using Godot;
using System;

public partial class GameManager : Node
{

	public static int coinsAmount;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitGameData();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public static void InitGameData()
	{
		coinsAmount = 0;
	}
}
