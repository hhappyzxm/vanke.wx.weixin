using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;

namespace Vanke.WX.Weixin.Controllers
{
    public class FilesController : GenericApiController
    {
        [HttpPost]
        public async Task<IEnumerable<string>> Upload()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new Exception("Unsupported media type");
            }

            var provider = new CustomMultipartFormDataStreamProvider(HttpRuntime.AppDomainAppPath + @"Temp");

            await Request.Content.ReadAsMultipartAsync(provider);

            var files =
                provider.FileData
                    .Select(file => new FileInfo(file.LocalFileName))
                    .Select(fileInfo => fileInfo.Name).ToList();

            return files;
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize) : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                var fileExtension = Path.GetExtension(headers.ContentDisposition.FileName.Trim('"'));

                return Guid.NewGuid() + fileExtension;
            }
            else
            {
                return "NoName";
            }
        }
    }
}
