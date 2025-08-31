using Godot;
using System;

public partial class FragileBlock : Node2D
{
    private bool _isActived;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if(!_isActived)
            return;

    	Scale = new Vector2(1, Scale.Y - 0.03f) * (float)delta * 60;
    
    	if(Scale.Y < 0.01)
    		QueueFree();
    }

    public void OnPlayerDetected(Node2D node)
        => _isActived = true;
}
