using Godot;

namespace IceGame.Source.Models.Enemies
{
    public partial class IceWizard : CharacterBody2D
    {
        private Node2D _leftAnchor;
        private Node2D _rightAnchor;
        private PackedScene _projectileScene;
        private Player _player;
        private float _timer;

        public override void _Ready()
        {
            _leftAnchor = GetNode<Node2D>("LeftAnchor");
            _rightAnchor = GetNode<Node2D>("RightAnchor");

            _projectileScene = GD.Load<PackedScene>("res://Scenes/Enemies/IceWizardProjectile.tscn");

            _player = Player.GetPlayer();
        }

        public override void _PhysicsProcess(double delta)
        {
            _timer += (float)delta * 60;

            if (_timer < 100)
                return;

            _timer -= 100;

            var instance = _projectileScene.Instantiate<Node2D>();

            if (_player.Position.X > Position.X)
                instance.Position = _rightAnchor.Position + Position;
            else
                instance.Position = _leftAnchor.Position + Position;

            LevelManager.GetManager().AddChildOnLevel(instance);
        }
    }
}