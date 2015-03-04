﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMongodb
{
    public class User
    {
         /// <summary>
        /// BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId 
        /// </summary>
        //public BsonType.ObjectId _Id { set; get; }
        public string Name { get; set; }
        public string Sex { set; get; }
        public  int _id { set; get; }
    }
}
