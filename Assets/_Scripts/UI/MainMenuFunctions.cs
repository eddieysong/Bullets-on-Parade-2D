using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

}