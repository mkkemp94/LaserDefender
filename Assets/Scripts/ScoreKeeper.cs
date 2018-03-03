using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
	This class keeps track of the static score.
	Objects that use this script will be updated when score is called.
*/
public class ScoreKeeper : MonoBehaviour {

	private Text scoreText;
	public static int score = 0;
	
	void Start() {
		scoreText = GetComponent<Text>();
		Reset();
	}
	
	public void Score (int points) {
		Debug.Log("Scored!");
		score += points;
		scoreText.text = score.ToString();
	}
	
	public static void Reset () {
		score = 0;
	}
}
