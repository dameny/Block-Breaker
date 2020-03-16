using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool automatedTest = false;

	private float mousePosInBlocks;
	private bool started = false;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!automatedTest) {
			MoveWithMouse();
		} else if(automatedTest && !started){
			MoveWithMouse();
		}else {
			MoveAuto ();
		}
	}

	// A test mode where the paddle matches the ball's x transform so it can't lose
	void MoveAuto(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y , 0f);

		paddlePos.x = Mathf.Clamp (ball.transform.position.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	// Mouse based controls
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y , 0f);
		
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	public void GameStarted () {
		started = true;
	}
}
