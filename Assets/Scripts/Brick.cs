using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;

	private LevelManager levelManager;
	private int timesHit;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision){
		timesHit++;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
		}

	}

	void SimulateWin(){
		// TODO Remove this method once we can actually win
		levelManager.LoadNextLevel();
	}
}
