// Motores Sistema de transmisión (Relay ) - Actuadores (Puente H)

#define motorR8 8
#define motorR9 9
#define motorL10 10
#define motorL11 11

int in3 = 4;
int in4 = 5;
int in2 = 6;
int in1 = 7;

void setup() {
  Serial.begin(9600);

  pinMode(motorR8, OUTPUT);
  pinMode(motorR9, OUTPUT);
  pinMode(motorL10, OUTPUT);
  pinMode(motorL11, OUTPUT);

  pinMode(in3, OUTPUT);
  pinMode(in4, OUTPUT);
  pinMode(in2, OUTPUT);
  pinMode(in1, OUTPUT);
}

void loop() {
  if (Serial.available() > 0) {
    char command = Serial.read();
    
    if (command == 'w') {
      digitalWrite(motorR8, HIGH);
      digitalWrite(motorR9, LOW);
      digitalWrite(motorL10, LOW);
      digitalWrite(motorL11, HIGH);
    } 
    else if (command == 's') {
      digitalWrite(motorR8, LOW);
      digitalWrite(motorR9, HIGH);
      digitalWrite(motorL10, HIGH);
      digitalWrite(motorL11, LOW);
    }

    if (command == 't') {
      digitalWrite(motorR8, LOW);
      digitalWrite(motorR9, LOW);
      digitalWrite(motorL10, LOW);
      digitalWrite(motorL11, LOW);
    } 

    if (command == 'd') {
      digitalWrite(motorR8, LOW);
      digitalWrite(motorR9, HIGH);
      digitalWrite(motorL10, LOW);
      digitalWrite(motorL11, HIGH);
    } 
    else if (command == 'a') {
      digitalWrite(motorR8, HIGH);
      digitalWrite(motorR9, LOW);
      digitalWrite(motorL10, HIGH);
      digitalWrite(motorL11, LOW);
    }

    if (command == 'k') {
      digitalWrite(in1, LOW);
      digitalWrite(in2, HIGH);
    }
    if (command == 'l') {
      digitalWrite(in1, HIGH);
      digitalWrite(in2, LOW);
    }
    if (command == 'm') {
      digitalWrite(in1, LOW);
      digitalWrite(in2, LOW);
    }
    
     if (command == 'i') {
      digitalWrite(in3, HIGH);
      digitalWrite(in4, LOW);
    }
    if (command == 'o') {
      digitalWrite(in3, LOW);
      digitalWrite(in4, HIGH);
    }
    if (command == 'n') {
      digitalWrite(in3, LOW);
      digitalWrite(in4, LOW);
    }
  }
}
