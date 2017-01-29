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
			var buffer = await provider.Contents[0].ReadAsStreamAsync();

			return new ConvertedFile(FileMaker.GenerateStringFromStream(buffer));
		}

    }
}
