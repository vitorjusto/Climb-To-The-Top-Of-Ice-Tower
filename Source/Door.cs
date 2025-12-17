using System;
using Godot;
using IceGame.Source;

public partial class Door : Node2D
{
    private bool _isDlayerFrontDoor;
    [Export]
    public int Id;
    [Export]
    public string Path;
    private OpacityChangerNode _opacityChanger;

    public override void _Ready()
        => _opacityChanger = new OpacityChangerNode(GetNode<Node2D>("PlayerButtonUp"));

	public override void _Process(double delta)
	{
        if(_isDlayerFrontDoor && Input.IsActionJustPressed("Up"))
            LevelManager.GetManager().StartLevelTransition(Id, Path);

		_opacityChanger.Active = _isDlayerFrontDoor;
		_opacityChanger.Process(delta);
    }

    public void OnPlayerEntered(Node2D node)
        => _isDlayerFrontDoor = true;
    public void OnPlayerExited(Node2D node)
        => _isDlayerFrontDoor = false;
}
public class OpacityChangerNode
{
    public bool Active;
    private readonly Node2D _node;
    private double _opacity;
    public OpacityChangerNode(Node2D node)
    {
        _node = node;
    }
    public void Process(double delta)
    {
        if(Active)
            _opacity += 600 * delta;
        else
            _opacity -= 600 * delta;
			
        _opacity = Math.Clamp(_opacity, 0, 255);
        _node.Modulate = Color.Color8(255, 255, 255, (byte)_opacity);
    }
}
