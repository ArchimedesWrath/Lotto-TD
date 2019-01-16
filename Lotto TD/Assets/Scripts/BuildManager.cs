using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance; 
	public static Node currentNode;

	public Node SecondNode;

	public List<Tower> buildList = new List<Tower>();

	public TowerList TowerList;

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
	}

	public void ChoseRandomTower() {
		
		if (currentNode.HasTower()) {
			Debug.Log("This node already has a tower!");
			return;
		}
		int randIndex = UnityEngine.Random.Range(0, buildList.Count);
		Tower towerToBuild = buildList[randIndex];
		this.BuildTower(towerToBuild.gameObject, currentNode);
		
	}

	public void BuildTower(GameObject towerGameObject, Node node) {
		
		TowerList.AddNode(node);
		float towerHeight = towerGameObject.transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;
		float nodeHeight = node.GetComponent<Renderer>().bounds.size.y;
		Vector3 newPos = new Vector3(0f, towerHeight / 2 + nodeHeight, 0);
		Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
		GameObject newTower = (GameObject)Instantiate(towerGameObject, node.transform.position + newPos, rotation);
		node.SetCurrentTower(newTower);
		TowerStatsUI();
	}

	public void SetCurrentNode(Node node) {
		if (currentNode) TowerList.RemoveNode(currentNode);
		if (node.tower) {
			TowerList.AddNode(node);
			TowerStatsUI();
		} else {
			BuildingUI();
		}
		currentNode = node;
	}

	public void SetSecondNode(Node node) {
		if (SecondNode) TowerList.RemoveNode(SecondNode);
		if (node && node.tower) TowerList.AddNode(node);
		SecondNode = node;
	}

	public void SellTower() {
		currentNode.DestroyCurrentTower();
		BuildingUI();

	}

	private void TowerStatsUI() {
		builderUI.Hide();
		towerUI.Show();
		towerStatsUI.Show(currentNode.towerObject);
	}

	private void BuildingUI() {
		towerUI.Hide();
		towerStatsUI.Hide();
		builderUI.Show();
	}
}
