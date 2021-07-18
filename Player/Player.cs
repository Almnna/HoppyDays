using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 motion              = new Vector2(0, 0);
    private const int SPEED             = 1000;
    private const int GRAVITY           = 300;
    private const int jumpSPEED         = 6000;
    private const int Boost             = 2;
    private Vector2 UP                  = new Vector2(0, -1);
    private const int WORLDLIMIT        = 4000;
    private bool HURTJUMP               = false;
    private bool BOOSTJUMP              = false;
    private AudioStreamPlayer jumpAudio = new AudioStreamPlayer();
    private AudioStreamPlayer painAudio = new AudioStreamPlayer();
    //Exports
    //[Export]
   
    //Signals//
    [Signal]
    public delegate void signal(Vector2 motion);

    public override void _Ready()
    {
        jumpAudio = GetNode<AudioStreamPlayer>("jump");
        painAudio = GetNode<AudioStreamPlayer>("pain");
    }

    private void hurtJump()
    {
        HURTJUMP = false;
        motion.y -= jumpSPEED;
        playSoundEffect("pain");
    }

    public void applyGravity()
    {
        if (Position.y > WORLDLIMIT)
        {
           GetTree().CallGroup("Gamestate", "endGame");
        }
        else if (IsOnCeiling()) {
            motion.y = 1;
        } else if (!IsOnFloor())
        {
            motion.y += GRAVITY;

        }
        else if (HURTJUMP)
        {
            //motion.y = 0;
            hurtJump();
        }else if ( IsOnFloor() && BOOSTJUMP)
        {
            //motion.y = 0;
            boost();
        }
        else
        {
            motion.y = 0;
        }
    }

    public void move()
    {
        if (Input.IsActionPressed("left") && !Input.IsActionPressed("right")) { motion.x = -SPEED; }
        else if (Input.IsActionPressed("right") && !Input.IsActionPressed("left")){ motion.x = SPEED; }
        else { motion.x = 0; }
    }

    public void jump()
    {
        if (Input.IsActionPressed("jump") && IsOnFloor()){
            motion.y = -jumpSPEED;
            playSoundEffect("jump");
        }
    }

    public void animate()
    {
        EmitSignal("signal", motion);
    } 

    public void hurt(string name = null)
    {
        if(name != null)
        {
            if(name == "Hazard") { HURTJUMP = true; }
        }
    }

    public void boostJump()
    {
        BOOSTJUMP = true;
    }

    public void playSoundEffect(string name)
    {
        if (name == "jump") { jumpAudio.Play(); } else if (name == "pain") { painAudio.Play(); }
    }

    public void boost()
    {
        BOOSTJUMP = false;
        motion.y = (-(jumpSPEED - 1000) * Boost);
        playSoundEffect("jump");
    }

    public override void _PhysicsProcess(float delta)
    {
        applyGravity();
        move();
        jump();
        animate();
        MoveAndSlide(motion, UP);
    }
}
