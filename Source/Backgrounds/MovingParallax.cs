using Godot;

namespace IceGame.Source.Backgrounds
{
	public partial class MovingParallax : ParallaxLayer
	{
		[Export]
		public Vector2 Speed {get; set;}
		public override void _Process(double delta)
		{
			MotionOffset = new Vector2(
    			x: MotionOffset.X + Speed.X * (float)(delta * 60),
    			y: MotionOffset.Y + Speed.Y * (float)(delta * 60)
			);
		}
	}
}
