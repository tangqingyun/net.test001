using MvcWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace MvcWebAPI.API
{
    public class ContactController : ApiController
    {
      
        User[] user = new User[] 
        { 
            new User {  age= 1, Name = "Tomato Soup", Email = "123@qq.com" }, 
            new User { age = 2, Name = "Yo-yo", Email = "1234@qq.com" }, 
            new User { age = 3, Name = "Hammer", Email = "12345@qq.com" } 
        };
      
        public IEnumerable<User> GetAll()
        {
            return user;
        }
      
        public string Get(int id)
        {
            return "value" + id;
        }

    }
}
