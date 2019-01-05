using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TowerAmount {
	public Tower Tower;
	public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject {

	public List<TowerAmount> Materials;
	public Tower Result;	
	public bool CanCraft(TowerList towers) {
		foreach(TowerAmount towerAmount in Materials) {
			if (towers.TowerCount(towerAmount.Tower) < towerAmount.Amount) {
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
