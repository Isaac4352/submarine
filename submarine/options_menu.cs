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

	void _on_check_box_toggled(bool button_pressed)
	{
		var master_sound = AudioServer.GetBusIndex("Master");
		var background_sound = AudioServer.GetBusIndex("background");
		var sfx_sound = AudioServer.GetBusIndex("sfx");
		if(button_pressed)
		{
			AudioServer.SetBusMute(master_sound,true);
			AudioServer.SetBusMute(background_sound,true);
			AudioServer.SetBusMute(sfx_sound,true);
		}
		else
		{
			AudioServer.SetBusMute(master_sound,false);
			AudioServer.SetBusMute(background_sound,false);
			AudioServer.SetBusMute(sfx_sound,false);
		}
	}
}
