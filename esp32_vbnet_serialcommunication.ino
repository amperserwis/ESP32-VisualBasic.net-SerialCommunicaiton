
#define potentio 34
#define led1 26
#define led2 27
#define led3 25


int sensorvalue;

void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600);
    pinMode(led1, OUTPUT);
    pinMode(led2, OUTPUT);
    pinMode(led3, OUTPUT);
    pinMode(potentio, INPUT); 
}

void loop() {
  // put your main code here, to run repeatedly:
    String request = Serial.readStringUntil ('\r');
    sensorvalue = analogRead(potentio);
    
    Serial.print(sensorvalue);
    Serial.print(",");
    Serial.print("Led 1 = ");
    Serial.print(digitalRead(led1));
    Serial.print(" ");
    Serial.print("Led 2 = ");
    Serial.println(digitalRead(led2));
 
    
    if (request.indexOf("Led 1") != -1){
    digitalWrite(led1, !digitalRead(led1));
    
    }
    if (request.indexOf("Led 2") != -1){
    digitalWrite(led2, !digitalRead(led2));
      
    }
    
}
