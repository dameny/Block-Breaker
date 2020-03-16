using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

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
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);

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
			puffSmoke();
			Destroy (gameObject);
		} else {
			DamageSprite();
		}
	}

	void puffSmoke(){
		Vector3 smokeLevelOffset = new Vector3(0.0f, 0.0f, -5.0f);
		GameObject smokePuff = Instantiate(smoke, transform.position + smokeLevelOffset, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer> ().color;
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
