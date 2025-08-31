using Godot;

namespace IceGame.Source
{
    public partial class Warpzone : Area2D
    {
        [Export]
        public int Id;
        [Export]
        public string Path;

        public void OnPlayerDetected(Node2D node)
            => LevelManager.GetManager().StartLevelTransition(Id, Path);
    }
}