using Godot;
using System;

public partial class Global : Node
{
	public int Tracknummer = 1;
	public void SetTracknummer(int i){
		Tracknummer=i;
	}
	public int GetTracknummer(){
		return Tracknummer;
	}
	
}
