using Godot;
using System;
/// <summary>
/// 注意Position和GlobalPosition的区别，一个是相对坐标另一个的全局坐标，相对坐标是不会改变的
/// 特别注意的一点如果Plate From 有一个会移动的父节点那么这个逻辑就会出现问题
/// </summary>
public partial class Platefrom : AnimatableBody2D
{
	[Export] Node2D[] positionArr;
	public const float SPEED = 65f;
	private int curPosIndex = -1;
	private int nextPosIndex;
	private Vector2 offsetPosition = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		curPosIndex = positionArr != null && positionArr.Length >= 1 ? 0 : -1;
		nextPosIndex = curPosIndex != -1 ? 1 : 0;
		if (curPosIndex != -1)
			offsetPosition = positionArr[curPosIndex].GlobalPosition - positionArr[curPosIndex].Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		if (curPosIndex != -1)
		{
			Vector2 nextPos = positionArr[nextPosIndex].Position + offsetPosition;
			Vector2 curPos = Position;
			var direction = (nextPos - curPos).Normalized;
			float distance = curPos.DistanceTo(nextPos);
			if (distance <= 0.5)
			{
				SetNextRoundPosition();
			}
			float moveDistance = SPEED * (float)delta;
			if (distance < moveDistance)
				moveDistance = distance;
			curPos += moveDistance * direction();
			Position = curPos;
		}
	}
	private void SetNextRoundPosition()
	{
		if (curPosIndex == -1) return;
		curPosIndex = curPosIndex == positionArr.Length - 1 ? 0 : curPosIndex + 1;
		nextPosIndex = nextPosIndex == positionArr.Length - 1 ? 0 : nextPosIndex + 1;
	}
}
