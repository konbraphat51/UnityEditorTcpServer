using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace EditorTcpServer
{
    public abstract class EditorTcpServer : EditorWindow, IEditorWindow
    {
        public bool isRunning { get; protected set; }
        private TcpListener tcpListener;

        public void StartServer(int port)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                isRunning = true;
                Debug.Log($"TCP Server started on port {port}");
                ListenForClients();
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to start TCP Server: {e.Message}");
            }
        }

        public void StopServer()
        {
            if (isRunning)
            {
                tcpListener.Stop();
                isRunning = false;
                Debug.Log("TCP Server stopped");
            }
        }

        private async void ListenForClients()
        {
            while (isRunning)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                HandleClient(client);
            }
        }

        private async void HandleClient(TcpClient client)
        {
            Debug.Log("Client connected");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Debug.Log($"Received: {request}");

                    string response = await ProcessRequest(request);
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    Debug.Log($"Sent: {response}");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error handling client: {e.Message}");
            }
            finally
            {
                client.Close();
                Debug.Log("Client disconnected");
            }
        }

        public abstract Task<string> ProcessRequest(string request);
    }
}
