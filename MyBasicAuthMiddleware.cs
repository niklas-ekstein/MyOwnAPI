using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A5WebAPI.Controllers;
using A5WebAPI.Models;

// You probably need to change the namespace
namespace A5WebAPI
{
    // Example copied from https://stackoverflow.com/questions/38977088/asp-net-core-web-api-authentication
    // Add app.UseMiddleware<MyBasicAuthMiddleware>(); to your Startup.cs file in the Configure method.
    public class MyBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        ChatUser currentUser;

        public MyBasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ChatContext db)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);

                var SelectedUser = db.ChatUserSelect;

                foreach (ChatUser CU in SelectedUser)
                {
                    if (CU.chatUserID == 1)
                    {
                        currentUser = CU;
                        CurrentUser.usernameSession = CU;
                    }
                }

                if (CurrentUser.usernameSession.username == username && CurrentUser.usernameSession.password == password)//"assignment5" && CurrentUser.usernameSession.password == "assignment5")
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }

            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }
    }
}

