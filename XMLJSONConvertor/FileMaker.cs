using System.IO;
using System.Text;

namespace XMLJSONConvertor
{
	/*
	 * The FileMaker class is a utility class
	 * designed to handle reading and writing files,
	 * and opening streams
	*/
	public static class FileMaker
	{
		public static void WriteFile(string fileName, string content){
			using (StreamWriter outputFile = new StreamWriter(fileName, true)){
				try{
					outputFile.WriteLine(content);
				}
				catch (System.Exception ex){
					throw ex;
				}

			}
		}
		public static string ReadFile(string fileName){
			try{
				string fileContent = "";
				using (StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8)){
					fileContent = streamReader.ReadToEnd();
				}
				return fileContent;
			}catch (System.Exception ex){
				throw ex;
			}

		}
		public static Stream GenerateStreamFromString(string s){
			try{
				MemoryStream stream = new MemoryStream();
				StreamWriter writer = new StreamWriter(stream);
				writer.Write(s);
				writer.Flush();
				stream.Position = 0;
				return stream;
			}catch (System.Exception ex){
				throw ex;
			}
		}
		public static string GenerateStringFromStream(Stream stream){
			try{
				string s = "";
				using (var reader = new StreamReader(stream, Encoding.UTF8))
				{
					s = reader.ReadToEnd();
				}
				return s;
			}catch (System.Exception ex){
				throw ex;
			}

		}
	}
}
