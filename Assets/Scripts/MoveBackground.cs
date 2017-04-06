using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

	public float speed = 1.5f;

	Vector2 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
