using Godot;
namespace IceGame.Source.States
{
    public class ScreenTransitionStartState : IState
    {
        private Panel _screen;
        private float _speed = 5000;

        public ScreenTransitionStartState(Panel screen)
        {
            _screen = screen;
        }

        public bool Process(double delta)
        {
            _screen.Position += new Vector2(_speed, 0) * (float)delta;

            return _screen.Position.X > -462;
        }

        public void Start()
        {
        }
    }
}