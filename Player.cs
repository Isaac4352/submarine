using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace submarine_game
{
	public partial class Player : CharacterBody2D
	{
		[Export]
		private float Speed = 500.0f;

		private float RotationSpeed = 0.0f;
		private float _rotationDirection;
		private float _rotationDirectionTmp;
		const int ACCELERATION = 2;
		const float ROTATION_ACCELERATION = 0.001f;
		const float FRICTION = 2;
		private Vector2 starting_direction;
		private Vector2 direction;
		private Vector2 velocity;
		private AnimationNodeStateMachinePlayback stateMachine;
		private AnimationTree animationTree;

		[Export]
		public int maxHealth = 50;
		[Export]
		public int currentHealth;

		[Signal] 
		public delegate void healthChangedEventHandler();

		private AudioStreamPlayer2D soundEffect;

		void _ready() {
			stateMachine = GetNode<AnimationTree>("AnimationTree").Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
			animationTree = GetNode<AnimationTree>("AnimationTree");
			starting_direction =  new Vector2(0,(float)0.1);
			velocity = new Vector2(1,1);
			EmitSignal(nameof(healthChangedEventHandler));
			currentHealth = maxHealth;
			//updateAnimationParameter(starting_direction);
	}

		private Vector2 GetInput() {
			_rotationDirection = Input.GetAxis("ui_left", "ui_right");
			if(_rotationDirection != 0){
				_rotationDirectionTmp = _rotationDirection;
			} 
			direction = new Vector2(		
				0,
				Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up")
			);
			return direction;
		}

		private void updateAnimationParameter(Vector2 moveInput) {
			if(moveInput != Vector2.Zero) 
			{
				animationTree.Set("parameters/idle/blend_position", moveInput);
				animationTree.Set("parameters/walk/blend_position", moveInput);
			}
		}

		private void hurt(int damage)
		{
			currentHealth -= damage;

		}

		private void pickNewState() {
			if(Velocity != Vector2.Zero) {
				stateMachine.Travel("walk");
			}
			else {
				stateMachine.Travel("idle");
			}
		}

		public override void _PhysicsProcess(double delta)
		{
			// Velocity is a property of RigidBody2D.
			soundEffect = GetNode<AudioStreamPlayer2D>("./SoundEffectPlayer");
			//parameters/idle/blend_position
			velocity = Velocity;
			

			// You should replace UI actions with custom gameplay actions.
			Vector2 direction = GetInput();
			//GD.Print(Position);
			//updateAnimationParameter(direction);
			//GD.Print(velocity);

			//acc and frict


			if(direction == Vector2.Zero) {
				if (direction.Length() > (FRICTION * delta)) {
					//velocity.X -= velocity.Normalized().X * (FRICTION * (float)delta);
				}
			}	
			
		

			if(Input.IsActionPressed("ui_up") || Input.IsActionPressed("ui_down")) {
				velocity += direction.Rotated(Rotation) * ACCELERATION;
				if(!soundEffect.Playing)
				{
					soundEffect.Play();
					
				}
				soundEffect.VolumeDb +=  0.0001f;
				if(soundEffect.VolumeDb > 1)
				{
					soundEffect.VolumeDb = 1;
				}
				//soundEffect.VolumeDb = Mathf.Lerp(soundEffect.VolumeDb,0,1);
				//velocity = velocity * Speed * ACCELERATION;
			}
			else{
				velocity.X = Mathf.Lerp(velocity.X,0,0.1f);
				velocity.Y = Mathf.Lerp(velocity.Y,0,0.1f);
				soundEffect.Stop();
				soundEffect.VolumeDb -= ACCELERATION * 0.0001f;
				if(soundEffect.VolumeDb < 1)
				{
					soundEffect.VolumeDb = 0;
				}
				//soundEffect.VolumeDb = Mathf.Lerp(soundEffect.VolumeDb,0,1);
			} 



		// velocity = velocity.Rotated(Rotation);
			
			if(!Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down")) {
				if(Input.IsActionPressed("ui_left") || Input.IsActionPressed("ui_right")) {
					//RotationSpeed -= ROTATION_ACCELERATION * _rotationDirection.Normalized().X; 
			
					//RotationSpeed = Mathf.Clamp(RotationSpeed,(float)0.2,(float)-0.2);

					if(Input.IsActionPressed("ui_left")){
						RotationSpeed -= ROTATION_ACCELERATION ;
									velocity += direction.Rotated(Rotation) * ACCELERATION;
					}
					if(Input.IsActionPressed("ui_right")){
						RotationSpeed += ROTATION_ACCELERATION ;
									velocity += direction.Rotated(Rotation) * ACCELERATION;
					}

					if(RotationSpeed >= 0.2){
						RotationSpeed = 0.2f;
					}
					if(RotationSpeed <= -0.2){
						RotationSpeed = -0.2f;
					}

						
					//rotation += RotationSpeed; //ne peut pas y mettre direction, sinon la ralentissement ne marchera pas comme il faut
				
					
					// ui left, turn left, if ui right, turn right
					//velocity = velocity.Rotated(rotation);
				}
				else{
						//RotationSpeed -= ROTATION_ACCELERATION * _rotationDirection.Normalized().X; 
						if(RotationSpeed < 0) {
								RotationSpeed += ROTATION_ACCELERATION;
							// if(_rotationDirection > 0){
							// 	RotationSpeed -= ROTATION_ACCELERATION;
							// 	GD.Print("right");
							// }
						}
						else
						{
							if(RotationSpeed > 0){
								RotationSpeed -= ROTATION_ACCELERATION;
							//	GD.Print("left");
							}
						}

						if(Mathf.IsEqualApprox(_rotationDirection, 0)){
							_rotationDirection = 0;
							//GD.Print("close to 0");
						}
						else{
						//	GD.Print("test");
						}

								
						//GD.Print("in");
						
						//Rotation += RotationSpeed;
						//Rotation += RotationSpeed * _rotationDirection;
						
				}
			}
			else{

						if(RotationSpeed < 0) {
								RotationSpeed += ROTATION_ACCELERATION;
							// if(_rotationDirection > 0){
							// 	RotationSpeed -= ROTATION_ACCELERATION;
							//	GD.Print("right");
							// }
						}
						else
						{
							if(RotationSpeed > 0){
								RotationSpeed -= ROTATION_ACCELERATION;
							//	GD.Print("left");
							}
						}

						if(Mathf.IsEqualApprox(_rotationDirection, 0)){
							_rotationDirection = 0;
							//GD.Print("close to 0");
						}
						else{
						//	GD.Print("test");
						}
				// if(RotationSpeed != 0) {
				// 				RotationSpeed -= ROTATION_ACCELERATION;
				// 			// if(_rotationDirection > 0){
				// 			// 	RotationSpeed -= ROTATION_ACCELERATION;
				// 			// 	GD.Print("right");
				// 			// }
				// 			// if(RotationSpeed <= 0){
				// 			// 	RotationSpeed = 0;
				// 			// }
				// 		}
			
								
						//GD.Print("in");
						
						//Rotation += RotationSpeed * _rotationDirectionTmp;
			}
			//GD.Print(RotationSpeed);
					

				//GD.Print(RotationSpeed);
			//velocity = direction  * Speed * (float)delta;	
			//Velocity = velocity.Rotated(rotation);
			Rotation += RotationSpeed;
			Velocity = velocity;
			//GD.Print(Velocity);
			
			MoveAndSlide();
			//pickNewState();

		}
	}
}
