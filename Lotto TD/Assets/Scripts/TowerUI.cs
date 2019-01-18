using UnityEngine;

public class TowerUI : MonoBehaviour {

	public GameObject ui;
	public GameObject CurrentTower;
	public TowerList TowerList;
	public CraftingList CraftingList;
	BuildManager buildManager;

	// Use this for initialization
	void Start () {
		buildManager = BuildManager.instance;
		CurrentTower = null;
		ui.SetActive(false);
	}

	public void Hide() {
		ui.SetActive(false);
	}

	public void Show() {
		CurrentTower = BuildManager.currentNode.tower;
		ui.SetActive(true);
	}

	public void OnSellPressed() {
		buildManager.SellTower();
	}

	public void OnCombineTowerPressed() {
		// When pressed loop through TowerList and compare it to Crafting Recipes
		//if (CanCraft) Instantiate Button with that crafting recipe, and Towers
		if (buildManager.GetSecondNode() == null) {
			Debug.Log("You need more than at least 2 towers to combine!");
			return;
		}

		TowerList.AddNode(buildManager.GetCurrentNode());
		TowerList.AddNode(buildManager.GetSecondNode());
		foreach(CraftingRecipe craftingRecipe in CraftingList.CraftingRecipes) {
			craftingRecipe.Craft(TowerList);
		}
	}
}
