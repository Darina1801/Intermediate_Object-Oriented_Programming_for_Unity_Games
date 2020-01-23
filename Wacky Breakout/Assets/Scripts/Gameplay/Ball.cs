using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		float angle = 3 * Mathf.PI / 2;
		Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
		GetComponent<Rigidbody2D>().AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// Setts new direction on collision with the paddle
	/// </summary>
	/// <param name="newDirection"></param>
    public void SetDirection(Vector2 newDirection)
	{
		Vector2 currentVelocity = GetComponent<Rigidbody2D>().velocity;
		GetComponent<Rigidbody2D>().AddForce(newDirection * ConfigurationUtils.BallImpulseForce - currentVelocity, ForceMode2D.Impulse);
	}
}
