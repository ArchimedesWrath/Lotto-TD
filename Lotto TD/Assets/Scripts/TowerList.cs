using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerList : MonoBehaviour {
	public List<Node> Towers;

	BuildManager buildManager;

	void Start() {
		buildManager = BuildManager.instance;
	}

	public bool AddNode(Node node) {
		if (node.tower == null) {
			return false;
		}
		Towers.Add(node);
		return true;
	}

	public bool RemoveNode(Node node) {
		Towers.Remove(node);
		return true;
	}

	public bool AddTower(GameObject tower) {
		buildManager.BuildTower(tower, BuildManager.currentNode);
		return true;
	}

    public bool Contains(Node node)
    {
        for (int i = 0; i < Towers.Count; i++) {
			if (Towers[i] == node) {
				return true;
			}
		} 
		return false; 
    }

    public void RemoveTower(GameObject tower) {
			for(int i = 0; i < Towers.Count; i++) {
				if (Towers[i].tower.tag == tower.tag) {
					Debug.Log("Tower being removed" + tower);
					Destroy(Towers[i].tower.gameObject);
					Towers[i].tower = null;
					Towers.Remove(Towers[i]);
				}
			}
	}

	public int Count () {
		return Towers.Count;
	}

	public int TowerCount(GameObject tower) {
		int numTowers = 0;
		foreach (Node presentTower in Towers) {
			Debug.Log("Present tower: " + presentTower.tower);
			Debug.Log("Tower needed: " + tower);
			if (tower.tag == presentTower.tower.tag) numTowers++;
		} 
		return numTowers;
	}
}
