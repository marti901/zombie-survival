// https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API/Writing_WebSocket_server
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5123);
server.Start();

Console.WriteLine("Server has started on 127.0.0.1:5123");
Console.WriteLine("Waiting for a connection...");

TcpClient client = server.AcceptTcpClient();


Console.WriteLine("A client connected");

NetworkStream stream = client.GetStream();

while (true)
{
	while (!stream.DataAvailable) ;

	byte[] bytes = new byte[client.Available];

	await stream.ReadAsync(bytes, 0, bytes.Length);

	if(bytes.Length > 3)
	{
		string data = Encoding.UTF8.GetString(bytes);

		// Replace Regex
		if (Regex.IsMatch(data, "^GET"))
		{
			Console.WriteLine("Should do hand shake");

			const string endOfLine = "\r\n"; // HTTP/1.1 defines the sequence CR LF as the end-of-line marker

			byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + endOfLine
				+ "Connection: Upgrade" + endOfLine
				+ "Upgrade: websocket" + endOfLine
				+ "Sec-WebSocket-Accept: " + Convert.ToBase64String(
					System.Security.Cryptography.SHA1.Create().ComputeHash(
						Encoding.UTF8.GetBytes(
							new Regex("Sec-WebSocket-Key: (.*)").Match(data).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
						)
					)
				) + endOfLine
				+ endOfLine);

			await stream.WriteAsync(response, 0, response.Length);
		}
	}
}

