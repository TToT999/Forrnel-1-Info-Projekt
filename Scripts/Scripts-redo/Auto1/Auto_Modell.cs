using Godot;
using System;

public partial class Auto_Modell : Node
{
	public float kurvenradius {get;set;} = 99999f;
    public float reibung { get; set; } = 2.0f;
    public float turnFactor { get; private set; }
    public double maxV { get; private set; } = 9999;
    public bool isOffTrack { get; set; } = false;
	public bool drifting {get; set;} = false;
	public float currentRotation {private get; set;} = 0;
	
	public void BerechnungTurn(Vector2 Velocity, float dt, float Rotation){
	if(Velocity.Length() > 200){
		turnFactor = (float) (1-(0.0005* Velocity.Length())); 
		}
	else if(Velocity.Length() < 1 ) turnFactor = 0;
	else turnFactor = 1;

	if(isOffTrack) reibung = 1.5f;
  	else reibung = 2.0f;
	float drotation = Mathf.AngleDifference(Rotation, currentRotation);
	if (Velocity.Length() > 0 && Math.Abs(drotation) > 0.001f){
		kurvenradius = Math.Abs(Velocity.Length() / (drotation / dt));
	}
	else kurvenradius = 9999f;
	maxV = 6* Math.Sqrt(kurvenradius * 10f * reibung);
	currentRotation = Rotation;}

	public void Set_IsOffTrack (bool input){
	isOffTrack = input;
  }
}
