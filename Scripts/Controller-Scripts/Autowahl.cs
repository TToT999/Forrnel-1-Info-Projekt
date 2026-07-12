using Godot;
using System;

public partial class Autowahl : Node2D
{
	private Sprite2D sprite2D;
	private Node2D Options;

public override void _Ready()
{
	  sprite2D = GetNode<Sprite2D>("Auto-View");
	  Options = GetNode<Node2D>("Options");
}
	
	void _on_zurück_3_pressed(){
		 GetTree().ChangeSceneToFile("res://start.tscn"); 
	}
	void _on_einstellungen_pressed(){
		GetTree().ChangeSceneToFile("res://options.tscn");
		//GetNode<Node2D>("Options").setOrt(3);
	}
	void _on_aston_pressed(){
		
	}
	void _on_kick_pressed(){
		
	}
	void _on_alp_pressed(){
		
	}
	void _on_merc_pressed(){
		
	}
	void _on_haa_pressed(){
		
	}
	void _on_red_bull_light_pressed(){
		
	}
	void _on_will_pressed(){
		
	}
	void _on_ferr_pressed(){
		
	}
	void _on_mc_pressed(){
		
	}
	void _on_red_pressed(){
		
	}
}
