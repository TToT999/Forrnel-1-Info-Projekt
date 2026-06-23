using Godot;
using System;

public partial class Auto_View : Sprite2D
{
	private Camera2D cam;
	private CharacterBody2D auto;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cam = this.GetChild<Camera2D>(0);
		auto = GetNode<CharacterBody2D>("/root/Game/Auto");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Position = auto.GlobalPosition;
		this.Rotation = auto.GlobalRotation;

		
	}
}
