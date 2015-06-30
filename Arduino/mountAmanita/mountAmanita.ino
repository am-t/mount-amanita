#define INPUT_SIZE 6
#define OUTPUT_SIZE 6

long timer;
short inputPin[] = {7, 8, 9, 10, 11, 12};
bool pinState[] = {0, 0, 0, 0, 0, 0};

void setup() {
  Serial.begin(9600);
  pinMode(inputPin[0], INPUT_PULLUP);
  pinMode(inputPin[1], INPUT_PULLUP);
  pinMode(inputPin[2], INPUT_PULLUP);
  pinMode(inputPin[3], INPUT_PULLUP);
  pinMode(inputPin[4], INPUT_PULLUP);
  pinMode(inputPin[5], INPUT_PULLUP);
  //digitalWrite(inputPin[0], HIGH); //Enables Pull-up resistor -> HIGH = OFF
}

void loop() {
  // send a message every 100 ms
  // avoid using delay() since it just blocks everything
  long now = millis();
  if (now - timer > 600) {
    int sensorN = INPUT_SIZE;
    for (sensorN; sensorN >= 0; sensorN --){
      if (digitalRead(inputPin[sensorN]) != pinState[sensorN]) {
        pinState[sensorN] = digitalRead(inputPin[sensorN]);
        Serial.print("arduino ");
        Serial.print(sensorN);
        Serial.print(" ");
        Serial.println(!pinState[sensorN]);
      }
    }
  }
}
