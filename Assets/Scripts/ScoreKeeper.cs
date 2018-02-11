using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text scoreText;
	public int score = 0;
	
	void Start() {
		scoreText = GetComponent<Text>();
		Reset();
	}
	
	public void Score (int points) {
		Debug.Log("Scored!");
		score += points;
		scoreText.text = score.ToString();
	}
	
	public void Reset () {
		score = 0;
		scoreText.text = score.ToString();
	}
}
