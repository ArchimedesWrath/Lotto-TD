using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TowerAmount {
	public GameObject Tower;
	public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject {

	public List<TowerAmount> Materials;
	public GameObject Result;	
	public bool CanCraft(TowerList towers) {
		foreach(TowerAmount towerAmount in Materials) {
			Debug.Log("You need " + towerAmount.Amount + "of tower type: " +towerAmount.Tower);
			if (towers.TowerCount(towerAmount.Tower) < towerAmount.Amount) {
				Debug.Log("Cannot craft anything");
				return false;
			}
		}
		return true;
	}

	public void Craft(TowerList towers) {
		if (CanCraft(towers)) {
			foreach(TowerAmount towerAmount in Materials) {
				for (int i = 0; i < towerAmount.Amount; i++) {
					towers.RemoveTower(towerAmount.Tower);
				}
			}
			towers.AddTower(Result);
		}
	}
}
