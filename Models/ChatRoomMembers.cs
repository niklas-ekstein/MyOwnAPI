using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace A5WebAPI.Models
{
    public class ChatRoomMembers
    {
        public int chatRoomMembersId { get; set; }
        public int chatRoomID { get; set; }
        public int chatUserID { get; set; }
    }
}
