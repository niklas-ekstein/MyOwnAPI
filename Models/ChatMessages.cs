using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace A5WebAPI.Models
{
    public class ChatMessages
    {
        //Id is PK, can be removed and use ChatMessagesID
        public int Id { get; set; }
        public int ChatMessagesID { get; set; }
        
        public int chatRoomID { get; set; }
        public int chatMemberID { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string message { get; set; }
    }
}
