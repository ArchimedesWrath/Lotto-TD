using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: CLEAN UP THIS SCRIPT!!!
public class Player : MonoBehaviour {
	public static Player instance;
	public GameObject currentNode;
	void Awake() {
		// Every time we start the game, instantiate one and only one Player that can 
		// be accessed from anywhere.
		if (instance != null)  {
			Debug.Log("More than one Player in scene!");
			return;
		}
		instance = this;
	}
	void Start () {

	}
	public GameObject menu;
	private bool isShowing = false;
	// Test Update method for toggling UI elements.
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isShowing = !isShowing;
			menu.SetActive(isShowing);
		}
	}

	public void SetCurrentNode(GameObject node) {
		//Debug.Log("Setting current node at: " + node.transform.position.x + ", " + node.transform.position.z);
		currentNode = node;
	}
}
