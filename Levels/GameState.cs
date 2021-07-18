using Godot;
using System;

public class GameState : Node2D
{
    private const string GameOverScene = "res://Levels/GameOver.tscn";
    private const string winGameScene = "res://Levels/Victory.tscn";
    private int lives                  = 3;
    private int coins                  = 0;

    public override void _Ready()
    {
        AddToGroup("Gamestate");
    }
    

    private void endGame()
    {
        GetTree().ChangeScene(GameOverScene);
    }

    private void winGame()
    {
        GetTree().ChangeScene(winGameScene);
    }

    public void hurt(Player body, string hurtType)
    {
        body.hurt(hurtType);
        lives -= 1;
        update(lives, coins);
        if (lives < 0) { endGame(); }
    }

    public void increaseCoins(int coin = 1)
    {
        coins += coin;
        update(lives, coins);
    }

    public void update(int lives, int coins)
    {
        GetTree().CallGroup("GUI", "update", lives, coins);
    }
}
