using Godot;
using System;


public partial class KnightController : Node2D
{
	[Export] CharacterBody2D body;
	[Export] AnimatedSprite2D animatedSprite;
	[Export] int runVelocity = 40;
	[Export] float gravity = 10;

	float currenDirection = 0;
	float gravityForce = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

		currenDirection = Input.GetActionStrength("RightKey", false) + (-Input.GetActionStrength("LeftKey", false));

		//IDLE
		if (currenDirection == 0)
		{
			animatedSprite.Play("IDLE");
		}
		//MOVE LEFT
		if (currenDirection < 0)
		{
			animatedSprite.FlipH = true;
			animatedSprite.Play("RUN");
		}
		//MOVE RIGHT
		if (currenDirection > 0)
		{
			animatedSprite.FlipH = false;
			animatedSprite.Play("RUN");
		}

		if (Input.IsActionPressed("JumpKey"))
		{
			gravityForce = -300;
		}

    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		gravityForce += gravity* Convert.ToSingle(delta);
		if (body.IsOnFloor())
		{
			gravityForce = 0;
		}
		GD.Print(gravityForce);
		body.Velocity = new(currenDirection * runVelocity, gravityForce);

		GD.Print(body.IsOnFloor());
		//body.Velocity = new Vector2(20, 0);

		body.MoveAndSlide();
	}
}
