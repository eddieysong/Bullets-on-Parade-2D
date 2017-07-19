// Eddie Song 2017-07-04
// Script to control the UI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private Text lives;

	// handles to UI elements in scene
	private GameObject bossHPCanvas;
	private RectTransform bossHPFill;

	private GameObject messageCanvas;
	private Text messageText;

	private GameObject simulatedInfoCanvas;

	// queue to hold messages
	private Queue<string> messagesQueue = new Queue<string>();

	// Use this for initialization
	void Awake () {
		lives = GameObject.Find ("Player Status Canvas/Lives Display").GetComponent<Text>();
		bossHPCanvas = GameObject.Find ("Boss HP Canvas");
		messageCanvas = GameObject.Find ("Message Canvas");
		simulatedInfoCanvas = GameObject.Find ("Simulated Info Canvas");

	}

	void Start () {
		bossHPFill = bossHPCanvas.transform.Find ("Gauge/Fill").GetComponent<RectTransform>();
		bossHPCanvas.SetActive (false);

		messageText = messageCanvas.transform.Find ("Panel/Text").GetComponent<Text> ();
		messageCanvas.SetActive (false);
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

	void QueueMessages (string [] messages) {
		foreach (string msg in messages) {
			messagesQueue.Enqueue (msg);
		}
		StartCoroutine(ShowNextMessage ());
	}

	IEnumerator ShowNextMessage () {
		if (!messageCanvas.activeInHierarchy && messagesQueue.Count > 0) {
			while (simulatedInfoCanvas.activeInHierarchy) {
				yield return new WaitForSeconds (0.1f);
			}
			messageCanvas.SetActive (true);
			messageText.text = messagesQueue.Dequeue();
			PauseGame (true);
		}
	}

	public void HideMessage () {
		messageCanvas.SetActive (false);
		if (messagesQueue.Count > 0) {
			StartCoroutine(ShowNextMessage ());
		} else {
			PauseGame (false);
		}
	}

	void PauseGame(bool pauseOn) {
		if (pauseOn) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}
}
