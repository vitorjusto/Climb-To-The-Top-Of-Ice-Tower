using Godot;
using IceGame.Source.States;
using System;
using System.Collections.Generic;

namespace IceGame.Source
{
    public partial class LevelManager : Node2D
    {
        private StateHandler _deathLoadHandler;
        public Node2D CurrentLevel;

        private static LevelManager _manager;
        public static LevelManager GetManager()
            => _manager;

        public override void _Ready()
        {
            _manager = this;
            var list1 = new List<IState>()
            {
                new ScreenTransitionStartState(GetNode<Panel>("CanvasLayer/Panel")),
                new LevelLoadState(new LevelSpwanData(0, "res://Scenes/Levels/Act1.tscn"), this),
                new ScreenTransitionEndingState(GetNode<Panel>("CanvasLayer/Panel"))

            };
            _deathLoadHandler = new(list1);
            _deathLoadHandler.StartProcess();
        }

        public override void _Process(double delta)
        {
            _deathLoadHandler.Process(delta);
        }

        public void StartDeathTransition()
        {
            _deathLoadHandler.StartProcess();
        }
    }
}
