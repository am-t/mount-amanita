#define INPUT_SIZE 6
#define UV_SIZE 3
#define BONFIRE_SIZE 3
#define MSG_CHARS 3

long timer;
short inputPin[] = {8, 9, 10, 11, 12, 13};
bool pinState[] = {1,1,1,1,1,1};
short uvPin[] = {2,4,7};
short firePin[] = {3,5,6};
bool fireLit = false;



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
    pinMode(uvPin[ledCount],OUTPUT);
    digitalWrite(uvPin[ledCount],LOW);
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
  if(fireLit){
    bonFire();
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
  if(LEDid < UV_SIZE){
    digitalWrite(uvPin[LEDid],state);
  }else{
    if(state == 1){fireLit = true;}
    else if(state == 0){
      fireLit = false;
      for(int i = 0; i < BONFIRE_SIZE; i++){
        analogWrite(firePin[i], 0);
      }
    }
  }
  
}

void bonFire(){
  for(int i = 0; i < BONFIRE_SIZE; i++){
    analogWrite(firePin[i], random(120)+50);
  }  
}
