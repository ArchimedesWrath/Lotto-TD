using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public Transform target;
	public GameObject DamageParticle;
	public int damage = 4;
	public float range = 4.0f;
	public float attackSpeed = 1f;
	public int tier = 1;
	public float fireCountDown = 0f;
	void Start () {

	}
	public virtual void Update () {
		fireCountDown -= Time.deltaTime;
		if (fireCountDown <= 0) {
			this.Attack();
			fireCountDown = 1 / attackSpeed;
		}
	}

	public virtual void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, range);
	}

	public virtual void Attack() {

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

		if (target == null) return;
		// Now actually attack the enemy (maybe fix this to be better)
		Enemy targetedEnemy = target.gameObject.GetComponent<Enemy>();
		targetedEnemy.Damage(damage);
		if (DamageParticle) {
			GameObject damageParticle = (GameObject)Instantiate(DamageParticle, target.transform.position, target.transform.rotation);
			damageParticle.gameObject.GetComponent<DamageParticle>().SetAliveTime(attackSpeed - 0.05f);
			targetedEnemy.DamageParticle = damageParticle;		
		} 
	}
}
