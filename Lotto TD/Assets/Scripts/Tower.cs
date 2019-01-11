using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	private Transform target;
	public GameObject bullet;
	public float range = 4.0f;
	public float fireRate = 1f;
	private float fireCountDown = 0f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) return;

		// Rotate tower to face enemy
		/*
		Vector3 dir = this.transform.position - target.position;
		Quaternion lookRot = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(this.transform.rotation, lookRot, Time.deltaTime).eulerAngles;
		this.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		*/

		// Logic to fire bullet, similar to countdown logic in wave spawner
		fireCountDown -= Time.deltaTime;
		if (fireCountDown <= 0) {
			this.Shoot();
			fireCountDown = 1 / fireRate;
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, range);
	}

	void Shoot() {
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
