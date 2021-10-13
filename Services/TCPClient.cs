using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Matriks.ApiClient.TcpConnection;

public class TcpClient
{
	#region private members 	
	private System.Net.Sockets.TcpClient _socketConnection;
    public bool Connected;

    public event EventHandler<bool> OnConnected;
    public event EventHandler<OnDataInEventArgs> OnDataIn;
    public event EventHandler<bool> OnDisconnected;
    public event EventHandler<bool> OnConnectionStatus;
    public event EventHandler<bool> OnReadyToSend;

	#endregion
	// Use this for initialization 	
	public void Start(string ip, int port)
	{
		ConnectToTcpServer(ip,port);
	}

	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer(string ip, int port)
	{
		try
        {
            ListenForData(ip, port);
        }
		catch (Exception e)
		{

		}
	}
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData(string ip, int port)
	{
		try
		{
			_socketConnection = new System.Net.Sockets.TcpClient(ip, port);
			Byte[] bytes = new Byte[30000000];
			while (true)
			{
				// Get a stream object for reading 				
				using (NetworkStream stream = _socketConnection.GetStream())
                {
					Connected = true;
                    OnConnected(this, true);
					int length;
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
					{
						var incommingData = new byte[length];
						Array.Copy(bytes, 0, incommingData, 0, length);
                        if (OnDataIn != null)
                        {
                            // Convert byte array to string message. 		
                            Encoding encoding = Encoding.GetEncoding("UTF-8");
                            var str1 = encoding.GetString(incommingData);
							OnDataIn(this, new OnDataInEventArgs(incommingData, str1));
                        }
						
						//string serverMessage = Encoding.Default.GetString(incommingData);
						//Console.WriteLine("server message received as: " + serverMessage);

					}
				}
			}
		}
		catch (SocketException socketException)
        {
            Connected = false;
			Console.WriteLine("Socket exception: " + socketException);
		}
	}

	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	public void SendMessage(object jsonToSend)
	{
		if (_socketConnection == null)
		{
			return;
		}
		try
        {
            if (!_socketConnection.Connected)
            {
                this.Connected = _socketConnection.Connected;
                return;
			}
			// Get a stream object for writing. 			
			NetworkStream stream = _socketConnection.GetStream();
			if (stream.CanWrite)
			{
				// Convert string message to byte array.                 
                byte[] clientMessageAsByteArray =null;
                if(jsonToSend is string)
                    clientMessageAsByteArray = Encoding.UTF8.GetBytes(jsonToSend as string);
				else if (jsonToSend is byte[] bytes)
                    clientMessageAsByteArray = bytes;
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
			}
		}
		catch (SocketException socketException)
		{
            Console.WriteLine("Socket exception: " + socketException);
		}
	}

	//public void SendMessageBytes(byte[] bytesToSend)
	//{
	//	if (socketConnection == null)
	//	{
	//		return;
	//	}
	//	try
	//	{
	//		// Get a stream object for writing. 			
	//		NetworkStream stream = socketConnection.GetStream();
	//		if (stream.CanWrite)
	//		{
	//			// Convert string message to byte array.                 
	//			// Write byte array to socketConnection stream.                 
	//			stream.Write(bytesToSend, 0, bytesToSend.Length);
	//		}
	//	}
	//	catch (SocketException socketException)
	//	{
	//		Console.WriteLine("Socket exception: " + socketException);
	//	}
	//}

    
}