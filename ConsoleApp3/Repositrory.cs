using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ConsoleApp3
{
    sealed class Repositrory<T> where T : class, new()
    {
        private static readonly Repositrory<T> Instance = new Repositrory<T>();
       
        private static readonly IMongoDatabase DbDatabase=MongoDbConnection.GetInstance().Client.GetDatabase("db" + new T().GetType().Name);
        private static readonly IMongoCollection<T> PostsCol = DbDatabase.GetCollection<T>("db" + new T().GetType().Name);
       


        public async Task<List<T>> All()
        {
          return await PostsCol.AsQueryable<T>().ToListAsync<T>();
        }


        public async void Add(T t)
        {
     
            await PostsCol.InsertOneAsync(t);
        }

        public async void Add(IList<T> list)
        {
         
           await PostsCol.InsertManyAsync(list);
        }

        public List<T> Get()
        {
            return null;
        }


        public async Task<long> Count()
        {
        
           return await PostsCol.CountAsync<T>(p => true);
        }

        public void RemoveAll()
        {
          
         
            DbDatabase.DropCollection("db" + new T().GetType().Name);

        }



        public static Repositrory<T> GetInstance()
        {
            return Instance;
        }

       
    }
}
