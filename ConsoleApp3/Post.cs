using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleApp3
{

    [BsonIgnoreExtraElements]
    public class Post
    {
        public string name { get; set; }
        public string straat { get; set; }
        public string email { get; set; }


        public override string ToString()
        {
            return name + " " + straat + email;
        }

    }
}