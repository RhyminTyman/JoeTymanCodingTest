using System.Xml;
using Newtonsoft.Json;

namespace XMLJSONConvertor
{
	public class DataProcessor
	{
		private const string XML = "xml";
		private const string JSON = "JSON";
		private string originalFile;
		private XmlDocument openedXMLFile  = new XmlDocument();
		private string fileExtension;
		private string log = "";

		public string FileExtension{
			get{
				return fileExtension;
			}
		}

		/*
 		* I created a log to provide some sort of insight
 		* to what is happening with processing the file
 		* while this would be unused with an API, it provides
 		* the user some information when using a console or windows
 		* app
 		*/
		public string Log{
			get{
				return log;
			}
		}

		public DataProcessor(string _originalFile){
			originalFile = _originalFile;
		}

		/*
		 * I decide to check the content of the file rather than 
		 * the extension, this allows the user to pass any file regardless
		 * extension and the application will determine how to 
		 * handle it, which will prevent possible other errors
		 * with a file not formated properly for the the 
		 * extension.
		 */
		public bool CheckFile()
		{
			if (originalFile.IsJson()){
				log += "Source file is JSON and will be converted to XML";
				fileExtension = JSON;
				return true;
			}
			try{
				openedXMLFile.LoadXml(originalFile);
				log += "Source file is XML and will be converted to JSON";
				fileExtension = XML;
				return true;
			}catch {
				log += "File is neither XML or JSON";
				return false;
			}
		}
		public string ConvertFile(){
			if (fileExtension == JSON){
				return JsonConvert.DeserializeXmlNode(originalFile).OuterXml;
			}else { 
				return JsonConvert.SerializeXmlNode(openedXMLFile);
			}
		}

	}

}

