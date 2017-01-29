using System;
using XMLJSONConvertor;

namespace JSONXMLConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length != 2)
				Console.WriteLine("Please enter a source file name and a destination file name");
			else {
				DataProcessor myDataProcessor = new DataProcessor(FileMaker.ReadFile(args[0]));
				if (myDataProcessor.CheckFile())
					FileMaker.WriteFile(args[1],myDataProcessor.ConvertFile());
				Console.WriteLine(myDataProcessor.Log);
				                                                  
			}
				
		}

	}
}
