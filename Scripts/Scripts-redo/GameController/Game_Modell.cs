using Godot;
using System;

public partial class Game_Modell : Node
{

 private Area2D PlayerCollision;
 private TileMapLayer Track;

 private int lastcheckpoint = -1;
 private Custom_List list;

public void SetTouchedCheckpoint(int i, Curve2D track){
   if((lastcheckpoint +1) == i ||(lastcheckpoint == (track.GetPointCount()-2) && i == 0) || lastcheckpoint == -1){
      lastcheckpoint = i;
      GD.Print("No Cut");
   }
   else {lastcheckpoint = i;
      GD.Print("Track Cut");
   } 
}
      // Tut noch nix hier bitte dann Connection zu Track Cut und Zeitregistrierung setzen
   
}
