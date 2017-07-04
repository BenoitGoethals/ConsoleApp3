using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace ConsoleApp3
{
    class Repositrory<T> where T : class, new()
    {
        private static Repositrory<T> instance = new Repositrory<T>();
        private static MongoClient client = new MongoClient();
        public String DataBase { get; set; }


        public  List<T> All()
        {

            T t=new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            return postsCol.AsQueryable<T>().ToList<T>();
        }


        public  void Add(T t)
        {
            var db = client.GetDatabase("db"+DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            postsCol.InsertOne(t);
        }

        public void Add(IList<T> list)
        {
            T t = new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);
            postsCol.InsertMany(list);
        }



        public long Count()
        {
            T t = new T();
            var db = client.GetDatabase("db" + DataBase);
            var postsCol = db.GetCollection<T>("db" + t.GetType().Name);

            return postsCol.Count<T>();
        }







        public static Repositrory<T> GetInstance()
        {
            return instance;
        }

       
    }
}
