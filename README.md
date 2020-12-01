# MyOwnAPI

Please read documentation before you try to use the API:

You will need to use Postman or some similar software to use this API. There is
authorization that can be found in the ChatContext class, as some example seed
data.

The path: https://localhost:44378/api/ChatRooms (Change port for your local
host.)

Create a new chat room. The chat user that creates the room becomes the owner.
PATH: /chatrooms
HTTP Method: POST
Request body: {"roomName": “Name of the chat room” }
Response body: { "chatRoomID": 9, "chatRoomOwner": 1, "roomName": " Room name" }
or otherwise NotFound or BadRequest.

Delete a room by sending the ID number of the room, for example /1 for the room with
ID number 1. You will get information about the room in the response body.
PATH: /chatrooms/1
HTTP Method: DELETE
Response body: { "chatRoomID": 1, "chatRoomOwner": 1, "roomName": " Room name" }
or otherwise NotFound or BadRequest.

Update a room with PUT by sending the ID number of the room, for example /1 for the
room with ID number 1.
PATH: /chatrooms/1
HTTP Method: PUT
Request body: { "chatRoomID": 2, "chatRoomOwner": 1, "roomName": "test" }
Response body: If succeded the response will be a 1, as the NoContent(); is returned.
Otherwise NotFound or BadRequest.

All chat members that are members of a room can invite other chat users to the
room. First the chat user id that you want to invite and then the chat room id. If you want
to invite chat user with id 1 to room id 2, that’s: 1/2
PATH: /chatrooms/1/2
HTTP Method: POST
Response body: The response will always be a 1, as the NoContent(); is returned.
All chat members can send messages to rooms they are members in.

The path only needs the ID number of the room, for example /1 for the room with ID
number 1. And then a string message as request body.
PATH: /chatrooms/1
HTTP Method: POST
Request body: { "message": "this is my message to the room" }
Response body: The response will always be a 1, as the NoContent(); is returned.

List all chat users in a chat room.
The path only needs the ID number of the room, for example /1 for the room with ID
number 1.
PATH: /chatrooms/1
HTTP Method: GET
Response body: { "chatRoomMembersId": 1, "chatRoomID": 1, "chatUserID": 1 }

If there is no message the response will be empty.
List all messages for a chat room.
The path needs /messages and then the ID number of the room, for example
/messages/1 for the room with ID number 1.
PATH: chatrooms/messages/1
HTTP Method: GET
Response body: { "id": 1, "chatMessagesID": 1, "chatRoomID": 1, "chatMemberID": 1,
"date": "0001-01-01T00:00:00", "message": "This is the only message in this room" }
If there is no message the response will be empty
