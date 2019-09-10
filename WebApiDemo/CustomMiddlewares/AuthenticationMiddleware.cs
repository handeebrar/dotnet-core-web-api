using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
        //bir sonraki delegeye geç komutu için
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"]; //basic hande:12345

            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase)) //autheader var ve basicle başlıyorsa
            {
                var token = authHeader.Substring(6).Trim(); //hande:12345
                var credentialString = "";

                try
                {
                    credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token)); //base64'ten encode 
                }
                catch (Exception)
                {

                    context.Response.StatusCode = 500;
                }

                var credentials = credentialString.Split(':');

                if (credentials[0] == "hande" && credentials[1] == "12345")
                {
                    var claims = new[]
                    {
                        new Claim("name", credentials[0]),
                        new Claim(ClaimTypes.Role, "Admin"),
                    };
                    var identity = new ClaimsIdentity(claims);
                    context.User = new ClaimsPrincipal(identity);
                }
                else
                {
                    context.Response.StatusCode = 401; //unauthrorized
                }
            }

            await _next(context);
        }
    }
}
