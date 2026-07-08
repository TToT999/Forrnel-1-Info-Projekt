using Godot;
using System;

public partial class Trackwahl : Node2D
{
	public double Tracknummer = 1; 
	void _on_einstellungen_pressed(){
		GetTree().ChangeSceneToFile("res://options.tscn");
	}
	void _on_track_1_pressed(){
		Tracknummer = 1; 
	}
	void _on_track_2_pressed(){
		Tracknummer = 2;
	}
	void _on_zurück_2_pressed(){
		 GetTree().ChangeSceneToFile("res://start.tscn"); 
	}
}
