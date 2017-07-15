using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenuFunctions : MonoBehaviour {

	[SerializeField]
	private Button menuButton;
	[SerializeField]
	private AllLevelsConfigObject allLevels;
	[SerializeField]
	float yPos = -100;
	[SerializeField]
	float yDistance = -140;

	private GameObject scrollViewContent;


	// Use this for initialization
	void Start () {
		PopulateLevelSelectMenu ();
	}

	void PopulateLevelSelectMenu() {
		scrollViewContent = GameObject.Find ("Content");
		scrollViewContent.GetComponent<RectTransform> ().sizeDelta = 
			new Vector2 (scrollViewContent.GetComponent<RectTransform> ().sizeDelta.x, -yDistance *10* (allLevels.levels.Length + 0.5f));

		//		foreach (LevelWavesConfigObject level in allLevels.levels) {
		for (int i = 0; i < allLevels.levels.Length; i++) {
			Button newButton = Instantiate (menuButton, scrollViewContent.transform);
			newButton.GetComponent<RectTransform> ().localPosition = new Vector3 (0f, yPos, 0f);
			newButton.transform.Find ("Text").GetComponent<Text> ().text = allLevels.levels[i].levelName;
			yPos += yDistance;


			newButton.GetComponent<LevelSelectButton> ().TargetLevel = i;
		}
	}

	public void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
