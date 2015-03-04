using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace EntityFramework.MVC.Domain
{
    /// <summary>
    /// 课程表实体
    /// </summary>
    [Table("Course")]
    public class Course:IEntity
    {
       
        public Guid CourseID { get; set; }        
        public string Title { get; set; }        
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
