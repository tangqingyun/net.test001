using Basement.Framework.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestSqlMonitoring
{
    public partial class MainForm : Form
    {
        IDatabase database = Database.Uni2uni_LocalLife;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT TOP 10 
                                --创建时间 
                                QS.creation_time, 
                                --查询语句 
                                SUBSTRING(ST.text,(QS.statement_start_offset/2)+1, 
                                ((CASE QS.statement_end_offset WHEN -1 THEN DATALENGTH(st.text) 
                                ELSE QS.statement_end_offset END - QS.statement_start_offset)/2) + 1 
                                ) AS statement_text, 
                                --执行文本 
                                ST.text, 
                                --执行计划 
                                QS.total_worker_time, 
                                QS.last_worker_time, 
                                QS.max_worker_time, 
                                QS.min_worker_time 
                                FROM 
                                sys.dm_exec_query_stats QS 
                                --关键字 
                                CROSS APPLY 
                                sys.dm_exec_sql_text(QS.sql_handle) ST 
                                WHERE 
                                QS.creation_time BETWEEN '2012-12-03 00:00:00' AND '2014-12-31 00:00:00' 
                                --AND ST.text LIKE '%%' 
                                ORDER BY 
                                QS.creation_time DESC";
            DataTable dt = database.GetDataTable(sql);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dr[1] +" ==执行时间："+dr[0]+"\r\n\r\n");
            }
            textBox1.Text = sb.ToString();
        }


    }
}
