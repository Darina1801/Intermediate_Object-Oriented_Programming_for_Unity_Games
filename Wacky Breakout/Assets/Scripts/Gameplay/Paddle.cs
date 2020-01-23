using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// The paddle
/// </summary>
public class Paddle : MonoBehaviour
{
	// moving paddle support
	private Rigidbody2D paddleRigidbody2D;

	// collider support
	float halfColliderWidth;

	//bounce support
	private const float BounceAngleHalfRange = (float)Math.PI / 3;

	// Start is called before the first frame update
	void Start()
    {
	    paddleRigidbody2D = GetComponent<Rigidbody2D>();
	    halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

	// FixedUpdate is called 50 times per second
	void FixedUpdate()
	{
		// paddle clamping in the screen support
		float horisontalAxisInput = Input.GetAxis("Horizontal");

		if (horisontalAxisInput != 0)
		{
			Vector2 newPosition = paddleRigidbody2D.position;
			newPosition.x += horisontalAxisInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
			newPosition.x = CalculateClampedX(newPosition.x);
			paddleRigidbody2D.MovePosition(newPosition);
		}
	}

	/// <summary>
	/// Clamps paddle in the screen
	/// </summary>
	/// <param name="newPositionX"></param>
	/// <returns>new x position</returns>
	float CalculateClampedX(float newPositionX)
	{
		if (newPositionX - halfColliderWidth < ScreenUtils.ScreenLeft)
		{
			return ScreenUtils.ScreenLeft + halfColliderWidth;
		}
		else if (newPositionX + halfColliderWidth > ScreenUtils.ScreenRight)
		{
			return ScreenUtils.ScreenRight - halfColliderWidth;
		}
		else
		{
			return newPositionX;
		}
	}

	/// <summary>
	/// Detects collision with a ball to aim the ball
	/// </summary>
	/// <param name="collision">collision info</param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ball") && TopCollision(collision))
		{
			// calculate new ball direction
			float ballOffsetFromPaddleCenter = transform.position.x -
			                                   collision.transform.position.x;
			float normalizedBallOffset = ballOffsetFromPaddleCenter /
			                             halfColliderWidth;
			float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
			float angle = Mathf.PI / 2 + angleOffset;
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

			// tell ball to set direction to new direction
			Ball ballScript = collision.gameObject.GetComponent<Ball>();
			ballScript.SetDirection(direction);
		}
	}

	bool TopCollision(Collision2D collision)
	{
		float paddleColliderTop = GetComponent<BoxCollider2D>().transform.position.y;
		if (collision.transform.position.y >= paddleColliderTop)
		{
			return true;
		}	
		else return false;
	}
}
