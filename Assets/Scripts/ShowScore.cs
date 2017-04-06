using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour {

	public Text scoreText;

	private int score;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("score", score);
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
