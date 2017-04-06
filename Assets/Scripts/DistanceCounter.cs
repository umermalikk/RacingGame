using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DistanceCounter : MonoBehaviour {

	public Text scoreText;

	private int score;
	private MoveBackground track;

	private Animator animator;
	
	// Use this for initialization
	void Start () {
		score = 0;
		track = (MoveBackground) FindObjectOfType(typeof(MoveBackground));
		InvokeRepeating("updateScore", 1.0f, 0.1f);

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	public int GetScore() {
		return score;
	}

	private void updateScore() {
		score += (int) track.speed;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			float playerPos = gameObject.transform.position.x;
			float enemyPos = col.gameObject.transform.position.x;

			playerPos = Truncate(playerPos);
			enemyPos = Truncate(enemyPos);

			float difference = 0.0f;
			if (enemyPos > playerPos) {
				difference = Mathf.Abs(enemyPos - playerPos);
			} else if (playerPos > enemyPos) {
				difference = Mathf.Abs(playerPos - enemyPos);
			}

			difference = Truncate(difference);

			if (difference < 0.60 || difference > 0.74)
				GameOver();

		}
	}

	private float Truncate(float value) {
		int left = (int) value;
		int right = (int) ((value * 100.0));

		if (right > 99)
			right %= 100;

		return (float) left + (float) (right / 100.0f);
	}

	private void GameOver() {
		print(score);
		animator.SetBool("car_explode", true);
		PlayerPrefs.SetInt("score", score);
		Destroy(gameObject);
		SceneManager.LoadScene("score");
	}

}
