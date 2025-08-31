using System;
using System.Linq;
using Godot;
using IceGame.Source.Enums;

namespace IceGame.Source.States
{
    public class LevelLoadState : IState
    {
        public LevelSpwanData LevelData;
        private readonly Player _player;
        private LevelManager _manager;

        public LevelLoadState(LevelSpwanData levelData, LevelManager manager)
        {
            LevelData = levelData;
            _player = Player.GetPlayer();
            _manager = manager;
        }

        public bool Process(double delta)
        {
            _manager.CurrentLevel?.CallDeferred("queue_free");
            var scene = GD.Load<PackedScene>(LevelData.LevelPath);
            var level = scene.Instantiate<Node2D>();

            var node = (Node2D)level.GetChildren().FirstOrDefault((x) => x is Spawner spawner && spawner.Id == LevelData.Id);
            _player.Position = (node).Position;

            SetCameraBlocker(level);

            _manager.CurrentLevel = level;
            _manager.AddChild(level);
            _player.GetNode<Camera2D>("Camera2D").PositionSmoothingEnabled = false;

            return true;
        }

        private void SetCameraBlocker(Node2D level)
        {
            var camera = _player.GetNode<Camera2D>("Camera2D");
    
            camera.LimitTop = -10000000;
            camera.LimitBottom = 10000000;
            camera.LimitLeft = -10000000;
            camera.LimitRight = 10000000;

            foreach(var blocker in level.GetChildren().Where((x) => x is CameraBlocker).Select((x) => (CameraBlocker)x))
            {
                if (blocker.Anchor == EAnchor.Top)
                    camera.LimitTop = (int)blocker.Position.Y;
                else if (blocker.Anchor == EAnchor.Bottom)
                    camera.LimitBottom = (int)blocker.Position.Y;
                else if (blocker.Anchor == EAnchor.Left)
                    camera.LimitLeft = (int)blocker.Position.X;
                else if (blocker.Anchor == EAnchor.Right)
                    camera.LimitRight = (int)blocker.Position.X;
            }
        }

        public void Start()
        {
        }
    }
}