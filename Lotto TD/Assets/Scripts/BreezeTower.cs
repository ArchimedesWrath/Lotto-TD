using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreezeTower : MonoBehaviour {

	private Transform smallRing;
	private Transform bigRing;

	// Use this for initialization
	void Start () {
		smallRing = this.gameObject.transform.GetChild(2);
		bigRing = this.gameObject.transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		smallRing.RotateAround(smallRing.position, smallRing.forward, Time.deltaTime * 90f);
		bigRing.RotateAround(smallRing.position, smallRing.forward, Time.deltaTime * -90f);
	}
}