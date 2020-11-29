//Niklas Ekstein 9107233133
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace A5WebAPI.Models
{
    public class ChatUser
    {
        public int chatUserID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
