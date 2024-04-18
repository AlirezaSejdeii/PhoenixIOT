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
char identifier[] = "test_devide_id_1234";
char serverUrl[] = "http://5.201.152.69:5264";


char val1[] = "val1[]";
char val2[] = "val2[]";
char val3[] = "val3[]";
char val4[] = "val4[]";
char val5[] = "val5[]";
char val6[] = "val6[]";
char val7[] = "val7[]";
char val8[] = "val8[]";
char val9[] = "val9[]";
char val10[] = "val10[]";
char val11[] = "val11[]";
char val12[] = "val12[]";
char val13[] = "val13[]";
char val14[] = "val14[]";
char val15[] = "val15[]";
char val16[] = "val16[]";
char val17[] = "val17[]";
char val18[] = "val18[]";
char val19[] = "val19[]";
char val20[] = "val20[]";

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

    http.begin(client, String(serverUrl) + "/device-manager/update-variables/" + String(identifier));
    http.addHeader("Content-Type", "application/json");

    StaticJsonDocument<22> doc;
    doc["temperature"] = String(temperature);
    doc["humidity"] = String(humidity);
    doc["val1"] = val1;
    doc["val2"] = val2;
    doc["val3"] = val3;
    doc["val4"] = val4;
    doc["val5"] = val5;
    doc["val6"] = val6;
    doc["val7"] = val7;
    doc["val8"] = val8;
    doc["val9"] = val9;
    doc["val10"] = val10;
    doc["val11"] = val11;
    doc["val12"] = val12;
    doc["val13"] = val13;
    doc["val14"] = val14;
    doc["val15"] = val15;
    doc["val16"] = val16;
    doc["val17"] = val17;
    doc["val18"] = val18;
    doc["val19"] = val19;
    doc["val20"] = val20;

    String jsonData;
    serializeJson(doc, jsonData);

    int httpResponseCode = http.POST(jsonData);
    Serial.println("JSON Payload: " + jsonData);
    if (httpResponseCode > 0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
    } else {
      Serial.println("Error sending data to server");
      Serial.println(http.errorToString(httpResponseCode).c_str());
    }

    http.begin(client, String(serverUrl) + "/device-manager/status/" + String(identifier));
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
      http.begin(client, String(serverUrl) + "/device-manager/update-last-sync/" + String(identifier));
      http.PUT("");
    } else {
      Serial.println("Error on HTTP request");
    }
    http.end();
  }
}
