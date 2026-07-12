using Godot;
using System;
using System.Reflection.PortableExecutable;

public partial class GameController : Node
{
	private Auto1 Player;
	private Game_Modell modell;
	private Game_View view;
	private Path2D track1path;
	private Path2D track2path;
	public override void _Ready()
	{
		modell = GetNode<Game_Modell>("Game_Modell");
		view = GetNode<Game_View>("Game_View");
		track1path = GetNode<Path2D>("/root/Game/Tracks/TileMapLayer/Track_1");
		track2path = GetNode<Path2D>("/root/Game/Tracks/TileMapLayer/Track_2");
		Player = GetNode<Auto1>("/root/Game/Auto");
		view.InstanceCheckpointsTrack(track1path);
		view.InstanceCheckpointsTrack(track2path);
	}

	public void SetTouchedCheckpoint(int i, Path2D track)
	{
		modell.SetTouchedCheckpoint(i,track.GetCurve());
	}

}
