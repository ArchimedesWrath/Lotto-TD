using UnityEngine;

public class BuildTower : MonoBehaviour {
	public GameObject tower;
	public void PurchaseRandomTowerLow() {
		Debug.Log("Random low tower purchased");
		//TODO: Create random way of chosing different towers
		Player.instance.ChoseRandomTower();
	}

	public void PurchaseRandomTowerMed() {
		Debug.Log("Random mid tower purchased");
	}

	public void PurchaseRandomTowerHigh() {
		Debug.Log("Random high tower purchased");
	}
}
