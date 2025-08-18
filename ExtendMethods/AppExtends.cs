using System.Net;
using Microsoft.AspNetCore.Http;
namespace AppMVC.Net.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
                {
                    appError.Run(async context =>
                    {
                        var response = context.Response;
                        var statuscode = response.StatusCode;

                        var content = @$"
                            <html>
                            <head>
                                <meta charset='utf-8' />
                                <title>Error {statuscode}</title>
                            </head>
                            <body>
                                <h1>Error {statuscode} - {(HttpStatusCode)statuscode}</h1>
                                <p>An error occurred while processing your request.</p>
                            </body>
                            </html>";

                        response.ContentType = "text/html";
                        await response.WriteAsync(content);
                    });
                });
        }
    }

}