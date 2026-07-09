using Godot;
using System;

public partial class Custom_List : Node
{
	// Das hier ist eine Verkette Liste (Linked List), Rest der Methoden in res://Scripts/Model-Scripts/Track_Checkpoint
	private Track_Checkpoint initial;
	public override void _Ready()
	{
	}

	public void set_Initial(Track_Checkpoint c)
	{
		initial = c;
	}

	public Track_Checkpoint get_Object(int i) // i hier als index nicht Nummer also i = 5 => Object 6 aufgerufen
	{ Track_Checkpoint current;
	current = initial;
		for (int b = 0; b < i; b++)
		{if(!(current.get_Next() == null)){
			current = current.get_Next();
			//GD.Print(current.get_CheckpointNumber());
		}else GD.Print("Index out of Range");
		}
		return current;
	}

}
