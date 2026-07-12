using Godot;
using System;

public partial class CheckpointModell : Area2D
{
	public bool isFinishLine {get;set;} = false;
	public int checkpointNumber {get; set;}
	public Track_Checkpoint next {get; set;}

	public void on_area_entered(Node2D body){
	 	GetParent<Track_Checkpoint>().SetTouchedCheckpoint(checkpointNumber);
	}
	public int get_CheckpointNumber() {return checkpointNumber;}
}
