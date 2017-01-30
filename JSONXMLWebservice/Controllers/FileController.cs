using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using XMLJSONConvertor;

namespace JSONXMLWebservice.Controllers
{
    public class FileController : ApiController
    {
		[HttpPost, Route("api/process")]
		public async Task<IHttpActionResult> Process()
		{
			if (!Request.Content.IsMimeMultipartContent())
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

			var provider = new MultipartMemoryStreamProvider();
			await Request.Content.ReadAsMultipartAsync(provider);
			/*
			 * In theory the user could submit multiple files in the 
			 * POST however since I only want to process one file
			 * and send it back I am send back an error if I get more
			 * than one file
			 */
			if (provider.Contents.Count != 1)
				throw new HttpResponseException(HttpStatusCode.Forbidden);
			
			var buffer = await provider.Contents[0].ReadAsStreamAsync();

			return new ConvertedFile(FileMaker.GenerateStringFromStream(buffer));
		}

    }
}
