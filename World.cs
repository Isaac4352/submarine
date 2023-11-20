using Godot;
using System;

public partial class World : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private AudioStreamPlayer ambiance;
	public override void _Ready()
	{
		ambiance = GetNode<AudioStreamPlayer>("AudioStreamPlayer2D");
		GD.Print("readyTest");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//ambiance.Play();
		//GD.Print("test");
	}
}
