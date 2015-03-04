using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMongodb
{
    class Program
    {

        const string strconn = "mongodb://127.0.0.1:27017";//数据库连接字符串

        const string dbName = "foobar";//数据库名称
        const string collectionName = "users";
        static MongoServer server = MongoDB.Driver.MongoServer.Create(strconn);//创建数据库链接
        static MongoDatabase db;
        static void Main(string[] args)
        {
            // server.Connect();
            // db = server.GetDatabase(dbName);//获得数据库
            db = GetDatabaseConection();

            //DeleteByObjId(7);
            //Insert();
            //User umodel = new User()
            //{
            //    _id = 7,
            //    Name = "lili",
            //    Sex = "女"
            //};
            //UpdateById(umodel);
            var list = FindAll();
            foreach (var itm in list)
            {
                Console.WriteLine(itm.Name);
            }
            Console.ReadKey();
        }


        public static bool Insert()
        {

            User users = new User();
            users._id = 11;
            users.Name = "zhangsan";
            users.Sex = "男";

            //获得Users集合,如果数据库中没有，先新建一个
            MongoCollection col = db.GetCollection(collectionName);
            col.Insert<User>(users);
            Console.WriteLine("插入成功！");
            return true;
        }

        public static void DeleteByObjId(int _id)
        {
            MongoCollection<User> usersCollection = db.GetCollection<User>(collectionName);
            IMongoQuery query = Query.EQ("_id", _id);
            usersCollection.Remove(query);
        }

        public static void UpdateById(User user)
        {
            MongoCollection<User> col = db.GetCollection<User>(collectionName);
            BsonDocument bd = BsonExtensionMethods.ToBsonDocument(user);

            IMongoQuery query = Query.EQ("_id", user._id);

            col.Update(query, new UpdateDocument(bd));


        }

        public static IList<User> FindAll()
        {
            IList<User> list = new List<User>();
            MongoCollection<User> col = db.GetCollection<User>(collectionName);
            var nlist = col.FindAll();
            foreach (var item in nlist)
            {
                list.Add(item);
            }
            return list;
        }

        public static MongoDatabase GetDatabaseConection()
        {
            var serverAddress = new List<MongoServerAddress>() { 
                new MongoServerAddress("127.0.0.1",27017)
            };
            var mongoConnectionStringBuilder = new MongoConnectionStringBuilder
            {
                Servers = serverAddress,
                ConnectionMode = serverAddress.Count() > 1 ? ConnectionMode.ReplicaSet : ConnectionMode.Direct
            };
            //mongoConnectionStringBuilder.Username = "aaa";
           // mongoConnectionStringBuilder.Password = "aaa";
            // var cacheServer = MongoServer.Create(mongoConnectionStringBuilder);
          
            var clientSettings = MongoClientSettings.FromConnectionStringBuilder(mongoConnectionStringBuilder);
            var cacheServer = new MongoClient(clientSettings).GetServer();
           
            MongoDatabase mdb= cacheServer.GetDatabase("foobar");
            
            return mdb;

        }

    }




}
