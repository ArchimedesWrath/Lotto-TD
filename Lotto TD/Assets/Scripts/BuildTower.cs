using UnityEngine;

public class BuildTower : MonoBehaviour {

	BuildManager buildManager;

	void Start() {
		buildManager = BuildManager.instance;
	}
	public void PurchaseRandomTowerLow() {
		//TODO: Create random way of chosing different towers
		buildManager.ChoseRandomTower();
	}

	public void PurchaseRandomTowerMed() {
	}

	public void PurchaseRandomTowerHigh() {
	}
}
