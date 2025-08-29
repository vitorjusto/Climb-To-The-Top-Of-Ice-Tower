using System;
using Godot;
namespace IceGame.Source.States
{
    public class ScreenTransitionEndingState : IState
    {
        private Panel _screen;
        private Vector2 _startPosition;
        private float _speed = 5000;

        public ScreenTransitionEndingState(Panel screen)
        {
            _screen = screen;
            _startPosition = new Vector2(-7231, -265);
        }

        public bool Process(double delta)
        {
            _screen.Position += new Vector2(_speed, 0) * (float)delta;

            if(_screen.Position.X > 3092)
            {
                _screen.Position = _startPosition;
                Player.GetPlayer().GetNode<Camera2D>("Camera2D").PositionSmoothingEnabled = true;
                return true;
            }

            return false;
        }

        public void Start()
        {
        }
    }
}