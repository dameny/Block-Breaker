using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level Loaded: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit ();
	}

	public void LoadNextLevel (){
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
