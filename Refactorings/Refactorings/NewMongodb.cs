using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication1
{
	public class NewMongodb
	{
		public void Init()
		{
			var client = new MongoClient("mongodb://localhost:27017");
			
			var database = client.GetDatabase("foo");

			//var collection = client.GetCollection<BsonDocument>("bar");

			//await collection.InsertOneAsync(new BsonDocument("Name", "Jack"));

			//var list = await collection.Find(new BsonDocument("Name", "Jack"))
			//	.ToListAsync();
		}
	}

	public class Person
	{
		public ObjectId Id { get; set; }

		public string Name { get; set; }
	}
}