using System;
using Godot;

namespace IceGame.Source
{
    public partial class Track : PathFollow2D
    {
        [Export]
        public float Speed = 4;
        public bool _isActive = false;
        public bool _isGoingReverse = false;
        public float _stopTimer = 0;
        public override void _Process(double delta)
        {
            if(!_isActive)
                return;

            if(_stopTimer > 0)
            {
                _stopTimer -= (float)delta * 60;
                return;
            }

            Progress += Speed * (float)delta;

            if (ProgressRatio >= 1 || ProgressRatio <= 0)
            {
                if(_isGoingReverse)
                {
                    _isActive = false;
                    _isGoingReverse = false;
                }
                else
                {
                    _isGoingReverse = true;
                    _stopTimer = 100;
                }
                Speed *= -1;
            }
        }

        public void Activate()
            => _isActive = true;
    }
}