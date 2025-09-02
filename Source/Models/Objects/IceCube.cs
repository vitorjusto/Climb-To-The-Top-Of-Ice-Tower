using Godot;

namespace IceGame.Source.Models.Objects
{
    public partial class IceCube : Area2D
    {
        public void OnPlayerDetected(Node2D node)
            => this.GetTree().ChangeSceneToFile("res://Scenes/EndingScreen.tscn");

    }
}