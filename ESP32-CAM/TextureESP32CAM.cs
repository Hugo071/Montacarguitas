using System;
using System.Collections;
using System.Collections.Generic;
using NativeWebSocket;
using UnityEngine;

public class TextureESP32CAM : MonoBehaviour
{
    private WebSocket _webSocket;
    // Start is called before the first frame update
    async void Start()
    {
        _webSocket = new WebSocket("ws://192.168.0.105:8888");
        _webSocket.OnOpen += () =>
        {
            Debug.Log("Conexion abierta");
        };
        _webSocket.OnError += (e) =>
        {
            Debug.Log("Error"+e);
        };
        _webSocket.OnClose += (e) =>
        {
            Debug.Log("Conexion cerrada");
        };
        _webSocket.OnMessage += (bytes) =>
        {
            //Debug.Log("Tamaño del mensaje:" + bytes.Length );
            if (bytes.Length > 0)
            {
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(bytes);
                if (GetComponent<Renderer>() != null)
                {
                    GetComponent<Renderer>().material.mainTexture = tex;
                }
            }
        };
        await _webSocket.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        _webSocket.DispatchMessageQueue();
    }

    private async void OnApplicationQuit()
    {
        await _webSocket.Close();
    }
}
