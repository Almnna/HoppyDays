using Godot;
using System;

public class JumpPad : Area2D
{
    AnimationPlayer animationPlayer = new AnimationPlayer();

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    void _on_JumpPad_body_entered(Player body)
    {
        //if (!animationPlayer.IsPlaying())
        //{
        animationPlayer.Play("boost");
        body.boostJump();
        //}
    }
}
