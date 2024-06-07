//ESP8266 (Cliente)
#include <ESP8266WiFi.h>

const char* ssid = "MERCUSYS";
const char* password = "25876314";

WiFiServer server(80);

void setup() {
  Serial.begin(9600);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {}
  server.begin();
}

void loop() {
  WiFiClient client = server.available();
  
  if (client) {
    Serial.begin(9600);
    String currentLine = "";
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();
        if (c == 'w') { Serial.write('w'); }
        if (c == 's') { Serial.write('s'); }
        if (c == 't') { Serial.write('t'); }
        if (c == 'a') { Serial.write('a'); }
        if (c == 'd') { Serial.write('d'); }
        if (c == 'k') { Serial.write('k'); }
        if (c == 'l') { Serial.write('l'); }
        if (c == 'i') { Serial.write('i'); }
        if (c == 'o') { Serial.write('o'); }
        if (c == 'n') { Serial.write('n'); }
        if (c == 'm') { Serial.write('m'); }
      }
    }
    client.stop();
    Serial.end();
  }
}