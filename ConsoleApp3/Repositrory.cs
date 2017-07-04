using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace ConsoleApp3
{
    sealed class Repositrory<T> where T : class, new()
    {
        private static readonly Repositrory<T> Instance = new Repositrory<T>();
       
        private static readonly IMongoDatabase DbDatabase=MongoDbConnection.GetInstance().Client.GetDatabase("db" + new T().GetType().Name);
        private static readonly IMongoCollection<T> PostsCol = DbDatabase.GetCollection<T>("db" + new T().GetType().Name);
       


        public  List<T> All()
        {
            
         
           return IAsyncCursorSourceExtensions.ToList<T>(PostsCol.AsQueryable<T>());
        }


        public  void Add(T t)
        {
     
            PostsCol.InsertOne(t);
        }

        public void Add(IList<T> list)
        {
         
            PostsCol.InsertMany(list);
        }

        public List<T> Get()
        {
            return null;
        }


        public long Count()
        {
        
           return PostsCol.AsQueryable().Count<T>();
        }

        public void RemoveAll()
        {
          
         
            DbDatabase.DropCollection("db" + new T().GetType().Name);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public static Repositrory<T> GetInstance()
        {
            return Instance;
        }

       
    }
}
