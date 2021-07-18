using Godot;
using System;

public class Lightning : Node2D
{
    private Vector2 motion = new Vector2(0, 0);

    private const float SPEED = 400;

    public override void _Ready()
    {
        SetAsToplevel(true);//doesn't inherit the parent position instead 0, 0
        motion = GlobalPosition = GetParent<RayCast2D>().GlobalPosition;
    }

    public override void _Process(float delta)
    {
        motion.y += SPEED * delta;
        Position = motion;

        ManageCollision();
    }

    private void ManageCollision()
    {
        var collider = GetNode<Area2D>("Area2D").GetOverlappingBodies();
        foreach (Node body in collider)
        {
            if (body.Name == "Player")
            {
                GetTree().CallGroup("Gamestate", "hurt", body, "Hazard");
            }
            QueueFree();
        }
    }

    void _on_VisibilityNotifier2D_screen_exited()
    {
        QueueFree();
    }
}
