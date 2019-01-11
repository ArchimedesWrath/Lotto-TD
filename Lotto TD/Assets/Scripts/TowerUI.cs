using UnityEngine;

public class TowerUI : MonoBehaviour {

	public GameObject ui;
	public GameObject CurrentTower;
	public TowerList TowerList;
	public CraftingList CraftingList;

	// Use this for initialization
	void Start () {
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

	public void OnCombineTowerPressed() {
		// When pressed loop through TowerList and compare it to Crafting Recipes
		//if (CanCraft) Instantiate Button with that crafting recipe, and Towers
		foreach(CraftingRecipe craftingRecipe in CraftingList.CraftingRecipes) {
			craftingRecipe.Craft(TowerList);
		}
	}
}
