using Godot;
using System;

public partial class Coin : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			GameManager.Instance.coinsAmount++;
			GD.Print(GameManager.Instance.coinsAmount);
			QueueFree();
		}
	}
}
