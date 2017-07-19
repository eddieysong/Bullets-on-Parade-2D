using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{

	private Canvas menuCanvas, creditCanvas;

	// Use this for initialization
	void Start ()
	{
		menuCanvas = GameObject.Find ("Menu Canvas").GetComponent<Canvas> ();
		try {
			creditCanvas = GameObject.Find ("Credit Canvas").GetComponent<Canvas> ();
			creditCanvas.enabled = false;
		} catch {
		}
	}

	public void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	public void ShowCredits ()
	{
		menuCanvas.enabled = false;
		creditCanvas.enabled = true;
	}

	public void ShowMenu ()
	{
		menuCanvas.enabled = true;
		creditCanvas.enabled = false;
	}

	public void LinkToGitHub ()
	{
		Application.OpenURL("https://github.com/eddieysong/Bullets-on-Parade-2D/");
	}

	public void LinkToTwitter ()
	{
		Application.OpenURL("https://twitter.com/eddieysong");
	}

}