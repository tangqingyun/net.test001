using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.Domain
{
    /// <summary>
    /// 学生登记表实体
    /// </summary>
    public class Enrollment
    {
        public Guid EnrollmentID { get; set; }
        public Guid CourseID { get; set; }
        public Guid StudentID { get; set; }        
        public decimal? Grade { get; set; }       
        /// <summary>
        /// 课程实体
        /// </summary>
        public virtual Course Course { get; set; } 
        /// <summary>
        /// 学生实体
        /// </summary>
        public virtual Student Student { get; set; }

    }
}
