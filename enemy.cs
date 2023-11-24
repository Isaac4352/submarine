using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	int speed = 25;
	bool playerChase = false;
	Vector2 target_position;

	CharacterBody2D player = null;

	void _on_detection_area_body_entered(CharacterBody2D body)
	{
		player = body;
		playerChase = true;
	}

	void _on_detection_area_body_exited( CharacterBody2D body)
	{
		player = null;
		playerChase = false;
	}

	public override void _PhysicsProcess(double delta)
	{
		if(playerChase)
		{
			target_position = (player.Position - Position).Normalized();
			
			Velocity = target_position * speed;

			if(Position.DistanceTo(player.Position) > 3)
			{
				MoveAndSlide();
			}
		}
	}
}
