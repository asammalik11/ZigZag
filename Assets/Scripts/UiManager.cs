using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;
	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text bestScore1;
	public Text bestScore2;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		bestScore1.text = "Best Score: " + PlayerPrefs.GetInt ("highScore").ToString();
	}

	public void GameStart(){
		tapText.SetActive (false);
		zigzagPanel.GetComponent<Animator> ().Play ("PanelUp");
	}

	public void GameOver(){
		score.text = PlayerPrefs.GetInt ("score").ToString();
		bestScore2.text = PlayerPrefs.GetInt ("highScore").ToString();
		gameOverPanel.SetActive (true);
	}

	public void Reset(){
		SceneManager.LoadScene (0);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
