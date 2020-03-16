// Manages the level switching. Since the level has to switch when all the blocks are destroyed
// The brick class sends a message to the level manager and the level manager checks the number
// of bricks left.

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		Debug.Log ("Level Loaded: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit ();
	}

	public void LoadNextLevel (){
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
