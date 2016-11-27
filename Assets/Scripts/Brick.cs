using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	//public int maxHits;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;


	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = this.tag == "Breakable";
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		if (isBreakable) {
			breakableCount++;
		}

		Debug.Log ("The number of breakable bricks is " + breakableCount);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);

		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits(){
		timesHit++;
		
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Debug.Log ("The number of breakable bricks is " + breakableCount);
			Destroy (gameObject);
		} else {
			DamageSprite();
		}
	}

	void DamageSprite(){
		int spriteIndex = timesHit - 1;

		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex]; 
		}
	}

	void SimulateWin(){
		// TODO Remove this method once we can actually win
		levelManager.LoadNextLevel();
	}
}
