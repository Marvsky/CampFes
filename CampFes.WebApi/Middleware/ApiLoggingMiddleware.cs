using CampFes.Models;
using System.Text;

namespace CampFes.WebApi.Middleware
{
    /// <summary>
    /// 擷取API串接紀錄中間層
    /// </summary>
    public class ApiLoggingMiddleware
    {
        private readonly ILogger<ApiLoggingMiddleware> _logger;

        private readonly RequestDelegate _next;

        public ApiLoggingMiddleware(ILogger<ApiLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //啟用請求緩衝區
                //不讓response讀取後就清空
                context.Request.EnableBuffering();

                //攔截請求
                var request = await FormatRequest(context.Request);

                // 紀錄回應前的狀態
                var originalBodyStream = context.Response.Body;

                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                await _next(context);

                var response = await FormatResponse(context.Response);

                //紀錄資訊
                _logger.LogInformation("Request: \n{Request}", request);
                _logger.LogInformation("Response: \n{Response}", response);

                // 將原始回應內容寫回
                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                _logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_001, ex.Message);
            }
        }

        /// <summary>
        /// 格式化請求
        /// </summary>
        private static async Task<string> FormatRequest(HttpRequest request)
        {
            try
            {
                request.EnableBuffering();
                var headers = FormatHeaders(request.Headers);
                var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();
                request.Body.Position = 0;
                var ip = request.HttpContext.Connection.RemoteIpAddress?.ToString();

                return $"Method: {request.Method}\n" +
                       $"URL: {request.Scheme}://{request.Host}{request.Path}{request.QueryString}\n" +
                       $"Headers: \n{headers}" +
                       $"Body: {body}\n" +
                       $"IP: {ip}";
            }
            catch (Exception ex)
            {
                return "格式化請求失敗:" + ex.Message;
            }
        }

        /// <summary>
        /// 格式化回應
        /// </summary>
        private static async Task<string> FormatResponse(HttpResponse response)
        {
            try
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                var headers = FormatHeaders(response.Headers);
                var body = await new StreamReader(response.Body, Encoding.UTF8).ReadToEndAsync();

                //response圖片 因為資料長度過長 所以不儲存在Log
                if (body.Length >= 2000)
                {
                    body = "長度過長，不存於Log";
                }

                response.Body.Seek(0, SeekOrigin.Begin);

                return $"Status code: {response.StatusCode}\n" +
                       $"Headers: \n{headers}" +
                       $"Body: {body}";
            }
            catch (Exception ex)
            {
                return "格式化回應失敗:" + ex.Message;
            }
        }

        /// <summary>
        /// 格式化標頭
        /// </summary>
        private static string FormatHeaders(IHeaderDictionary headers)
        {
            var formattedHeaders = new StringBuilder();
            foreach (var (key, value) in headers)
            {
                formattedHeaders.AppendLine($"\t{key}: {string.Join(",", value)}");
            }

            return formattedHeaders.ToString();
        }
    }
}
