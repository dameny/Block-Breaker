using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
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
				this.rigidbody2D.velocity = new Vector2(3f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (started) {
			audio.Play ();
		}
	}
}
