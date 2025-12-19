using Godot;

namespace IceGame.Source
{
	public partial class TitleScreen : Node2D
	{
		private double _timer = 100;
		[Export]
		public AnimationPlayer AniPlayer;
		public override void _Process(double delta)
		{
			if(_timer > 0)
			{
				_timer -= delta * 60;

				if(_timer <= 0)
					AniPlayer.Play("new_animation");

				return;
			}

			if(Input.IsActionJustPressed("Spacebar"))
				GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
		}
	}
}