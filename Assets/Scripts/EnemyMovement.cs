using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float minSpeed = 4.0f;
	public float maxSpeed = 10.0f;

	private float speed;

	// Use this for initialization
	void Start () {
		speed = -(Random.Range(minSpeed, maxSpeed));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
	}
}
