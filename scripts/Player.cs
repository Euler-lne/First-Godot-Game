using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float SPEED = 100f;
    public const float JUMP_FORCE = -300f; // 重命名更贴切
    public int direction = 1;
    private AnimatedSprite2D animatedSprite2D;

    // 获取项目设置中的重力值
    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


    public override void _Ready()
    {
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // 自动重力应用
        if (!IsOnFloor())
        {
            // 为什么这里需要乘以 delta，因为 gravity 的加速度，要乘以时间才是速度
            velocity.Y += gravity * (float)delta;
        }

        // 水平移动
        velocity.X = Input.GetAxis("move_left", "move_right") * SPEED;

        // 跳跃修复：仅响应按键按下瞬间
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JUMP_FORCE;
        }
        if (IsOnFloor())
        {// 动画方向控制
            if (velocity.X != 0)
            {
                animatedSprite2D.FlipH = velocity.X < 0;
                animatedSprite2D.Play("run");
            }
            else
            {
                animatedSprite2D.Play("idle");
            }
        }
        else
        {
            animatedSprite2D.Play("jump");
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}