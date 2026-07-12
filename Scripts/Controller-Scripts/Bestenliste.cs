using Godot;
using System;

public partial class Bestenliste : Node2D
{
	void _on_zurück_5_pressed(){
		GetTree().ChangeSceneToFile("res://main_menu.tscn");
	}
}
