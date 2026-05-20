using Godot;
using System;

public partial class GameController : Node
{
 private CharacterBody2D Player;
 private TileMapLayer Track;

 public override void _Ready(){
    Player = (CharacterBody2D) GetNode("Auto");
    Track = (TileMapLayer) GetNode("Track1/TileMapLayer");
    GD.Print(Track);

 }

}
