using Basement.Framework.Data;
using SqlMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMonitoring.Services
{

    public class MonitoringService
    {
        IDatabase database = Database.Uni2uni_LocalLife;
        public MonitoringService()
        {

        }

        public Entity_Monitoring SingleAsModel()
        {
            string dtime = DateTime.Now.ToString();
            string sql = @"SELECT TOP 1 
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
                                QS.creation_time <  GETDATE() ORDER BY QS.creation_time DESC";
            Entity_Monitoring model = database.SingleAsModel<Entity_Monitoring>(sql);
            return model;

        }
    }
}
