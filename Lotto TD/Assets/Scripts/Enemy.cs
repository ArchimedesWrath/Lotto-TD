using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 2.5f;
	private Transform target;
	private int CheckPointIndex = 0;
	public int health = 10;

	public GameObject particle;
	// Use this for initialization
	void Start () {
		target = CheckPoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {

		if (this.health <= 0 ) this.Die();
		this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);

		if (Vector3.Distance(this.transform.position, target.position) <= 0.2f) {
			this.GetCheckPoint();
		}
	}

	void GetCheckPoint() {
		if (CheckPointIndex >= CheckPoints.points.Length - 1) {
			CheckPointIndex = 0;
		} else {
			CheckPointIndex++;
		}
		this.SetTarget();
	}

	void SetTarget() {
		target = CheckPoints.points[CheckPointIndex];
	}

	public void Die() {
		GameObject effectPart = (GameObject)Instantiate(particle, this.transform.position, this.transform.rotation);
		Destroy(effectPart, 1.5f);
		GameManager.instance.RemoveEnemy();
		Destroy(this.gameObject);
	}

	public void Damage(int dps) {
		Debug.Log(dps + " damage was applied to this GameObject.");
		this.health -= dps;

		if (this.health <= 0 ) this.Die();
	}
}
