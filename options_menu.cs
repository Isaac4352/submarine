using Godot;
using System;

public partial class options_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void _on_back_pressed()
	{
		GetTree().ChangeSceneToFile("menu.tscn");
	}
}
