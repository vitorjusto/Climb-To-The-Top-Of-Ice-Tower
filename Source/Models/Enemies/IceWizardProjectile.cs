using Godot;

namespace IceGame.Source.Models.Enemies
{
    public partial class IceWizardProjectile : CharacterBody2D
    {
        public const float Speed = 300.0f;
        public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

        public override void _PhysicsProcess(double delta)
        {
            Vector2 velocity = Velocity;

            velocity.Y += gravity * (float)delta;
            Velocity = velocity;
            MoveAndSlide();

            if(IsOnFloor())
                QueueFree();
        }
    }
}
