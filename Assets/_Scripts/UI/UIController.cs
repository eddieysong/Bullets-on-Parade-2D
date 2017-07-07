using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private Text lives;

	// Use this for initialization
	void Awake () {
		lives = GameObject.Find ("Canvas/Lives Display").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshLives (int livesRemaining) {
		lives.text = livesRemaining.ToString ();
	}
}
