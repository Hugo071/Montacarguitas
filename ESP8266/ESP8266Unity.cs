// ESP8266 Unity (Server)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class Chat : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    public string ipAddress = "192.168.0.100"; // IP del ESP8266
    public int port = 80;

    void Start()
    {
        ConnectToESP8266();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SendMessageToESP("s");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            SendMessageToESP("t");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SendMessageToESP("w");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            SendMessageToESP("t");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendMessageToESP("a");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            SendMessageToESP("t");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SendMessageToESP("d");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            SendMessageToESP("t");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SendMessageToESP("k");
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            SendMessageToESP("m");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SendMessageToESP("l");
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            SendMessageToESP("m");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SendMessageToESP("i");
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            SendMessageToESP("n");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SendMessageToESP("o");
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            SendMessageToESP("n");
        }
    }

    void ConnectToESP8266()
    {
        try
        {
            client = new TcpClient(ipAddress, port);
            stream = client.GetStream();
            Debug.Log("Conectado al ESP8266");
        }
        catch (SocketException e)
        {
            Debug.Log("No se pudo conectar al ESP8266: " + e.Message);
        }
    }

    void SendMessageToESP(string message)
    {
        if (stream != null)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Debug.Log("Mensaje enviado: " + message);
        }
    }

    void OnApplicationQuit()
    {
        SendMessageToESP("t");
        SendMessageToESP("n");
        SendMessageToESP("m");
        if (stream != null)
        {
            stream.Close();
        }
        if (client != null)
        {
            client.Close();
        }
    }
}
