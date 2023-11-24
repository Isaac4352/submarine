using Godot;
using System;


namespace submarine_game
{

	public partial class pression : ProgressBar
	{
		// Called when the node enters the scene tree for the first time.

	
		Player player;
		public override void _Ready()
		{
			player = GetNode<Player>("submarine.tscn");
			update();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			GetNode<Player>("test");
		}

		public void update()
		{
			//Value = player.currentHealth;
			Value = player.currentHealth* 100/player.maxHealth;
		}
	}
}
