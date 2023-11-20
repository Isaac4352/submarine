using Godot;
using System;

public partial class Volume : HSlider
{
	// Called when the node enters the scene tree for the first time.

	[ExportCategory("Extra Category")]
	[Export]
	public string busName;
	public int busIndex;
	public override void _Ready()
	{
		busIndex = AudioServer.GetBusIndex(busName);
		//_ValueChanged().connect(_on_value_changed)
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_volume_slider_value_changed(float value) 
	{
		AudioServer.SetBusVolumeDb(busIndex,Mathf.LinearToDb(value));
	}
}
