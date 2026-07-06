using Godot;
using System;
using System.Collections.Generic;

public partial class GameController : Node
{
 private Auto1 Player;
 private Area2D PlayerCollision;
 private TileMapLayer Track;
 private Path2D track1path;
 private Curve2D track1;
 private Path2D track2path;
 private Curve2D track2;
 private PackedScene checkpointscene;
 private  List<Track_Checkpoint> checkpoints; 
 private Node2D checkpointnode;
 private int lastcheckpoint = -1;
 private bool currentlyInCheckpoint = false;

 public override void _Ready(){
    Player = GetNode<Auto1>("/root/Game/Auto");
    PlayerCollision = GetNode<Area2D>("/root/Game/Auto/Area2D");
    Track =  GetNode<TileMapLayer>("/root/Game/Tracks/TileMapLayer");
    //GD.Print(Track);
    checkpoints = new List<Track_Checkpoint>();
    track1path = GetNode<Path2D>("/root/Game/Tracks/TileMapLayer/Track_1");
    track1 = track1path.GetCurve();
    checkpointscene = GD.Load<PackedScene>("res://Track_Checkpoint.tscn");
    checkpointnode = GetNode<Node2D>("CheckpointController");
    InstanceCheckpointsTrack1();
 }

   public Vector2 CalcTileMapPos(){ //Methode falsch rum gedacht?
   Vector2 playerGlobal = Player.GlobalPosition;
   Vector2 playerLocalToTilemap = Track.ToGlobal(playerGlobal);
   Vector2I cell = Track.LocalToMap(playerLocalToTilemap);
   //GD.Print("Cell: " + cell);
   return cell;
   }

  

   public void _on_area_2d_body_entered(Node2D body){
      if(body is TileMapLayer) Player.Set_IsOffTrack(false);}
     
   
   public void _on_area_2d_body_exited(Node2D body){
      if(body is TileMapLayer) Player.Set_IsOffTrack(true);}

public override void _PhysicsProcess(double delta){
   CalcTileMapPos();
}

   public void InstanceCheckpointsTrack1()
   {  
      for (int i = 0; i < track1.GetPointCount(); i++)
      {
         Track_Checkpoint neu = checkpointscene.Instantiate<Track_Checkpoint>();
         checkpointnode.AddChild(neu);
         checkpoints.Add(neu);
         Vector2 current = track1.GetPointPosition(i);
         Vector2 next;
         if(i < track1.GetPointCount()-1) next = track1.GetPointPosition(i+1);
         else next = current;
         checkpoints[i].Position = track1.GetPointPosition(i);
         checkpoints[i].Rotation = current.AngleToPoint(next) + 0.5f* ((float) Math.PI);
         checkpoints[i].set_checkpointNumber(i);
      }

   }

   public void set_inCheckpoint(bool b)
   {
      currentlyInCheckpoint = b;
   }

   public void SetTouchedCheckpoint(int i)
   {if(!currentlyInCheckpoint){
      GD.Print(lastcheckpoint + i);
      if((lastcheckpoint +1) == i){
      lastcheckpoint = i;
      GD.Print("No Cut");}
      else {//lastcheckpoint = -5;
      GD.Print("Track Cut");} }
      // Tut noch nix hier bitte dann Connection zu Track Cut und Zeitregistrierung setzen
   }



}
