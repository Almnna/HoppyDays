using Godot;
using System;

public class Hazards : Area2D
{
    public const string name = "Hazard";
    void _on_SpikeTop_body_entered(Player body)
    {
        //body.hurt(name);
        GetTree().CallGroup("Gamestate", "hurt", body, name);
    }
}
