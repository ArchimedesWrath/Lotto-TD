using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 7.5f;
	// Use this for initialization
	public GameObject particle;
	private int damage = 5;
	public string appliedStatus = "SLOW";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			Destroy(this.gameObject);
			return;
		}

		Vector3 dir = this.transform.position - target.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			HitTarget();
			return;
		}
		
		if (target) this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
		
	}

	public void GetTarget(Transform _target) {
		target = _target;
	}

	void HitTarget() {
		GameObject effectPart = (GameObject)Instantiate(particle, this.transform.position, this.transform.rotation);
		Destroy(effectPart, 1.5f);
		// TODO: Make this legit
		
		if (target ) target.gameObject.GetComponent<Enemy>().Damage(this.damage, this.appliedStatus);
		Destroy(this.gameObject);
	}
}
