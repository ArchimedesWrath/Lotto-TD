using UnityEngine;

public class AoeTower : Tower {
	public override void Attack() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		foreach(GameObject enemy in enemies) {
				float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance && distanceToEnemy <= range) {
					// Damage the enemy
					enemy.gameObject.GetComponent<Enemy>().Damage(damage);
					//Instantiate(AttackParticle, enemy.transform.position, enemy.transform.rotation);
				}
			}
	}
}
