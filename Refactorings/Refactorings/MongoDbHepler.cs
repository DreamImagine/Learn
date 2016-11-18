using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApplication1
{
	/// <summary>
	/// MongoDB帮助类
	/// </summary>
	internal static class MongoDbHepler
	{

		/// <summary>
		/// 获取数据库实例对象
		/// </summary>
		/// <param name="connectionString">数据库连接串</param>
		/// <param name="dbName">数据库名称</param>
		/// <returns>数据库实例对象</returns>
		private static IMongoDatabase GetDatabase(string connectionString, string dbName)
		{
			//连接Mongo数据库
			var client = new MongoClient(connectionString);

			// 如果dbName 是新库的名字
			// 如果有 dbName 这个库，就查出这个库
			// 否则就创建
			var mongoDb = client.GetDatabase(dbName);

			////获得数据库
			return mongoDb;
		}

		#region 新增

		/// <summary>
		/// 插入一条记录
		/// </summary>
		/// <typeparam name="T">数据类型</typeparam>
		/// <param name="connectionString">数据库连接串</param>
		/// <param name="dbName">数据名称,名称不存在就会创建一个新的库</param>
		/// <param name="collectionName">集合名称，名称不存在就会创建一个新的集合</param>
		/// <param name="model">数据对象</param>
		public static void Insert<T>(string connectionString, string dbName, string collectionName, T model) where T : class
		{
			if (model == null)
			{
				throw new ArgumentNullException("model", "待插入数据不能为空");
			}
			var db = GetDatabase(connectionString, dbName);

			var collection = db.GetCollection<T>(collectionName);
			collection.InsertOneAsync(model);
		}

		/// <summary>
		/// 插入多条记录
		/// </summary>
		/// <typeparam name="T">数据类型</typeparam>
		/// <param name="connectionString">数据库连接串</param>
		/// <param name="dbName">数据名称,名称不存在就会创建一个新的库</param>
		/// <param name="collectionName">集合名称，名称不存在就会创建一个新的集合</param>
		/// <param name="modelList">数据对象</param>
		public static void Insert<T>(string connectionString, string dbName, string collectionName, IList<T> modelList) where T : class
		{
			if (modelList == null)
			{
				throw new ArgumentNullException("modelList", "待插入数据不能为空");
			}
			var db = GetDatabase(connectionString, dbName);

			var collection = db.GetCollection<T>(collectionName);
			collection.InsertManyAsync(modelList);
		}

		#endregion


		/// <summary>
		/// 获得集合中所有的文档条数
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="dbName">Name of the database.</param>
		/// <param name="collectionName">Name of the collection.</param>
		/// <returns></returns>
		public static long GetCount<T>(string connectionString, string dbName, string collectionName) where T : class
		{
			var db = GetDatabase(connectionString, dbName);

			var collections = db.GetCollection<T>(collectionName);

			return collections.Count(new BsonDocument());
		}

		/// <summary>
		/// 获得集合中条数
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="dbName">Name of the database.</param>
		/// <param name="collectionName">Name of the collection.</param>
		/// <param name="filter">过滤表达式</param>
		/// <returns></returns>
		public static long GetCount<T>(string connectionString, string dbName, string collectionName, Expression<Func<T, bool>> filter) where T : class
		{
			var db = GetDatabase(connectionString, dbName);

			var collections = db.GetCollection<T>(collectionName);

			return collections.Count(filter);
		}






		#region 更新

		///// <summary>
		///// 更新数据
		///// </summary>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <param name="query">查询条件</param>
		///// <param name="dictUpdate">更新字段</param>
		//public static void Update(string connectionString, string dbName, string collectionName, IMongoQuery query, Dictionary<string, BsonValue> dictUpdate)
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection(collectionName);
		//	var update = new UpdateBuilder();
		//	if (dictUpdate != null && dictUpdate.Count > 0)
		//	{
		//		foreach (var item in dictUpdate)
		//		{
		//			update.Set(item.Key, item.Value);
		//		}
		//	}
		//	collection.Update(query, update, UpdateFlags.Multi);
		//}

		#endregion

		//#region 查询

		///// <summary>
		///// 根据ID获取数据对象
		///// </summary>
		///// <typeparam name="T">数据类型</typeparam>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <param name="id">ID</param>
		///// <returns>数据对象</returns>
		//public static T GetById<T>(string connectionString, string dbName, string collectionName, ObjectId id)
		//	where T : class
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection<T>(collectionName);
		//	return collection.FindOneById(id);
		//}

		///// <summary>
		///// 根据查询条件获取一条数据
		///// </summary>
		///// <typeparam name="T">数据类型</typeparam>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <param name="query">查询条件</param>
		///// <returns>数据对象</returns>
		//public static T GetOneByCondition<T>(string connectionString, string dbName, string collectionName, IMongoQuery query)
		//	where T : class
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection<T>(collectionName);
		//	return collection.FindOne(query);
		//}

		///// <summary>
		///// 根据查询条件获取多条数据
		///// </summary>
		///// <typeparam name="T">数据类型</typeparam>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <param name="query">查询条件</param>
		///// <returns>数据对象集合</returns>
		//public static List<T> GetManyByCondition<T>(string connectionString, string dbName, string collectionName, IMongoQuery query)
		//	where T : class
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection<T>(collectionName);
		//	return collection.Find(query).ToList();
		//}

		///// <summary>
		///// 根据集合中的所有数据
		///// </summary>
		///// <typeparam name="T">数据类型</typeparam>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <returns>数据对象集合</returns>
		//public static List<T> GetAll<T>(string connectionString, string dbName, string collectionName)
		//	where T : class
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection<T>(collectionName);
		//	return collection.FindAll().ToList();
		//}

		//#endregion

		//#region 删除

		///// <summary>
		///// 删除集合中符合条件的数据
		///// </summary>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		///// <param name="query">查询条件</param>
		//public static void DeleteByCondition(string connectionString, string dbName, string collectionName, IMongoQuery query)
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection(collectionName);
		//	collection.Remove(query);
		//}

		///// <summary>
		///// 删除集合中的所有数据
		///// </summary>
		///// <param name="connectionString">数据库连接串</param>
		///// <param name="dbName">数据库名称</param>
		///// <param name="collectionName">集合名称</param>
		//public static void DeleteAll(string connectionString, string dbName, string collectionName)
		//{
		//	var db = GetDatabase(connectionString, dbName);
		//	var collection = db.GetCollection(collectionName);
		//	collection.RemoveAll();
		//}

		//#endregion
	}
}