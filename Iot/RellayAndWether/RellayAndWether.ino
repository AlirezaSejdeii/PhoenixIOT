#include <DHT.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <ArduinoJson.h>

#define DHTPIN D4
const int relay_pin1 = 5;
const int relay_pin2 = 4;
const int relay_pin3 = 12;
const int relay_pin4 = 14;
#define DHTTYPE DHT11

// char ssid[] = "Mr.Me";
// char pass[] = "123456789";

char ssid[] = "Mr.Me";
char pass[] = "123456789";


DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(115200);
  pinMode(relay_pin1, OUTPUT);
  pinMode(relay_pin2, OUTPUT);
  pinMode(relay_pin3, OUTPUT);
  pinMode(relay_pin4, OUTPUT);

  digitalWrite(relay_pin1, HIGH);
  digitalWrite(relay_pin2, HIGH);
  digitalWrite(relay_pin3, HIGH);
  digitalWrite(relay_pin4, HIGH);

  WiFi.begin(ssid, pass);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.println("Retring to connect to the WiFi");
  }
  Serial.println("WiFi connected");

  dht.begin();
}

void loop() {
  delay(2000);
  float humidity = dht.readHumidity();
  float temperature = dht.readTemperature();

  if (isnan(humidity) || isnan(temperature)) {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }

  // Print the values to the Serial Monitor
  Serial.print("Humidity: ");
  Serial.print(humidity);
  Serial.print("%  Temperature: ");
  Serial.print(temperature);
  Serial.println("°C ");

  if (WiFi.status() == WL_CONNECTED) {
    WiFiClient client;  // Create a WiFiClient object
    HTTPClient http;

    http.begin(client, "http://5.201.152.69:7111/manager-device");
    http.addHeader("Content-Type", "application/json");
    String jsonData = "{\"temperature\": " + String(temperature) + ",\"humidity\": " + String(humidity) + "}";

    int httpResponseCode = http.POST(jsonData);
    Serial.println("JSON Payload: " + jsonData);
    if (httpResponseCode > 0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
    } else {
      Serial.println("Error sending data to server");
      Serial.println(http.errorToString(httpResponseCode).c_str());
    }

    int httpCode = http.GET();  // Make the HTTP GET request

    if (httpCode > 0) {                   // Check for the returning code
      String payload = http.getString();  // Get the request response payload
      Serial.println(payload);            // Print the response payload

      DynamicJsonDocument doc(1024);  // Create a JSON document object
      deserializeJson(doc, payload);  // Parse the JSON response payload into the JSON document

      digitalWrite(relay_pin1, doc["pin1"] ? LOW : HIGH);
      digitalWrite(relay_pin2, doc["pin2"] ? LOW : HIGH);
      digitalWrite(relay_pin3, doc["pin3"] ? LOW : HIGH);
      digitalWrite(relay_pin4, doc["pin4"] ? LOW : HIGH);
    } else {
      Serial.println("Error on HTTP request");
    }
    http.end();
  }
}
