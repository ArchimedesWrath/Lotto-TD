using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject Enemy;
	// Use this for initialization
	public Text spawnTimerText;
	private float spawnTimer = 5;
	void Start () {
		
	}

	void Update() {
		spawnTimer -= Time.deltaTime;
		spawnTimerText.text = spawnTimer.ToString("0");
		this.CheckWave();
	}

	void CheckWave() {
		if (spawnTimer <= 0) {
			Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
			spawnTimer = 5;
		}
	}
}
