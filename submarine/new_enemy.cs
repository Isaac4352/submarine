using Godot;
using System;

public partial class new_enemy : Area2D
{
	// Called when the node enters the scene tree for the first time.

	[Export]
	int speed = 25;
	[Export]
	Vector2 moveDirection;
	int rotationSpeed = 10;
	bool playerChase = false;
	Vector2 startPosition;
	Vector2 targetPosition;

	Sprite2D sprite;

	CharacterBody2D player = null;
	public override void _Ready()
	{
		startPosition = GlobalPosition;
		targetPosition = startPosition + moveDirection;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
