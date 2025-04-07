using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperHero.Core.MediatR;
using SuperHero.Core.Service;
using System.Net;

namespace SuperHero.API.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static readonly JsonSerializerSettings DefaultSerializerSettings = null;

        public static readonly System.Text.Json.JsonSerializerOptions DefaultSerializerOptions = null;

        static ControllerBaseExtensions()
        {
            DefaultSerializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            DefaultSerializerOptions = new System.Text.Json.JsonSerializerOptions();
        }

        private static Task<TResponse> HandleApplicationRequest<TRequest, TResponse>(ControllerBase controller, TRequest request, CancellationToken cancellationToken)
                where TRequest : IRequest<TResponse>
        {

            var requestMediator = ServiceLocator.Current.GetInstance<IRequestHandler<TRequest, TResponse>>();

            var result = requestMediator.Handle(request, cancellationToken);

            return result;
        }

        public static async Task<IActionResult> HandleQueryRequest<TRequest, TResponse>(this ControllerBase controller, TRequest request, CancellationToken cancellationToken)
           where TRequest : IRequest<TResponse>
           where TResponse : ServiceResponse
        {
            var response = await HandleApplicationRequest<TRequest, TResponse>(controller, request, cancellationToken).ConfigureAwait(false);

            if (response != null)
            {
                if (response.Status == null)
                    response.SetOk();

                response.StatusDescription = response.StatusDescription ?? $"Response of {typeof(TResponse).Name}";
            }

            return controller.ApiResult(response);
        }

        private static IActionResult ApiResult(this ControllerBase controller, object content)
        {
            return ApiResult(controller.Request, HttpStatusCode.OK, content, DefaultSerializerOptions);
        }

        private static IActionResult ApiResult(this ControllerBase controller, HttpStatusCode statusCode, object content)
        {
            return ApiResult(controller.Request, statusCode, content, DefaultSerializerOptions);
        }

        private static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content)
        {
            return ApiResult(request, statusCode, content, DefaultSerializerOptions);
        }

        private static IActionResult ApiResult(HttpRequest request, HttpStatusCode statusCode, object content, System.Text.Json.JsonSerializerOptions serializerSettings)
        {
            var supportedResponseTypes = new string[] { "json" };
            var responseType = "json";

            string requestedContentType = request?.Query["type"];

            if (!string.IsNullOrEmpty(requestedContentType) && supportedResponseTypes.Contains(requestedContentType, StringComparer.OrdinalIgnoreCase))
            {
                responseType = requestedContentType;
            }

            if (responseType.Equals("json"))
            {
                var result = new JsonResult(content, serializerSettings)
                {
                    StatusCode = (int)statusCode
                };

                return result;
            }
            else
                throw new NotSupportedException("output format not supported");
        }
    }
}
