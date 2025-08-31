using Godot;

namespace IceGame.Source
{
    public partial class MovingPlataform : Node2D
    {
        [Export]
        public Track Track;

        public void OnPlayerDetected(Node2D node)
            => Track.Activate();
    }
}