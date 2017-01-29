using System.Xml;
using Newtonsoft.Json;

namespace XMLJSONConvertor
{
	public class DataProcessor
	{
		private string originalFile;
		private XmlDocument openedXMLFile  = new XmlDocument();
		private string fileExtension;
		private string log = "";

		public string FileExtension{
			get{
				return fileExtension;
			}
		}

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
		 * the extension, this allows the user to pass any file
		 * extension and the application will determine how to 
		 * handle it, which will prevent possible other errors
		 * with a file not formated properly for the the 
		 * extension
		 */
		public bool CheckFile()
		{
			if (originalFile.IsJson()){
				log += "Source file is JSON will convert to XML";
				fileExtension = "JSON";
				return true;
			}
			try{
				openedXMLFile.LoadXml(originalFile);
				log += "Source file is XML will convert to JSON";
				fileExtension = "xml";
				return true;
			}catch {
				log += "File neither XML or JSON";
				return false;
			}
		}
		public string ConvertFile(){
			if (fileExtension == "JSON"){
				return JsonConvert.DeserializeXmlNode(originalFile).OuterXml;
			}else { 
				return JsonConvert.SerializeXmlNode(openedXMLFile);
			}
		}

	}

}

