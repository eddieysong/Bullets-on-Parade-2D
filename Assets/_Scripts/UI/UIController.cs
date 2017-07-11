// Eddie Song 2017-07-04
// Script to control the UI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private Text lives;

	private GameObject bossHPCanvas;
	private RectTransform bossHPFill;

	// Use this for initialization
	void Awake () {
		lives = GameObject.Find ("Player Status Canvas/Lives Display").GetComponent<Text>();
		bossHPCanvas = GameObject.Find ("Boss HP Canvas");

	}

	void Start () {
		bossHPFill = bossHPCanvas.transform.Find ("Gauge/Fill").GetComponent<RectTransform>();
		bossHPCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RefreshLives (int livesRemaining) {
		lives.text = livesRemaining.ToString ();
	}

	void ToggleBossHP (bool setActive) {
		bossHPCanvas.SetActive (setActive);
	}

	void RefreshBossHP (float proportionHP) {
		bossHPFill.localScale = new Vector2 (proportionHP, 1);
	}
}
