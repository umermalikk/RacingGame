using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject[] enemies;

	public float minWaitTime = 0.5f;
	public float maxWaitTime = 1.5f;

	private float limitPos = 1.93f;

	private GameObject enemy;
	private Vector3 enemyPosition;
    private int enemyIndex;
	private float currentPos = 0.0f;
	private float previousPos = 0.0f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnEnemy() {
		
		while (true) {

			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			
			if (enemies.Length > 0) {
				enemyIndex = Random.Range(0, (enemies.Length));

				do {
					currentPos = Random.Range(-limitPos, limitPos);
				} while(Mathf.Abs(currentPos - previousPos) <= 0.80);
				previousPos = currentPos;
				enemyPosition = new Vector3(currentPos, transform.position.y, transform.position.z);
				enemy = (GameObject) Instantiate (enemies[enemyIndex], enemyPosition, transform.rotation);
				DestroyObject(enemy, 6);
				/*if (Random.value > 0.5 && clone.GetComponent<AudioSource>())
					clone.GetComponent<AudioSource>().Play();*/
			}		
		}	
	}
}



