const path = require('path')
const express = require('express')
const webSocket = require('ws');
const app = express();

const WS_PORT = 8888;
const HTTP_PORT=8000;

const wsServer = new webSocket.Server({port: WS_PORT}, ()=>console.log(`WS server esta escuchando en ${WS_PORT}`));

let connectedClients=[];
wsServer.on('connection', (ws, req)=>{
    console.log('Conectado');
    connectedClients.push(ws);

    ws.on('message', data=>{
        connectedClients.forEach((ws, i)=>{
            if(connectedClients[i]==ws && ws.readyState === ws.OPEN){
                ws.send(data);
            }else{
                connectedClients.splice(i,1);
            }
        })
    })
});

app.get('/client', (req, res)=>res.sendFile(path.resolve(__dirname, './client.html')));
app.listen(HTTP_PORT, ()=> console.log(`HTTP server escuchando en ${HTTP_PORT} `)); 