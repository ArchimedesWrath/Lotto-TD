using UnityEngine;

public class TowerUI : MonoBehaviour {

	public GameObject ui;
	public Tower CurrentTower;
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
		CurrentTower = BuildManager.CurrentTower;
		ui.SetActive(true);
	}

	public void CombineTowerPressed() {
		ui.transform.GetChild(0).gameObject.SetActive(false);

		// Now check the recpies and tower lists to populate this GO with buttons. 

		OnCombineTowerPressed();
		ui.transform.GetChild(1).gameObject.SetActive(true);
	}

	public void OnCombineTowerPressed() {
		// When pressed loop through TowerList and compare it to Crafting Recipes
		//if (CanCraft) Instantiate Button with that crafting recipe, and Towers
		foreach(CraftingRecipe craftingRecipe in CraftingList.CraftingRecipes) {
			craftingRecipe.Craft(TowerList);
		}
	}
}
