using Godot;
using System;
using System.Drawing;


namespace submarine_game
{

	public partial class pression : TextureProgressBar
	{
		// Called when the node enters the scene tree for the first time.

	
		Player player;
		public override void _Ready()
		{
			GD.Print("root: " + GetParent().GetParent());
			player = GetParent().GetParent<Player>();
	
		
			
			update();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			update();
		}

		public void update()
		{
			Value = player.currentHealth;
			Value = player.currentHealth* 100/player.maxHealth;
		}
	}
}
