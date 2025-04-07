using System.Net;

namespace SuperHero.Core.Service
{
    public class ServiceResponse
    {
        public DateTime IssuedOn { get; set; } = DateTime.Now;
        public HttpStatusCode? Status { get; set; }
        public string StatusDescription { get; set; }

        public void SetOk() => Status = HttpStatusCode.OK;
        public void SetInternalServerError() => Status = HttpStatusCode.InternalServerError;
    }
}
