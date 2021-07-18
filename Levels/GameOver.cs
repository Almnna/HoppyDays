using Godot;
using System;

public class GameOver : Control
{
    private string CheckPointScene = "res://Levels/Level1.tscn";

    void _on_tryagain_pressed()
    {
        GetTree().ChangeScene(CheckPointScene);
    }
}
