using Godot;
using System;


public partial class Track_Checkpoint : Node2D
{
	private bool isFinishLine = false;
	private int checkpointNumber;
	private GameController controller;
	private Track_Checkpoint next;
	
	public override void _Ready()
	{
		controller = GetParent().GetParent<GameController>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void on_area_entered(Node2D body){
	 	controller.SetTouchedCheckpoint(checkpointNumber);
	}
	public void on_area_exited(Node2D body){
		
		
	}
	public void set_checkpointNumber (int i)
	{
		checkpointNumber = i;
	}

	public int get_CheckpointNumber(){return checkpointNumber;}

	public void set_Next(Track_Checkpoint c)
	{
		next = c;
	}

	public Track_Checkpoint get_Next() {return next;}

}
