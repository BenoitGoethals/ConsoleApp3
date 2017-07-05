using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public  class Repositrory<T> where T : class, new()
    {
        private static Repositrory<T> instance = new Repositrory<T>();
        private static MongoClient client = new MongoClient();
        public String DataBase { get; set; }


        public async Task<List<T>> All()
        {

            T t=new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            return await postsCol.AsQueryable<T>().ToListAsync<T>();
        }


        public async void Add(T t)
        {
            var db = client.GetDatabase("db"+DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            await postsCol.InsertOneAsync(t);
        }

        public async void Add(IList<T> list)
        {
            T t = new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            await postsCol.InsertManyAsync(list);
        }



        public async Task<long> Count()
        {
            T t = new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);

            return await postsCol.CountAsync<T>(p => true);
        }


        public  Task<DeleteResult> DeleteAllAsync()
        {
            T t = new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            return  postsCol.DeleteManyAsync(p => true);
        }




        public static Repositrory<T> GetInstance()
        {
            return instance;
        }

       
    }
}
