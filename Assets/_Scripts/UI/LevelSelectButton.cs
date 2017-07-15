using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour {

	private int targetLevel;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (LoadLevel);
	}
	
	void LoadLevel () {
		Debug.Log (targetLevel);
		SceneParameters.currentLevel = targetLevel;
		SceneManager.LoadScene ("LevelMain");
	}

	public int TargetLevel {
		get {
			return this.targetLevel;
		}
		set {
			targetLevel = value;
		}
	}
}
