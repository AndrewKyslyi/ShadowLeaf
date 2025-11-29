using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	private const float PI = Mathf.Pi;
	
	[Export]
	public Control JoystickLeft {get;set;} 
	// public VirtualJoystick JoystickRight {get;set;}
	
	private Vector2 direction = Vector2.Zero;
	
	public override void _PhysicsProcess(double delta)
	
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		//if (!IsOnFloor())
		//{
			//velocity += GetGravity() * (float)delta;
		//}

		// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		//{
			//velocity.Y = JumpVelocity;
		//}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		direction = Input.GetVector("left", "right", "up", "down");
		
		if (direction.LengthSquared() > 0) {
			
			float angle = direction.Angle();
			float eightDirAngle = Mathf.Round(angle / (PI / 4.0f)) * (PI / 4.0f);
			
			direction = Vector2.FromAngle(eightDirAngle).Normalized();
			
		} 
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
