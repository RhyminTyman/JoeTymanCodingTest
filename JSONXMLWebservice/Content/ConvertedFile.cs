using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using XMLJSONConvertor;

class ConvertedFile : IHttpActionResult
{
	private const string APPLICATION_PREFIX = "application/";
	private DataProcessor myDataProcessor; 
	public ConvertedFile(string _content){
		myDataProcessor = new DataProcessor(_content);
	}
	public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken){
		if (myDataProcessor.CheckFile()){
			var response = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StreamContent(FileMaker.GenerateStreamFromString(myDataProcessor.ConvertFile()))
			};
			response.Content.Headers.ContentType = new MediaTypeHeaderValue(APPLICATION_PREFIX+myDataProcessor.FileExtension);
			return Task.FromResult(response);
		}else {
			var response = new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
			return Task.FromResult(response);
		}

	}


}


