using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml;
using AutoMapper;
using ExpectedObjects;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class GenericClassTests
	{
		[Test]
		public void should_convert_to_baccarat_sendCard_info()
		{
			var xmlMessage = "<msg id=\"5793311\" type=\"10001\"><add p=\"product\" v=\"Baccarat\" /><add p=\"station\" v=\"101\" /><add p=\"timestamp\" v=\"1572971795777\" /><add p=\"gameID\" v=\"41480941\" /><add p=\"CardSeq\" v=\"Banker1\" /><add p=\"Card\" v=\"H11\" /><add p=\"TotalPoints\" v=\"0\" /></msg>";
			var xmlConverterAdapter= new XmlConverterAdapter<SendCardInfo>();
			var expected = new SendCardInfo()
			{
				Product = "Baccarat",
				Station = 101,
				Timestamp = "1572971795777",
				GameID = 41480941,
				CardSeq = "Banker1",
				Card = "H11",
				TotalPoints = 0

			};
			var actual = xmlConverterAdapter.Convert(xmlMessage);

			expected.ToExpectedObject().ShouldEqual(actual);
		}

		[Test]
		public void test_trim_end()
		{

		}
	}
	public class SendCardInfo
	{
		public string Product { get; set; }
		public int Station { get; set; }
		public string Timestamp { get; set; }
		public int GameID { get; set; }
		public string CardSeq { get; set; }
		public string Card { get; set; }
		public int TotalPoints { get; set; }
	}

	public class XmlConverterAdapter<T> : IConverterAdapter<T>
	{
		public T Convert(string input)
		{
			var propertyInfos = typeof(T).GetProperties();
			var xmlNodes = GetXmlNodes(input);
			var dictionary = new Dictionary<string, string>();
			foreach (XmlElement node in xmlNodes)
			{
				dictionary.Add(node.Attributes["p"].Value, node.Attributes["v"].Value);
				Debug.WriteLine(node.Attributes["p"].Value + ":" + node.Attributes["v"].Value);
			}

			var sendCardInfo = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dictionary));

			//foreach (var info in propertyInfos)
			//{

			//	Debug.WriteLine(info.Name);
			//}
			return sendCardInfo;
		}

		private XmlNodeList GetXmlNodes(string input)
		{
			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(input);
			return xmlDocument.SelectSingleNode("msg").ChildNodes;
		}
	}

	public interface IConverterAdapter<T>
	{
		T Convert(string input);
	}
}