using Godot;
using System;

public partial class Auto1 : CharacterBody2D
{
private Auto_View view;
private Auto_Modell modell;
private float deltatime = 0;

public override void _Ready()
	{
		view = GetNode<Auto_View>("Auto-View");
		modell = GetNode<Auto_Modell>("Auto-Modell");
	}



public override void _PhysicsProcess(double delta){
	float dt = (float) delta;

//Berechnung Reibung und Kurvenfahrt
	modell.BerechnungTurn(Velocity, dt, Rotation);

//Effects
	view.UpdateVisuals(Velocity, modell.maxV);

//Rotation
	float turnInput = 0f;
	if (Input.IsActionPressed("Turn-Right")) turnInput += 1f;
	if (Input.IsActionPressed("Turn-Left")) turnInput -= 1f;
  	Rotation += turnInput * 2.5f *modell.turnFactor* dt;	

//Movement
	float moveInput = 0f;
	if (Input.IsActionPressed("Acceleration")) moveInput = 1.7f;
	if (Input.IsActionPressed("Brake") && Velocity.Length() > 0) { // if geändert (Testen ob noch richtig)
		Velocity = Velocity.Normalized()*(Velocity.Length()-1.7f);
		moveInput = 0;
	}
   	Vector2 forward = Vector2.Up.Rotated(Rotation);

//Friction Braking
	if(!Input.IsActionPressed("Acceleration") && !Input.IsActionPressed("Brake")){
	  Velocity *= 0.999f; 
	  moveInput = 0;
	}
	Vector2 newVel = (Velocity.Length() + moveInput)*forward;
	newVel = newVel.LimitLength(400);
	if(Velocity.Length() <= modell.maxV && modell.drifting == false){
		Velocity = newVel;
	}
	else if (Velocity.Length() > modell.maxV || modell.drifting ){
		Velocity = (float)(1-delta)*Velocity;
		modell.drifting = true;
	}
	if(Velocity.Length()< 30) modell.drifting = false;
	deltatime += dt;
	MoveAndSlide();


	//Debugging Part
	int zähler = 0;
	if(Input.IsActionJustPressed("ui_home")){ 
		GD.Print("Point" + zähler + ":" + GlobalPosition);
		GD.Print("Ausrichtung" + zähler + ":" + Rotation);
		zähler += 1;
	}

}

public void Set_IsOffTrack (bool input){
	modell.isOffTrack = input;
  }
}
