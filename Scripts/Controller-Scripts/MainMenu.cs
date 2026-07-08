using Godot;
using System;

public partial class MainMenu : Node2D
{

	public override void _Ready()
	{
		
	}
	void _on_bestenliste_pressed(){
		GetTree().ChangeSceneToFile("res://bestenliste.tscn");
	}
	void _on_verlassen_pressed(){
		GetTree().Quit();
	}
	void _on_start_pressed(){
		 GetTree().ChangeSceneToFile("res://Drive.tscn"); 
		}
	void _on_einstellungen_pressed(){ 
		GetTree().ChangeSceneToFile("res://options.tscn");
	}
}
