using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EZ.Framework.Integration.WebApi
{
    public class FileUploadController : ApiController
    {
        public async Task<HttpResponseMessage> Post()
        {
            // 检查是否是 multipart/form-data
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            HttpResponseMessage response = null;

            try
            {
                // 设置上传目录
                var provider = new MultipartFormDataStreamProvider(@"F:\\StudyProject\\webapi2demo\\CSdemo\\UpLoad");
                // 接收数据，并保存文件
                var bodyparts = await Request.Content.ReadAsMultipartAsync(provider);
                response = Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return response;
        }
    }
}