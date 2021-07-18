using Godot;
using System;

public class PlayerAnimation : AnimatedSprite
{
    void _on_Player_signal(Vector2 motion)
    {
        if (motion.y < 0)
        {
            Play("jump");
        }
        else if (motion.x > 0)
        {
            FlipH = false;
            Play("walk");
        }
        else if (motion.x < 0)
        {
            FlipH = true;
            Play("walk");
        }
        else { Play("idle"); }
    }
}
