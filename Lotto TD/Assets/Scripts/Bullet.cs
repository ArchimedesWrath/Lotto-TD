using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 7.5f;
	// Use this for initialization
	public GameObject particle;
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
		Destroy(this.gameObject);
	}
}
