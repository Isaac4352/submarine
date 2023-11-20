using Godot;
using System;

public partial class menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	void _on_start_pressed()
	{
		GetTree().ChangeSceneToFile("World.tscn");
	}

	void _on_options_pressed()
	{
		GetTree().ChangeSceneToFile("options_menu.tscn");
	}
}
