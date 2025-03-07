using Godot;

public partial class DeadZoom : Area2D
{
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("Player"))
		{
			GD.Print("玩家死亡");

			// 延迟所有关键操作 
			// 将操作推迟到当前物理帧结束后执行
			// 确保引擎完成所有碰撞检测和物理计算
			CallDeferred(nameof(HandlePlayerDeath), body);
		}
	}
	// 在 Godot 中遇到这个错误是因为你在 ​物理碰撞回调中直接执行了场景切换操作。以下是具体分析和解决方案：
	private void HandlePlayerDeath(Node2D playerBody)
	{
		// 1. 先切换场景
		string currentScenePath = GetTree().CurrentScene.SceneFilePath;
		GetTree().ChangeSceneToFile(currentScenePath);

		GameManager.InitGameData();

		// 2. 场景切换完成后自动会清理旧节点
		// 不再需要手动 QueueFree()
	}
}