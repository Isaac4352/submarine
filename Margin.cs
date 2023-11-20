using Godot;
using System;

public partial class Margin : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = GetViewportRect().Size/2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
