using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A5WebAPI.Models;

namespace A5WebAPI.Models
{
    //Context class for the database with seed data for test.
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public DbSet<ChatRoomMembers> ChatRoomMember { get; set; }
        public DbSet<ChatUser> ChatUserSelect { get; set; }
        
        //Rename to ChatRooms?
        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<ChatMessages> ChatMessage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatUser>().HasData(
                new ChatUser { chatUserID = 1, password = "assignment5", username = "assignment5" },
                new ChatUser { chatUserID = 2, password = "assignment52", username = "assignment52" },
                new ChatUser { chatUserID = 3, password = "assignment53", username = "assignment53" }
                );
        }


    }

}