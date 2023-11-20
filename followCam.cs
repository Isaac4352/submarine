using Godot;
using System;

public partial class followCam : Camera2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var tileMap =  GetTree().Root.GetNode("Map").GetNode<TileMap>("TileMap");
		var mapRect = tileMap.GetUsedRect();
		var tileSize = tileMap.CellQuadrantSize;
		var worldSizePx = mapRect.Size * tileSize;
		//LimitRight = worldSizePx.X;
		//LimitBottom = worldSizePx.Y;
		GD.Print(worldSizePx);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
