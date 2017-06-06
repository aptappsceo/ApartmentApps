using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApartmentApps.API.Service.Controllers.Api
{
    class FileResult : IHttpActionResult
    {
        private readonly Byte[] _filePath;
        private readonly string _ext;
        private readonly string _contentType;

        public FileResult(Byte[] file, string ext, string contentType = null)
        {
            if (file == null) throw new ArgumentNullException("file");

            _filePath = file;
            _ext = ext;
            _contentType = contentType;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(_filePath))
            };

            var contentType = _contentType ?? MimeMapping.GetMimeMapping(_ext);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return Task.FromResult(response);
        }
    }
}