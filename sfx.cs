using Godot;
using System;

public partial class sfx : HSlider
{
	// Called when the node enters the scene tree for the first time.
	
	[Export]
	public String busName;
	public int busIndex;

	public override void _Ready()
	{
		busIndex = AudioServer.GetBusIndex(busName);
		//ValueChanged.connect
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
