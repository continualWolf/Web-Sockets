# WebSocket POC (Proof of Concept) in C#

This project is a minimalistic WebSocket proof of concept in C#. It demonstrates how to create a basic WebSocket server using the .NET framework.

#Usage

To use this WebSocket server, follow these steps:

Create an instance of the Server class, providing an IP address and a port number.

`Server server = new Server("127.0.0.1", 8080);`

Start the WebSocket server by calling the StartListening method.

`server.StartListening();`

The server will start listening on the specified IP address and port.

Connect WebSocket clients to the server, and it will print received messages to the console.
