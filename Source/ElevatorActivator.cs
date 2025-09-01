using Godot;
using System;

public partial class ElevatorActivator : Area2D
{
    [Export]
    public AnimationPlayer Player;
    private bool _isActivated;

    public void OnPlayerDetected(Node2D node)
    {
        if(_isActivated)
            return;

        _isActivated = true;
        Player.Play("new_animation");
    }
}
