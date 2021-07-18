using Godot;
using System;

public class Cloud : Node2D
{
    private bool timeout = false;
    private RayCast2D detector = new RayCast2D();

    public override void _Ready()
    {
        detector = GetNode<RayCast2D>("Sprite/RayCast2D");
    }

    public override void _Process(float delta)
    {
        if (detector.IsColliding())
        {
            fire();
        }
    }

    private void fire()
    {
        if (!timeout)
        {
            timeout = true;
            var lightning = GD.Load<PackedScene>("res://NPCs/Lightning.tscn").Instance();
            GetNode<RayCast2D>("Sprite/RayCast2D").AddChild(lightning);
            GetNode<Timer>("Sprite/Timer").Start();
        }
    }

    void _on_Timer_timeout()
    {
        timeout = false;
    }
}