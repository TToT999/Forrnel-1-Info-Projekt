using Godot;
using System;

public partial class Auto : CharacterBody2D
{

private bool isOffTrack = false;
private float currentRotation;
private float kurvenradius = 0;
private float reibung = 2.0f; //Wert anpassen je nach Fahrzeug Todo
private double maxv = 100;
Vector2 forward;

public override void _PhysicsProcess(double delta) {
  if(isOffTrack) reibung = 1f;
  else reibung = 2.0f;
//Berechnung Reibung und Kurvenfahrt
float drotation = Rotation - currentRotation;
if(Velocity.Length() > 0) kurvenradius = Math.Abs(drotation*Velocity.Length());
//GD.Print(kurvenradius);
maxv = 14*Math.Sqrt(kurvenradius*10f*reibung);
//if(maxv>0)GD.Print(maxv);
 currentRotation = Rotation;
GD.Print("hallihallo");
//Movement W/S und Rotation
  float dt = (float)delta;
  float turnInput = 0f;
    if (Input.IsActionPressed("Turn-Right")) turnInput += 1f;
    if (Input.IsActionPressed("Turn-Left")) turnInput -= 1f;
  Rotation += turnInput * 2.5f * dt;

  float moveInput = 0f;
    if (Input.IsActionPressed("Acceleration")) moveInput = 1.7f;
    if (Input.IsActionPressed("Brake")) moveInput = -1.7f;
   forward = Vector2.Up.Rotated(Rotation);
   
   if(Velocity.Length() > maxv){
      Velocity = BerechnungDrift(delta, true);
      //GD.Print(Velocity.Length());
       }else{ 
        Velocity = Velocity.Length()*forward;}
    if(!Input.IsActionPressed("Acceleration") && !Input.IsActionPressed("Brake")){
      Velocity *= 1f - (0.1f * dt); }
    float neuGeschwindigkeit = Velocity.Length()+moveInput;
    neuGeschwindigkeit = Mathf.Clamp(neuGeschwindigkeit, 0f, 200f);
    if (Velocity.Length() > 0)
        { Velocity = Velocity.Normalized() * neuGeschwindigkeit;}
      else if (moveInput > 0) 
       { Velocity = forward * moveInput;}
       if(Velocity.Length() > maxv){
      Velocity = BerechnungDrift(delta, true);
      //GD.Print(Velocity.Length());
       }else{ 
        Velocity = Velocity.Length()*forward;}
     MoveAndSlide();
    
//Ende Movement

  }

  public void Set_IsOffTrack (bool input){
    isOffTrack = input;
  }
// Idee: Mit Clamp maximale Drehung schrittweise Vector anpassen
  public Vector2 BerechnungDrift(double delta, bool drifting){
    float minradius = (Velocity.Length()*Velocity.Length())/(reibung*10f);
    float deltaomega = Velocity.Length()/minradius;
    float maxTurn = deltaomega * (float) delta;
    Vector2 velocity = new Vector2(1,1);
double angleTo = Velocity.AngleTo(forward);
float turn = (float) Mathf.Clamp(angleTo, -maxTurn, maxTurn);
GD.Print(turn);
float c = MathF.Cos(turn);
float s = MathF.Sin(turn);
    velocity = new Vector2(
    Velocity.X * c - Velocity.Y * s,
    Velocity.X * s + Velocity.Y * c);
    return velocity;

  }

}