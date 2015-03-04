using Basement.Framework.Data;
using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SqlMonitoring.Models
{
    [Serializable]
    public class Entity_Monitoring : IEntity
    {
        [Column("creation_time", DbType.DateTime, true, false)]
        public DateTime creation_time { set; get; }
        [Column("statement_text", DbType.String, true, false)]
        public string statement_text { set; get; }
        [Column("text", DbType.String, true, false)]
        public string text { set; get; }
        [Column("total_worker_time", DbType.Int64, true, false)]
        public long total_worker_time { set; get; }
        [Column("last_worker_time", DbType.Int64, true, false)]
        public long last_worker_time { set; get; }
        [Column("max_worker_time", DbType.Int64, true, false)]
        public long max_worker_time { set; get; }
        [Column("min_worker_time", DbType.Int64, true, false)]
        public long min_worker_time { set; get; }
    }
}