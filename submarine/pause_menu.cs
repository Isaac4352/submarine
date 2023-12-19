using Godot;
using System;

namespace submarine_game
{
	public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetProcess(true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CharacterBody2D submarine = GetTree().Root.GetChild<Node2D>(0).GetChild<TileMap>(0).GetChild<CharacterBody2D>(0);
		Position = submarine.Position;
		//GD.Print(submarine.GetPath());
		if(Input.IsActionJustPressed("pause"))
		{
			if(GetTree().Paused == true)
			{
				unpause();
				GD.Print("unpaused");
			}
			else
			{
				pause();
				GD.Print("paused");
			}
		}
	}

	void pause()
	{
		GetTree().Paused = true;
		this.Show();
	}

	void unpause()
	{
		GetTree().Paused = false;
		this.Hide();
	}

	void _on_button_pressed()
	{
		unpause();
	}
}

}
