//Niklas Ekstein 9107233133
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace A5WebAPI.Models
{
    public class ChatRoom
    {
        public int chatRoomID { get; set; }
        public int chatRoomOwner { get; set; }
        public string roomName { get; set; }
    }
}
