using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSource;



	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = Vector2.right * speed;
	}

	void onCollisionEnter2D(Collision2D col)
	{
		//LeftPaddle or RightPaddle
		if ((col.gameObject.name == "LeftPaddle") || (col.gameObject.name == "RightPaddle"))
		{
			HandlePaddleHit (col);
		}
		//TopWall or BottomWall
		if ((col.gameObject.name == "TopWall") || (col.gameObject.name == "BottomWall"))
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.WallBloop);
		}
		//LeftGoal or RightGoal
		if ((col.gameObject.name == "LeftGoal") || (col.gameObject.name == "RightGoal"))
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.goalBloop);
		}

	}

	void HandlePaddleHit(Collision2D col)
	{
		float y = BallHitPaddleWhere (transform.position, col.transform.position, col.collider.bounds.size.y);

		Vector2 dir = new Vector2();

		if (col.gameObject.name == "LeftPaddle")
		{
			dir = new Vector2 (1, y).normalized;
		}

		if (col.gameObject.name == "RightPaddle")
		{
			dir = new Vector2 (-1, y).normalized;
		}
		rigidBody.velocity = dir * speed;
		SoundManager.Instance.PlayOneShot (SoundManager.Instance.hitPaddleBloop);
	}

	float BallHitPaddleWhere( Vector2 ball, Vector2 paddle, float paddleHeight)
	{
		return (ball.y - paddle.y) / paddleHeight;
	}
}
