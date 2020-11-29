using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace A5WebAPI.Models
{
    //Static class to get the current chat user.
    public static class CurrentUser
    {

        public static ChatUser usernameSession;

    }
}
