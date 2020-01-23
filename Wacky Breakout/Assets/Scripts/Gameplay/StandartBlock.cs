using UnityEngine;

/// <summary>
/// A standart block
/// </summary>
public class StandartBlock : MonoBehaviour
{
	// Destroy a the block on collision with the ball
    void OnCollisionEnter2D(Collision2D collision)
    {
		GameObject ball = GameObject.FindWithTag("Ball");
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(gameObject);
		}
    }
}
