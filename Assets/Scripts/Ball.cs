using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float initialSpeed;

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool started;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Mouse Button clicked");
				started = true;
				paddle.GameStarted();
				float angle = Random.Range(Mathf.PI/4, Mathf.PI * 3/4);
				this.rigidbody2D.velocity = new Vector2(initialSpeed * Mathf.Cos(angle), initialSpeed * Mathf.Sin(angle));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		float xVelocitySign = rigidbody2D.velocity.x/Mathf.Abs(rigidbody2D.velocity.x);
		float yVelocitySign = rigidbody2D.velocity.y/Mathf.Abs(rigidbody2D.velocity.y);
		Vector2 velocityNudge = new Vector2(xVelocitySign * Random.Range(0.0f, 0.02f), yVelocitySign * Random.Range(0.0f, 0.02f));

		if (started) {
			rigidbody2D.velocity += velocityNudge;

			Debug.Log (rigidbody2D.velocity + " " + rigidbody2D.velocity.magnitude);
			audio.Play ();
		}
	}
}
