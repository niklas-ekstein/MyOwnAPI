//Niklas Ekstein 9107233133
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A5WebAPI.Models;

namespace A5WebAPI.Controllers
{
    //Controller that handles the API requests to https://localhost:44378/api/ChatRooms/ (Change port for your local host.)
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomsController : ControllerBase
    {
        private readonly ChatContext _context;
        
        public ChatRoomsController(ChatContext context)
        {
            _context = context;

        }

        //List all chat users in a chat room
        //There is no await used here.
        // GET: api/ChatRooms
        [HttpGet("{messages}/{id}")]
        public async Task<ActionResult<IEnumerable<ChatMessages>>> GetChatRoom(string messages, int id)
        {
            List<ChatMessages> cuList = new List<ChatMessages>();

            var SM = _context.ChatMessage;

            if(messages == "messages")
            {
                foreach (ChatMessages c in SM)
                {
                    if (c.chatRoomID == id)
                    {
                        cuList.Add(c);
                    }
                }
            }

            return cuList;
        }
        
        //List all messages for a chat room.
        //There is no await used here.
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ChatRoomMembers>>> GetChatRoom(int id)
        {
            List<ChatRoomMembers> cuList = new List<ChatRoomMembers>();

            var SM = _context.ChatRoomMember;

            foreach (ChatRoomMembers c in SM)
            {
                if (c.chatRoomID == id)
                {
                    cuList.Add(c);
                }
            }

            return cuList;
        }

        //Update room with PUT by sending the ID number of the room.
        // PUT: api/ChatRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatRoom(int id, ChatRoom chatRoom)
        {
            if (chatRoom.chatRoomOwner == CurrentUser.usernameSession.chatUserID)
            {
                if (id != chatRoom.chatRoomID)
                {
                    return BadRequest();
                }
                _context.Entry(chatRoom).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatRoomExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();

            }
            else
            {
                return NotFound();
            }

        }

        //Create a chat message, all chat members can send messages to rooms they are members in.
        [HttpPost("{id}")]
        public async Task<ActionResult<ChatRoom>> PostChatRoom(ChatMessages message, int id)
        {
            var SM = _context.ChatRoomMember;

            foreach (ChatRoomMembers c in SM)
            {
                if (c.chatRoomID == id && c.chatUserID == CurrentUser.usernameSession.chatUserID)
                {
                    _context.ChatMessage.Add(message);
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Invite user to room, all chat members that are members of a room can invite other chat users to the room.
        //Possible to add same member multiple times with this loop.
        [HttpPost("{cuID}/{crID}")]
        public async Task<ActionResult<ChatRoom>> PostChatRoom(int cuID, int crID)
        {
            var SM = _context.ChatRoomMember;

            foreach (ChatRoomMembers c in SM)
            {
                if (c.chatRoomID == crID)
                {
                    ChatRoomMembers CRM = new ChatRoomMembers { chatUserID = cuID, chatRoomID = crID };
                    _context.ChatRoomMember.Add(CRM);
                }
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Create a chatroom
        // POST: api/ChatRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChatRoom>> PostChatRoom(ChatRoom chatRoom)
        {
            chatRoom.chatRoomOwner = CurrentUser.usernameSession.chatUserID;

            _context.ChatRoom.Add(chatRoom);

            await _context.SaveChangesAsync();

            ChatRoomMembers CRM = new ChatRoomMembers { chatUserID = chatRoom.chatRoomOwner, chatRoomID = chatRoom.chatRoomID };
            _context.ChatRoomMember.Add(CRM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatRoom", new { id = chatRoom.chatRoomID }, chatRoom);

        }

        //Delete a chat room
        // DELETE: api/ChatRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatRoom>> DeleteChatRoom(int id)
        {
            var chatRoom = await _context.ChatRoom.FindAsync(id);

            if (chatRoom.chatRoomOwner == CurrentUser.usernameSession.chatUserID)
            {
                _context.ChatRoom.Remove(chatRoom);
                await _context.SaveChangesAsync();

                return chatRoom;
            }
            else
            {
                return NotFound();
            }
        }

        private bool ChatRoomExists(int id)
        {
            return _context.ChatRoom.Any(e => e.chatRoomID == id);
        }

    }
}
