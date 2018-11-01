using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: CLEAN UP THIS SCRIPT!!!
public class Player : MonoBehaviour {
	List<GameObject> lowTowers = new List<GameObject>();
	public GameObject tower1;
	public GameObject tower2;
	public GameObject tower3;
	public GameObject tower4;
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
		lowTowers.Add(tower1);
		lowTowers.Add(tower2);
		lowTowers.Add(tower3);
		lowTowers.Add(tower4);
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
		Debug.Log("Setting current node at: " + node.transform.position.x + ", " + node.transform.position.z);
		currentNode = node;
	}

	public void ChoseRandomTower() {
		int randIndex = UnityEngine.Random.Range(0, lowTowers.Count - 1);
		this.BuildTower(lowTowers[randIndex]);
	}

	void BuildTower(GameObject tower) {
		Transform pos = tower.transform.GetChild(0).gameObject.transform;
		Vector3 newPos = new Vector3(0f, pos.localScale.y / 2 + currentNode.transform.localScale.y / 2, 0f);
		tower = (GameObject)Instantiate(tower, currentNode.transform.position + newPos, currentNode.transform.rotation);
	}
}
