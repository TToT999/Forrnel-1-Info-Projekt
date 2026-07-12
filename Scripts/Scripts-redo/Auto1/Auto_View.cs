using Godot;
using System;

public partial class Auto_View : Node
{
	private Node2D effects;

	public override void _Ready()
	{
		effects = GetNode<Node2D>("Effects");
	}

    public void UpdateVisuals(Vector2 velocity, double maxV) 
    {
        effects.Visible = velocity.Length() >= maxV * 0.9;
    }
	}
