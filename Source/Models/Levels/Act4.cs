using Godot;
using IceGame.Source;
using System;

public partial class Act4 : Node2D
{
	public override void _Ready()
	{
        Player.GetPlayer().GetNode<Camera2D>("Camera2D").Offset = new Vector2(0, -350);
    }

}
