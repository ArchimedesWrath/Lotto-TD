using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject Enemy;
	private float spawnTime = 5.45f;
	public static float SpawnTimer;
	public static bool isWaiting;
	private bool isGameStart = true;
	void Start() {
		SpawnTimer = spawnTime;
		isWaiting = false;
	}

	void Update() {
		if (GameManager.instance.GetEnemyCount() <= 0) {
			isWaiting = true;
			SpawnTimer -= Time.deltaTime;
			if (SpawnTimer <= 0) {
				StartCoroutine(SpawnEnemies());
				SpawnTimer = spawnTime;
				isWaiting = false;
				GameManager.instance.SetEnemyCount(5);
				if (!isGameStart) 
					GameManager.instance.NextRound();
				else 
					isGameStart = false;
			}
		} 
	}

	IEnumerator SpawnEnemies() {
		for (int i = 0; i < 5; i++) {
			Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
			yield return new WaitForSeconds(0.5f);
		}
	
	}
}
