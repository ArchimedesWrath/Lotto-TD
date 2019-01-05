using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	private float roundTime = 10.45f;

	public static float RoundTimer;
	public Text roundTimerText;

	private int startingRound = 1;
	public static int Round;

	private int enemyCount = 0;
	void Start () {
		instance = this;
		Round = startingRound;
		RoundTimer = roundTime;
	}
	
	void Update () {
		if (enemyCount > 0) {
			RoundTimer -= Time.deltaTime;
		} else {
			RoundTimer = roundTime;
		}

		if (RoundTimer <= 0 && enemyCount > 0) {
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
		Round++;
	}

	void DestroyAllEnemies() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject enemy in enemies) {
			int enemyHealth = enemy.gameObject.GetComponent<Enemy>().health;
			enemy.gameObject.GetComponent<Enemy>().Damage(enemyHealth);
			PlayerStats.Lives--;
		}

		enemyCount = 0;
	}
}
