using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace ConsoleApplication1
{
	/// <summary>
	/// mongodb 服务类
	/// </summary>
	public class MongoDBServer
	{
		public void Init()
		{
			//var server = MongoServer.Create("mongodb://127.0.0.1");
			//var db = server.GetDatabase("blog");

			//var collection = db.GetCollection<ApiError>("ApiError");

			const string strconn = "mongodb://127.0.0.1:27017";

			//数据库名称

			const string dbName = "cnblogs";

			//连接Mongo数据库
			var client = new MongoClient(strconn);

			//获得数据库
			var db = client.GetDatabase(dbName);

			// 获得 ApiErrors 集合
			var collections = db.GetCollection<ApiExecTime>("ApiExecTimes");


			//新增单条数据

			//var singleApiExecTimes = new ApiExecTime();

			//collections.InsertOneAsync(singleApiExecTimes);


			//var ApiErrorList = new List<ApiExecTime>();

			//for (var i = 110; i < 119; i++)
			//{
			//	ApiErrorList.Add(new ApiExecTime() { BeginTime = DateTime.Now, Id = Guid.NewGuid().ToString(), EndTime = DateTime.Now, Url = "aa" + i });
			//}

			//// 批量添加
			//collections.InsertManyAsync(ApiErrorList);


			//// 统计所有个数
			var count = collections.Count(new BsonDocument());

			////根据条件统计
			var countFilter = collections.Count(t => t.BeginTime > DateTime.Now.AddDays(1));

			//// 查询 获得第一个对象 
			//var document = collections.Find(new BsonDocument()).FirstOrDefault();

			//Console.WriteLine(document);

			//// 查询 获得所有对象
			//var documentList = collections.Find(new BsonDocument()).ToList();

			//// 
			// collections.Find(new BsonDocument()).ForEachAsync(t => Console.WriteLine(t.Id));


			//// 
			// var cursor = collections.Find(new BsonDocument()).ToCursor();

			// foreach (var itemDocument in cursor.ToEnumerable())
			// {
			//	 Console.WriteLine(itemDocument.Id);
			// }


			//var filter = Builders<BsonDocument>.Filter.Eq("i", 71);

			//var documentFirst = collections.Find(filter).First();
			//Console.WriteLine(document);




			/*
			 *  新增api 错误集合**
			 */


			var aPIErrorRecordCollections = db.GetCollection<APIErrorRecord>("APIErrorRecords");


			aPIErrorRecordCollections.InsertOneAsync(new APIErrorRecord());


		}
	}

	/// <summary>
	/// api 执行时间
	/// </summary>
	public class ApiExecTime
	{
		/// <summary>
		/// 主键
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// 请求接口
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// 开始时间
		/// </summary>

		public DateTime BeginTime { get; set; }
		/// <summary>
		/// 结束时间
		/// </summary>

		public DateTime EndTime { get; set; }
		/// <summary>
		/// 执行秒
		/// </summary>

		public double ExecTime { get; set; }

		/// <summary>
		/// 是否出错
		/// </summary>
		public bool IsError { get; set; }
	}

	/// <summary>
	/// api 错误记录
	/// </summary>
	public class APIErrorRecord
	{

		public APIErrorRecord()
		{
			Id = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// 编号
		/// </summary>		
		public string Id { get; set; }

		/// <summary>
		/// 请求头
		/// </summary>		
		public string Headers { get; set; }

		/// <summary>
		/// 方法(Get,Post)
		/// </summary>		
		public string Method { get; set; }

		/// <summary>
		/// 来源
		/// </summary>		
		public string Referrer { get; set; }

		/// <summary>
		/// IP 地址
		/// </summary>		
		public string IPAddres { get; set; }

		/// <summary>
		/// 地址
		/// </summary>	
		public string Url { get; set; }

		/// <summary>
		/// 请求参数
		/// </summary>		
		public string ActionArguments { get; set; }

		/// <summary>
		/// 错误信息
		/// </summary>
		public string Error { get; set; }


		/// <summary>
		/// 是否解决
		/// </summary>
		public bool IsSolved { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>		
		public DateTime OperateTime { get; set; }

	}

	/// <summary>
	/// 用户操作记录_web
	/// </summary>
	public class UserOperateWebRecord
	{
		public UserOperateWebRecord()
		{
			Id = Guid.NewGuid().ToString();
		}
		/// <summary>
		/// 日志编号
		/// </summary>	

		public string Id { get; set; }

		/// <summary>
		/// 用户编号
		/// </summary>		
		public int UserId { get; set; }

		/// <summary>
		/// 令牌
		/// </summary>	
		public string Token { get; set; }

		/// <summary>
		/// 请求头部
		/// </summary>
		public string Headers { get; set; }

		/// <summary>
		/// 来源地址
		/// </summary>		
		public string Referrer { get; set; }

		/// <summary>
		/// 请求方式
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// IP地址
		/// </summary>		
		public string IPAddres { get; set; }

		/// <summary>
		/// 访问地址
		/// </summary>		
		public string Url { get; set; }

		/// <summary>
		/// 参数集合
		/// </summary>		
		public string ActionArguments { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>		
		public DateTime OperateTime { get; set; }

		/// <summary>
		/// 是否出错
		/// </summary>
		public bool IsError { get; set; }
	}


	/// <summary>
	/// 用户操作api 记录
	/// </summary>
	public class UserOperateAPIRecord
	{
		/// <summary>
		/// 编号
		/// </summary>		

		public string Id { get; set; }

		/// <summary>
		/// 用户编号
		/// </summary>		
		public int UserId { get; set; }

		/// <summary>
		/// 令牌
		/// </summary>		
		public string Token { get; set; }

		/// <summary>
		/// 请求头部
		/// </summary>
		public string Headers { get; set; }

		/// <summary>
		///来源地址
		/// </summary>		
		public string Referrer { get; set; }

		/// <summary>
		/// 请求方式
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// IP地址
		/// </summary>		
		public string IPAddres { get; set; }

		/// <summary>
		/// 访问地址
		/// </summary>		
		public string Url { get; set; }

		/// <summary>
		/// 参数集合
		/// </summary>		
		public string ActionArguments { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>		
		public DateTime OperateTime { get; set; }

		/// <summary>
		/// 是否出错
		/// </summary>
		public bool IsError { get; set; }
	}
}