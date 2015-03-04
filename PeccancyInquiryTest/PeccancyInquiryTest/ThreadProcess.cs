using Basement.Framework.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace PeccancyInquiryTest
{
    public class ThreadProcess
    {
        private readonly static string URL = "http://mobile.auto.sohu.com/wzcx/common/api/queryByCity.at?appKey=pc";
        private IList<VehicleEntity> CarList;
        private event EventHandler EventCompleted;//处理完成引发的事件
        private List<Thread> threadList = new List<Thread>();
        public ThreadProcess()
        {
            //threadList.Skip(1).Take(10);

            CarList = LoadData();
            for (int i = 0; i < ThreadCount; i++)
            {
                Thread thread = new Thread(new ThreadStart(ProcessData));
                thread.Name = "线程" + (i + 1);
                threadList.Add(thread);
            }
            EventCompleted += new EventHandler(Process_EventCompleted);
        }

        /// <summary>
        /// 运行线程
        /// </summary>
        public void Run()
        {
            threadList.ForEach(thread =>
            {
                thread.Start();
            });
            Console.WriteLine("开始所有线程的执行。");
        }

        private void ExecuteThread()
        {

            CarList = CarList.Where(m => m.IsCompleted == false).ToList();
            foreach (VehicleEntity model in CarList)
            {
                Monitor.Enter(this);//锁定，保持同步
                string carNum = "京" + model.EcarPart;//车牌号
                IList<ParamKeyValue> datas = new List<ParamKeyValue> { 
                 new ParamKeyValue("carNum",carNum),              
                 new ParamKeyValue("city",model.City),
                 new ParamKeyValue("ecarBelong",model.ProvinceCode.ToString().Substring(0,2)),
                 new ParamKeyValue("ecarPart",model.EcarPart),
                 new ParamKeyValue("engineNum",model.EngineNum),              
                 new ParamKeyValue("province",model.ProvinceCode),
                };
                string content = HttpHelper.Post(URL, datas, "", null, null, Encoding.UTF8);

                string statusPattern = string.Format("\"STATUS\":\"{0}\"", @"[\s\S]*?");
                string statusStr = Regex.Match(content, statusPattern).Value;//获取状态码
                string threadName = Thread.CurrentThread.Name + "|";
                if (!string.IsNullOrWhiteSpace(statusStr))
                {
                    string[] arr = statusStr.Split(':');
                    if (arr.Length > 1)
                    {
                        string status = arr[1];
                        switch (status.Replace("\"", ""))
                        {
                            case "0"://有违章记录
                                Console.WriteLine(threadName + "车牌号：" + carNum + "有违章记录");
                                break;
                            case "1"://输入的车辆查询信息有误
                                string errmsgPattern = string.Format("\"ERRMSG\":\"{0}\"", @"[\s\S]*?");
                                string errmsgStr = Regex.Match(content, errmsgPattern).Value;
                                Console.WriteLine(threadName + "车牌号：" + carNum + errmsgStr.Split(':')[1]);
                                break;
                            case "2"://没有违章记录
                                Console.WriteLine(threadName + "车牌号：" + carNum + "没有违章记录");
                                break;
                            default://未知错误
                                Console.WriteLine("未知错误");
                                break;
                        }
                    }
                }
                model.IsCompleted = true;
                int completedCount = CarList.Where(m => m.IsCompleted == false).ToList().Count;
                if (completedCount == 0)//如果全部处理完成则触发完成事件
                {
                    EventCompleted(this, new EventArgs());//引发完成事件
                }
                Monitor.Exit(this);//取消锁定
            }


        }

        /// <summary>
        /// 处理数据
        /// </summary>
        private void ProcessData()
        {
            while (true)
            {
                Monitor.Enter(this);//锁定，保持同步 
                VehicleEntity model = CarList[0];
                string carNum = "京" + model.EcarPart;//车牌号
                IList<ParamKeyValue> datas = new List<ParamKeyValue> { 
                 new ParamKeyValue("carNum",carNum),              
                 new ParamKeyValue("city",model.City),
                 new ParamKeyValue("ecarBelong",model.ProvinceCode.ToString().Substring(0,2)),
                 new ParamKeyValue("ecarPart",model.EcarPart),
                 new ParamKeyValue("engineNum",model.EngineNum),              
                 new ParamKeyValue("province",model.ProvinceCode),
                };
                string content = HttpHelper.Post(URL, datas, "", null, null, Encoding.UTF8);
                string statusPattern = string.Format("\"STATUS\":\"{0}\"", @"[\s\S]*?");
                string statusStr = Regex.Match(content, statusPattern).Value;//获取状态码
                string threadName = Thread.CurrentThread.Name + "|";
                if (string.IsNullOrWhiteSpace(statusStr)) {
                    continue;
                }
                string[] arr = statusStr.Split(':');
                if (arr.Length > 1)
                {
                    string status = arr[1];
                    switch (status.Replace("\"", ""))
                    {
                        case "0"://有违章记录
                            PeccancyInfo list = Basement.Framework.Serialization.JsonSerializer.ConvertToObject<PeccancyInfo>(content);
                            Console.WriteLine(threadName + "车牌号：" + carNum + "有违章记录");
                            break;
                        case "1"://输入的车辆查询信息有误
                            string errmsgPattern = string.Format("\"ERRMSG\":\"{0}\"", @"[\s\S]*?");
                            string errmsgStr = Regex.Match(content, errmsgPattern).Value;
                            Console.WriteLine(threadName + "车牌号：" + carNum + errmsgStr.Split(':')[1]);
                            break;
                        case "2"://没有违章记录
                            Console.WriteLine(threadName + "车牌号：" + carNum + "没有违章记录");
                            break;
                        default://未知错误
                            Console.WriteLine("未知错误");
                            break;
                    }
                }

                model.IsCompleted = true;
                CarList.RemoveAt(0);
                if (CarList.Count == 0)//如果全部处理完成则触发完成事件
                {
                    EventCompleted(this, new EventArgs());//引发完成事件
                }
                Monitor.Exit(this);//取消锁定
            }
        }

        private void Process_EventCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("执行完了，停止了所有线程的执行");
            threadList.ForEach(thread =>
            {
                thread.Abort();
            });
        }

        /// <summary>
        /// 需要开启的线程数量
        /// </summary>
        private int ThreadCount
        {
            get
            {
                string count = ConfigurationManager.AppSettings["ThreadCount"];
                return Convert.ToInt32(count);
            }
        }

        private IList<VehicleEntity> LoadData()
        {
            IList<VehicleEntity> VehicleList = new List<VehicleEntity> { 
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "62002049",
                        EcarPart = "JH0018",
                        ProvinceCode = "110000",
                        ShortID = 11
                    },
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "375653",
                        EcarPart = "NN3T19",
                        ProvinceCode = "110000",
                        ShortID = 11
                    },
                    new VehicleEntity
                    {
                        City = "110000",
                        EcarBelong = "11",
                        EngineNum = "375653",
                        EcarPart = "NN3T10",
                        ProvinceCode = "110000",
                        ShortID = 11
                    }
            };
            return VehicleList;
        }

    }
}
