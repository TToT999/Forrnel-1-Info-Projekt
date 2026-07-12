using Godot;
using System;

public partial class Options : Node2D
{
	public int Ort = 0;
	
	public void setOrt(int a){
		Ort = a;
	}
	void _on_zurück_4_pressed(){
		GetTree().ChangeSceneToFile("res://main_menu.tscn");
	}
}
