using Godot;

namespace IceGame.Source
{
    public partial class Player : CharacterBody2D
    {
        public const float Speed = 1000.0f;
        public const float JumpVelocity = -600.0f;
        public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

        private static Player _player;
        public static Player GetPlayer()
            => _player;

        public override void _Ready()
        {
            _player = this;
        }

        public override void _PhysicsProcess(double delta)
        {
            Vector2 velocity = Velocity;

            // Add the gravity.
            if (!IsOnFloor())
                velocity.Y += gravity * (float)delta;

            // Handle Jump.
            if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
                velocity.Y = JumpVelocity;

            // Get the input direction and handle the movement/deceleration.
            // As good practice, you should replace UI actions with custom gameplay actions.
            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            if (direction != Vector2.Zero)
            {
                velocity.X = direction.X * Speed;
            }
            else
                velocity.X = 0;

            velocity.X = Mathf.MoveToward(Velocity.X, velocity.X, 5);

            Velocity = velocity;
            MoveAndSlide();
        }
    }
}