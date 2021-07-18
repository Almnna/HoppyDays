using Godot;
using System;

public class Portal : Node2D
{
   void _on_Area2D_body_entered(Node2D body)
    {
        GetTree().CallGroup("Gamestate", "winGame");
    }
}
