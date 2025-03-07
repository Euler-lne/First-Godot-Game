using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float SPEED = 20f;
    public const float JUMP_SPEED = -100f;
    public int direction = 1;
    private AnimatedSprite2D animatedSprite2D;

    public override void _Ready()
    {
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        var position = Position;
        // var dir = Input.GetAxis("move_left", "move_right");
        // GD.Print(dir);
        if (Input.IsActionPressed("move_left"))
        {
            direction = 1;
            position.X += SPEED * (float)delta * direction;
            animatedSprite2D.FlipH = true;
        }
        else if (Input.IsActionPressed("move_right"))
        {
            direction = 01;
            position.X += SPEED * (float)delta * direction;
            animatedSprite2D.FlipH = false;
        }
        else if (Input.IsActionPressed("jump"))
        {
            position.Y += JUMP_SPEED * (float)delta;
        }
        Position = position;
    }
}
