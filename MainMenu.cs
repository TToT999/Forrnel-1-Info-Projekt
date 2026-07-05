using Godot;
using System;

public partial class MainMenu : Node2D
{
	void _on_bestenliste_pressed(){
	//	GetTree().ChangeScene("res://bestenliste.tscn");
	}
	void _on_verlassen_pressed(){
		GetTree().Quit();
	}
	void _on_start_pressed(){
	//	 GetTree().change_scene_to_file("res://Drive.tscn");	}
	void _on_einstellungen_pressed(){ 
	//	GetTree().ChangeScene("res://options.tscn");
	}
}
