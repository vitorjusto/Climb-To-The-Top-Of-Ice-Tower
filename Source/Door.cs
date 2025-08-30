using Godot;
using IceGame.Source;
using System;

public partial class Door : Node2D
{
    private bool _isDlayerFrontDoor;
    [Export]
    public int Id;
    [Export]
    public string Path;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if(_isDlayerFrontDoor && Input.IsActionJustPressed("Up"))
            LevelManager.GetManager().StartLevelTransition(Id, Path);

    }

    public void OnPlayerEntered(Node2D node)
        => _isDlayerFrontDoor = true;
    public void OnPlayerExited(Node2D node)
        => _isDlayerFrontDoor = false;
}
