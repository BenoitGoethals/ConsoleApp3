using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace ConsoleApp3
{
    public sealed class MongoDbConnection
    {
        private static readonly MongoDbConnection Instance=new MongoDbConnection();

        private static readonly MongoClient MongoClient = new MongoClient(Resource1.mongodb.ToString());

        public MongoClient Client => MongoClient;

        public static MongoDbConnection GetInstance()
        {
            return Instance;
        }
    }
}
