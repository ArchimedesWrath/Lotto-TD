using UnityEngine;

public class RotateTower : SingleTargetTower {
	public GameObject partToRotate;
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	public override void Update () {
		if (target == null) return;

		Vector3 dir = this.transform.position - target.position;
		Quaternion lookRot = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRot, Time.deltaTime).eulerAngles;
		partToRotate.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		fireCountDown -= Time.deltaTime;
		if (fireCountDown <= 0) {
			this.Attack();
			fireCountDown = 1 / attackSpeed;
		}
		
	}
	public override void Attack() {
		GameObject bulletGo = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
		Bullet _bullet = bulletGo.GetComponent<Bullet>();
		if(bullet != null) _bullet.GetTarget(target);
	}
	void UpdateTarget() {
		// Distance checks take computatinoal power so we should do this less than every frame.
		// Getting every enemy is going to be taxing on the system.
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
	}
}
