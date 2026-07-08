using Godot;
using System;

public partial class Start : Node2D
{
	void _on_start_2_pressed(){
		GetTree().ChangeSceneToFile("res://Drive.tscn");
	}
	void _on_einstellungen_pressed(){
		GetTree().ChangeSceneToFile("res://options.tscn");
	}
	void _on_zurück_pressed(){
		GetTree().ChangeSceneToFile("res://main_menu.tscn");
	}
	void _on_auto_pressed(){
		//GetTree().ChangeSceneToFile();
	}
	void _on_track_pressed(){
		GetTree().ChangeSceneToFile("res://trackwahl.tscn");
	}
}
