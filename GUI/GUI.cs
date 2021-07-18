using Godot;
using System;

public class GUI : CanvasLayer
{
    private Label livesLabel = new Label();
    private Label coinsLabel = new Label();
    private int lives = 3;
    private int coins = 0;


    public override void _Ready()
    {
        //initalizations
        AddToGroup("GUI");

        livesLabel = GetNode<Label>("Control/Banner/HBoxContainer/livesCount");
        livesLabel.Text = lives.ToString();

        coinsLabel = GetNode<Label>("Control/Banner/HBoxContainer/coinsCount");
        coinsLabel.Text = coins.ToString();
    }

    public void update(int lives, int coins)
    {
        this.lives = lives;
        livesLabel.Text = this.lives.ToString();

        this.coins = coins;
        coinsLabel.Text = this.coins.ToString();
    }
}
