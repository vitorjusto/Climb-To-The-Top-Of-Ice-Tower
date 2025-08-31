using System;
using Godot;

namespace IceGame.Source
{
    public partial class Player : CharacterBody2D
    {
        public const float Speed = 1000.0f;
        public const float JumpVelocity = -600.0f;
        public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

        private static Player _player;
        private bool _isDebug = false;
        public static Player GetPlayer()
            => _player;

        public override void _Ready()
        {
            _player = this;
        }

        public override void _PhysicsProcess(double delta)
        {

#if DEBUG
            //TODO: remove debug mode        
            if(Input.IsActionJustPressed("DebugMode"))
            {
                _isDebug = !_isDebug;
                GetNode<CollisionShape2D>("Hurtbox/CollisionShape2D").Disabled = _isDebug;
                Velocity = Vector2.Zero;
            }

            if(_isDebug)
            {
                HandleDebugControls();
                return;
            }
            
            if(Input.IsActionJustPressed("AutoDeath"))
                LevelManager.GetManager().StartDeathTransition();
#endif
            Vector2 velocity = Velocity;

            // Add the gravity.
            if (!IsOnFloor())
                velocity.Y += gravity * (float)delta;

            // Handle Jump.
            if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
                velocity.Y = JumpVelocity;


            var downButtonPressed = Input.IsActionPressed("Down");

            HandleCrouching(downButtonPressed);

            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

            if(!downButtonPressed && direction != Vector2.Zero)
                velocity.X = direction.X * Speed;
            else
                velocity.X = 0;
                
            velocity.X = Mathf.MoveToward(Velocity.X, velocity.X, 5);

            Velocity = velocity;
            MoveAndSlide();
        }

        private void HandleCrouching(bool downButtonPressed)
        {
            GetNode<Panel>("Panel").Visible = !downButtonPressed;
            GetNode<Panel>("Panel2").Visible = downButtonPressed;

            GetNode<CollisionShape2D>("CollisionShape2D").Disabled = downButtonPressed;
            GetNode<CollisionShape2D>("CollisionShape2D2").Disabled = !downButtonPressed;

            GetNode<CollisionShape2D>("Hurtbox/CollisionShape2D").Disabled = downButtonPressed;
            GetNode<CollisionShape2D>("Hurtbox/CollisionShape2D2").Disabled = !downButtonPressed;
        }

        private void HandleDebugControls()
        {
            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            this.Position += direction * 10;
        }

        public void OnAreaDetected(Area2D area)
            => LevelManager.GetManager().StartDeathTransition();
        public void OnBodyDetected(Node2D node)
            => LevelManager.GetManager().StartDeathTransition();
    }
}