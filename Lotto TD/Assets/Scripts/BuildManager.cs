using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance; 

	public Player player;
	private GameObject tower;

	private List<GameObject> towerList = new List<GameObject>();
	public GameObject tower_1;
	public GameObject tower_2;

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
		player = gameObject.GetComponent("Player") as Player;
		towerList.Add(tower_1);
		towerList.Add(tower_2);
	}

	public void ChoseRandomTower() {
		
		if (player.GetComponent<Node>().tower != null) {
			Debug.Log("This node already has a tower!");
			return;
		}
		int randIndex = UnityEngine.Random.Range(0, towerList.Count);
		this.BuildTower(towerList[randIndex]);
		
	}

	void BuildTower(GameObject tower) {
		player.GetComponent<Node>().SetCurrentTower(tower);

		float towerHeight = tower.transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;
		float nodeHeight = player.GetComponent<Node>().GetComponent<Renderer>().bounds.size.y;
		Vector3 newPos = new Vector3(0f, towerHeight / 2 + nodeHeight, 0);
		Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
		tower = (GameObject)Instantiate(tower, player.GetComponent<Node>().transform.position + newPos, rotation);
	}
}
