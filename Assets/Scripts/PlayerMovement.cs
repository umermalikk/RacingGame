using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Vector2 position;

	public float speed;

	private bool speedUp = false;
	private float limitPos = 1.93f;

	private MoveBackground track;
	private SpawnEnemies enemySpan;
	
	void Start () {
		track = (MoveBackground) FindObjectOfType(typeof(MoveBackground));
		enemySpan = (SpawnEnemies) FindObjectOfType(typeof(SpawnEnemies));
		position = transform.position;
    }
	
	void FixedUpdate () {
		position.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		position.x = Mathf.Clamp(position.x, -limitPos, limitPos);

		transform.position = position;

		speedUp = Input.GetKey ("up") ? true : false;

		if (speedUp) {
			track.speed = 3.0f;
			enemySpan.maxWaitTime = 0.5f;
		} else {
			track.speed = 1.5f;
			enemySpan.maxWaitTime = 1.5f;
		}
	}

}

