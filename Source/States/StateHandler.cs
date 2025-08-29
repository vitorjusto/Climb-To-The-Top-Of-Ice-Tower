using System.Collections.Generic;
using System.Linq;
using Godot;

namespace IceGame.Source.States
{
    public class StateHandler
    {
        private List<IState> _states;
        private IState _currentState;
        private int _currentStateIndex;
        private bool _processing;

        public StateHandler(List<IState> states)
        {
            _states = states;
        }

        public void Process(double delta)
        {
            if(!_processing)
                return;
            
            if(_currentState.Process(delta))
            {
                _currentStateIndex++;
                if(_currentStateIndex == _states.Count)
                    _processing = false;
                else
                {
                    _currentState = _states[_currentStateIndex];
                    _currentState.Start();
                }
            }   
        }

        public void StartProcess()
        {
            _processing = true;
            _currentState = _states.First();
            _currentState.Start();
            _currentStateIndex = 0;
        }
    }
}