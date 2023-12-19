using Godot;
using System;

public partial class treasure : StaticBody2D
{
	Sprite2D sprite;
	AnimationPlayer animation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		animation = GetNode<AnimationPlayer>("AnimationPlayer");
		animation.Play("glow");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_area_entered(Area2D area)
	{
		if(area.Name == "hurtBox")
		{
			sprite.Visible = false;
		}
	}
}
