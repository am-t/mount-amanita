#define INPUT_SIZE 6
#define OUTPUT_SIZE 6
#define MSG_CHARS 3

long timer;
short inputPin[] = {7, 8, 9, 10, 11, 12};
bool pinState[] = {0, 0, 0, 0, 0, 0};
short ledPin[] = {2,3,4};


const byte buffSize = 40;
char inputBuffer[buffSize];
const char startMarker = '<';
const char endMarker = '>';
byte bytesRecvd = 0;
boolean readInProgress = false;
boolean newDataFromPC = false;
short ledCount = 3;

void setup() {
  Serial.begin(9600);
  pinMode(inputPin[0], INPUT_PULLUP);
  pinMode(inputPin[1], INPUT_PULLUP);
  pinMode(inputPin[2], INPUT_PULLUP);
  pinMode(inputPin[3], INPUT_PULLUP);
  pinMode(inputPin[4], INPUT_PULLUP);
  pinMode(inputPin[5], INPUT_PULLUP);
  //digitalWrite(inputPin[0], HIGH); //Enables Pull-up resistor -> HIGH = OFF
  for(ledCount;ledCount>=0;ledCount--){
    pinMode(ledPin[ledCount],OUTPUT);
    digitalWrite(ledPin[ledCount],LOW);
  }
}

void loop() {
  getDataFromPC();
  long now = millis();
  if (now - timer > 600) {
    int sensorN = INPUT_SIZE;
    for (sensorN; sensorN >= 0; sensorN --) {
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

void getDataFromPC() {
  // receive data from PC and save it into inputBuffer
  if (Serial.available() > 0) {
    char x = Serial.read();
    // the order of these IF clauses is significant
    if (x == endMarker) {
      readInProgress = false;
      newDataFromPC = true;
      inputBuffer[bytesRecvd] = 0;
      parseData();
    }
    if (readInProgress) {
      inputBuffer[bytesRecvd] = x;
      bytesRecvd ++;
      if (bytesRecvd == buffSize) {
        bytesRecvd = buffSize - 1;
      }
    }
    if (x == startMarker) {
      bytesRecvd = 0;
      readInProgress = true;
    }
  }
}

void parseData() {
  // split the data into its parts
  char * strtokIndx; // this is used by strtok() as an index
  strtokIndx = strtok(inputBuffer, ",");     // get the first part - the string
  int LEDid = atoi(strtokIndx); // copy it to messageFromPC
  strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  int state = atoi(strtokIndx);     // convert this part to an integer
  digitalWrite(ledPin[LEDid],state);
}
