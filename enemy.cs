using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace submarine_game
{
	public partial class enemy : CharacterBody2D
	{
		int speed = 50;
		int rotationSpeed = 10;
		bool playerChase = false;
		Vector2 target_position;
		[Export]
		public int knockbackPower = 5000;

		Sprite2D sprite;

		Player player = null;

		void _on_detection_area_body_entered(Player body)
		{
			sprite = GetNode<Sprite2D>("Sprite2D");
			player = body;
			playerChase = true;
			GD.Print("chase");
		}

		void _on_detection_area_body_exited( CharacterBody2D body)
		{
			player = null;
			playerChase = false;
		}

			public void _on_hit_box_area_entered(Area2D area){
				if(area.Name == "hurtBox")
				{
					GD.Print(area.Name);
					//give meduse decceleration and acceleration, make look smoother, velocity not so sudden
					knockback();
				}
			}	
			public void knockback()
			{
				Vector2 knockbackDirection = -Velocity.Normalized() * knockbackPower;
				Velocity = knockbackDirection;
				GD.Print("enemy position: " + Position);
				MoveAndSlide();
					GD.Print("enemy position: " + Position);
			}

		void rotateToTarget(Node2D target, double delta)
		{
			Vector2 direction = target.Position - Position;
			float angleTo = Transform.X.AngleTo(direction);
			Rotate((float)(Mathf.Sign(angleTo) * Mathf.Min(delta * rotationSpeed, Mathf.Abs(angleTo))));
		}

		public override void _PhysicsProcess(double delta)
		{
			if(playerChase && player.currentHealth > 0)
			{
				target_position = (player.Position - Position).Normalized();
				
				//target_position = Position.MoveToward(player.Position, (float)delta * speed);
				//GD.Print("target_position" + target_position);
				
				Velocity = target_position * speed;

				if(Position.DistanceTo(player.Position) > 3)
				{
					MoveAndSlide();
		
					//LookAt(target_position);
				}
					rotateToTarget(player,delta);
			}
		}
	}

}
