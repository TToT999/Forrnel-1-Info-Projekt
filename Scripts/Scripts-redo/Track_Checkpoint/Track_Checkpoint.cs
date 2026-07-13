using Godot;
using System;

public partial class Track_Checkpoint : Node2D
{
	
	
	private GameController controller;
	private CheckpointModell modell;
	private CheckpointView view;


	public override void _Ready()
	{
		modell = GetNode<CheckpointModell>("Checkpoint_Modell");
		view = GetNode<CheckpointView>("Checkpoint_View");
		controller = GetNode<GameController>("/root/Game/CONTROLLER");
		view.Visible = true;
	}
	
	public void set_checkpointNumber (int i)
	{
		modell.checkpointNumber = i;
		GD.Print(i);
	}

	public void set_IsFinish(){modell.isFinishLine = true;}

	public int get_CheckpointNumber(){return modell.checkpointNumber;}

	public void set_Next(Track_Checkpoint c)
	{
		modell.next = c;
	}

	public Track_Checkpoint get_Next() {return modell.next;}

	public void SetTouchedCheckpoint(int i)
	{
		controller.SetTouchedCheckpoint(i, this.GetParent<Path2D>());
		GD.Print(i);
	}
}
