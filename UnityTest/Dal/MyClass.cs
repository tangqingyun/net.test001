﻿using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dal
{
    public class MyClass:IClass
    {
        public string ShowInfo()
        {
            return "这是我的班级!";
        }
    }
}