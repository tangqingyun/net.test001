using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.MVC.Domain
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        public Guid StudentID { get; set; }        
        public string LastName { get; set; }       
        public string FirstMidName { get; set; }        
        public DateTime EnrollmentDate { get; set; }      
        /// <summary>
        /// 登陆记实体集合
        /// </summary>
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
