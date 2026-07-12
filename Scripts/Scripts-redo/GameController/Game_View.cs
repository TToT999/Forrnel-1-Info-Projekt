using Godot;
using System;

public partial class Game_View : Node
{
	private Custom_List list;
	private PackedScene checkpointscene;
 	private Node2D checkpointnode;

	public override void _Ready()
	{	
		list = GetParent().GetNode<Custom_List>("Custom_List");
		checkpointscene = GD.Load<PackedScene>("res://Track_Checkpoint.tscn");
		checkpointnode = GetParent().GetNode<Node2D>("CheckpointController");
	}
	public async void InstanceCheckpointsTrack(Path2D trackPath) {
		Curve2D track = trackPath.GetCurve();
   for (int i = 0; i < track.GetPointCount()-1; i++){
	  Track_Checkpoint neu = checkpointscene.Instantiate<Track_Checkpoint>();
	  trackPath.AddChild(neu);
	  await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
	  neu.Position = track.GetPointPosition(i);
	  Vector2 current = track.GetPointPosition(i); //Berechnung Angle zum nächsten Punkt für Rotationsberechnung
	  Vector2 next;
	  if(i < track.GetPointCount()-1) next = track.GetPointPosition(i+1);
	  else next = current;
	  if(i==0){list.set_Initial(neu);}
	  else{list.get_Object(i-1).set_Next(neu);}
	  list.get_Object(i).Rotation = current.AngleToPoint(next) + 0.5f* ((float) Math.PI);
	  list.get_Object(i).set_checkpointNumber(i);   
   }
}
}
