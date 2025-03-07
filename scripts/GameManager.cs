using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	public int coinsAmount;
	public override void _EnterTree()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			QueueFree();
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitGameData();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public void InitGameData()
	{
		coinsAmount = 0;
	}
}
