using System;
using Godot;
namespace IceGame.Source.States
{
    public class ScreenTransitionStartState : IState
    {
        private Panel _screen;
        private Vector2 _startPosition;
        private float _speed = 2000;

        public ScreenTransitionStartState(Panel screen)
        {
            _screen = screen;
            _startPosition = new Vector2(-2303, -265);
        }

        public bool Process(double delta)
        {
            GD.Print(_screen.Position);
            _screen.Position += new Vector2(_speed, 0) * (float)delta;

            return _screen.Position.X > -462;
        }

        public void Start()
        {
        }
    }
}