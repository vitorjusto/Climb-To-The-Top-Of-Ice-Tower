using Godot;
using IceGame.Source.States;
using System.Collections.Generic;

namespace IceGame.Source
{
    public partial class LevelManager : Node2D
    {
        private StateHandler _deathLoadHandler;
        private StateHandler _levelTransitionHandler;
        private readonly LevelSpwanData _spawnData = new(0, "res://Scenes/Levels/Act4.tscn");
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
                new LevelLoadState(_spawnData, this),
                new ScreenTransitionEndingState(GetNode<Panel>("CanvasLayer/Panel"))

            };
            _deathLoadHandler = new(list1);
            _deathLoadHandler.StartProcess();

            
            var list2 = new List<IState>()
            {
                new ScreenTransitionStartState(GetNode<Panel>("CanvasLayer/Panel")),
                new LevelLoadState(_spawnData, this),
                new ScreenTransitionEndingState(GetNode<Panel>("CanvasLayer/Panel"))

            };
            _levelTransitionHandler = new(list2);
        }

        public override void _Process(double delta)
        {
            _deathLoadHandler.Process(delta);
            _levelTransitionHandler.Process(delta);
        }

        public void StartDeathTransition()
        {
            _deathLoadHandler.StartProcess();
        }

        public void StartLevelTransition(int id, string path)
        {
            _spawnData.Id = id;
            _spawnData.LevelPath = path;
            _levelTransitionHandler.StartProcess();
        }

        public void AddChildOnLevel(Node2D node)
            => CurrentLevel.AddChild(node);
    }
}
