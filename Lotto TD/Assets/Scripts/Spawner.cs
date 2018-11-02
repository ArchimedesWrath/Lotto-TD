using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	public static Spawner instance;
	public Transform spawnPoint;
	public GameObject Enemy;
	public Text spawnTimerText;
	private float spawnTimer = 5.45f;
	public bool isSpawning = false;
	void Awake() {
		instance = this;
	}

	void Update() {

		if (GameManager.instance.GetEnemyCount() <= 0) {
			spawnTimerText.gameObject.SetActive(true);
			spawnTimerText.text = spawnTimer.ToString("0");
			if (spawnTimer <= 0) {
				StartCoroutine(SpawnEnemies());
				spawnTimer = 5.45f;
				GameManager.instance.SetEnemyCount(5);
				GameManager.instance.NextRound();
			}
			spawnTimer -= Time.deltaTime;
		} else {
			spawnTimerText.gameObject.SetActive(false);
		}

	}

	IEnumerator SpawnEnemies() {
		for (int i = 0; i < 5; i++) {
			Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
			yield return new WaitForSeconds(0.5f);
		}
	
	}
}
