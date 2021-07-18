using Godot;
using System;

public class Coin : Node2D
{
    private int coinValue;
    private bool taken = false;

    public override void _Ready()
    {
        coinValue = 1;
    }

    void _on_Area2D_body_entered(Player body)
    {
        if (!taken)
        {
            taken = true;
            var seffect = GetNode<AudioStreamPlayer2D>("coinSE");
            seffect.Play();

            var animate = GetNode<AnimationPlayer>("AnimationPlayer");
            animate.Play("die");//at the end of animation die func will be called
        }

         
    }

    public void die()
    {
        GetTree().CallGroup("Gamestate", "increaseCoins", coinValue);
        QueueFree();
    } 
}
