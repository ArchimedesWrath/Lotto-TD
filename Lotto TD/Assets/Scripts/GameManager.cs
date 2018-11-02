using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	private float roundTimer = 20.45f;
	public Text roundTimerText;
	public Text roundText;
	private int round = 0;

	private int enemyCount = 0;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		roundText.text = round.ToString();
		if (enemyCount > 0) {
			roundTimerText.gameObject.SetActive(true);
			roundTimerText.text = roundTimer.ToString("0");
			roundTimer -= Time.deltaTime;
		} else {
			roundTimer = 20.45f;
			roundTimerText.gameObject.SetActive(false);
		}

		if (roundTimer <= 0 && enemyCount > 0) {
			// Destroy all enemies and take lives from player;
			DestroyAllEnemies();
		}
	}

	public void SetEnemyCount(int count) {
		this.enemyCount = count;
	}

	public void RemoveEnemy() {
		this.enemyCount--;
	}

	public int GetEnemyCount() {
		return this.enemyCount;
	}
	public void NextRound() {
		this.round++;
	}

	void DestroyAllEnemies() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].GetComponent<Enemy>().Damage(10);
		}
		enemyCount = 0;
	}
}
