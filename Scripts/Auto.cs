using Godot;
using System;

public partial class Auto : CharacterBody2D
{




public override void _PhysicsProcess(double delta) {

    float dt = (float)delta;
    // 1) Rotation aus A/D
    float turnInput = 0f;
    if (Input.IsActionPressed("Turn-Right")) turnInput += 1f;
    if (Input.IsActionPressed("Turn-Left")) turnInput -= 1f;
    Rotation += turnInput * 2.5f * dt;
    // 2) Vor/Zurück aus W/S
    float moveInput = 0f;
    float MaxSpeed = 100f;
    if (Input.IsActionPressed("Acceleration")) moveInput += 2.5f;
    if (Input.IsActionPressed("Brake")) moveInput -= 2.5f;
    // 3) Vorwärtsvektor relativ zur Drehung
    Vector2 forward = Vector2.Up.Rotated(Rotation);
    // 4) Geschwindigkeit setzen und bewegen
   
    GD.Print(Velocity.Length());
    if(Velocity.Length() <100){
    Velocity = forward*(moveInput + Velocity.Length());}
    else if (Velocity.Length() >= 100) {Velocity = Velocity.Length()*forward;}
   
    if(!Input.IsActionPressed("Acceleration") && !Input.IsActionPressed("Brake")){
    Velocity *= 1f - (0.98f * dt); }

     MoveAndSlide();
  }

}