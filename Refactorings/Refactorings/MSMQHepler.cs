using System;
using System.Messaging;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MongoDB.Bson.IO;

namespace ConsoleApplication1
{
	public class MSMQHepler
	{

		/// <summary>
		/// 注册消息队列
		/// </summary>
		public void Init()
		{
			//declare the MQ Path  
			var ekQ = ".\\Private$\\EKTestQueue";

			//create the MQ if the MQ is not exist  
			if (!MessageQueue.Exists(ekQ))
			{
				MessageQueue.Create(ekQ);
			}

			//create a new queue  
			var queue = new MessageQueue(ekQ);

			for (int i = 0; i < 2; i++)
			{
				var test = new Test();

				test.Name = "fdsfd";
				test.Sex = "cvx";
				//serialize the model  

				//var str = "f";
				var str = xmlSerial(test);

				

				//send the model data to queue  
				queue.Send(test);
				Console.WriteLine("Message sent {0} \n--------------", "Test" + str);

			}


		}


		public void Receive()
		{
			var ekQ = ".\\Private$\\EKTestQueue";

			using (var queue = new MessageQueue(ekQ))
			{
				queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });
				var exist = false;
				
				while (!MessageQueue.Exists(ekQ))
				{

					Console.WriteLine("No Existing queue");

				}
				exist = true;

				while (exist)
				{
					var m = queue.Receive();

					Console.WriteLine("Nessage Received {0} \n-----",(string)m.Body);
				}
			}
		}


		public static string xmlSerial<T>(T serializeClass)
		{
			string xmlString = string.Empty;
			XmlWriterSettings settings = new XmlWriterSettings();
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			StringBuilder xmlStringBuilder = new StringBuilder();
			using (XmlWriter writer = XmlWriter.Create(xmlStringBuilder))
			{
				serializer.Serialize(writer, serializeClass);
				xmlString = xmlStringBuilder.ToString();
			}

			return xmlString;
		}



	}

	public class Test
	{
		public string Name { get; set; }
		public string Sex { get; set; }
	}
}