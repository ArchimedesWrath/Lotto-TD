using UnityEngine;

public class SingleTargetTower : Tower {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}

	public override void Attack() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach(GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if(nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}

		if (bullet) {
			GameObject bulletGo = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
			Bullet _bullet = bulletGo.GetComponent<Bullet>();
			if(bullet != null) _bullet.GetTarget(target);
		}
	}
}
