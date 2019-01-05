using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerList : MonoBehaviour {
	public List<Tower> Towers;

	public bool AddTower(Tower tower) {
		if (tower == null) {
			return false;
		}
		Towers.Add(tower);
		return true;
	}

    public bool Contains(Tower tower)
    {
        for (int i = 0; i < Towers.Count; i++) {
			if (Towers[i] == tower) {
				return true;
			}
		} 
		return false; 
    }

    public void RemoveTower(Tower tower) {
			Debug.Log("Tower being removed" + tower);
			Towers.Remove(tower);
	}

	public int Count () {
		return Towers.Count;
	}

	public int TowerCount(Tower tower) {
		int numTowers = 0;
		foreach (Tower presentTower in Towers) {
			if (tower == presentTower) numTowers++;
		} 
		return numTowers;
	}
}
