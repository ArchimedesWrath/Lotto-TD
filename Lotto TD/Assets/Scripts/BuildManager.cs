using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance; 
	private Node currentNode;
	public static Tower CurrentTower;

	private List<Tower> towerList = new List<Tower>();
	public Tower tower_1;
	public Tower tower_2;

	public TowerBuilderUI builderUI;
	public TowerUI towerUI;
	public TowerStatsUI towerStatsUI;
	void Awake() {
		// Every time we start the game, instantiate one and only one Player that can 
		// be accessed from anywhere.
		if (instance != null)  {
			return;
		}
		instance = this;
	}
	void Start () {
		currentNode = null;
		CurrentTower = null;
		towerList.Add(tower_1);
		towerList.Add(tower_2);
	}

	public void ChoseRandomTower() {
		
		if (currentNode.HasTower()) {
			Debug.Log("This node already has a tower!");
			return;
		}
		int randIndex = UnityEngine.Random.Range(0, towerList.Count);
		this.BuildTower(towerList[randIndex], currentNode);
		
	}

	public void BuildTower(Tower tower, Node node) {
		node.SetCurrentTower(tower);

		float towerHeight = tower.transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;
		float nodeHeight = node.GetComponent<Renderer>().bounds.size.y;
		Vector3 newPos = new Vector3(0f, towerHeight / 2 + nodeHeight, 0);
		Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
		Instantiate(tower.gameObject, node.transform.position + newPos, rotation);
	}

	public void SetCurrentNode(Node node) {
		currentNode = node;
		towerUI.Hide();
		towerStatsUI.Hide();
		builderUI.Show();
	}

	public void SetCurrentTower(Tower tower) {
		CurrentTower = tower;
		builderUI.Hide();
		towerStatsUI.Show();
		towerUI.Show();
	}
}
