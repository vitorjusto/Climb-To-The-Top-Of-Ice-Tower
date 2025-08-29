using System.Linq;
using Godot;

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
            GD.Print("test");
            var scene = GD.Load<PackedScene>(LevelData.LevelPath);
            var level = scene.Instantiate<Node2D>();

            var node = level.GetChildren().FirstOrDefault((x) => x is Spawner spawner && spawner.Id == LevelData.Id);
            _player.Position = ((Node2D)node).Position;

            _manager.CurrentLevel = level;
            _manager.AddChild(level);
            Player.GetPlayer().GetNode<Camera2D>("Camera2D").PositionSmoothingEnabled = false;

            return true;
        }

        public void Start()
        {
        }
    }
}