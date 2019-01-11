using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public GameObject tower;
	private Color startColor;
	private Renderer rend;

	private Color[] originalColor;

	BuildManager buildManager;


	void Start() {
		if (rend == null) rend = GetComponent<Renderer>();
		StoreOriginalColor();
		tower = null;
		buildManager = BuildManager.instance;
	}

	private void StoreOriginalColor() {
		if (rend != null) {
			Material[] materials = rend.materials;
			originalColor = new Color[materials.Length];
			for(int i = 0; i < materials.Length; i++) {
				originalColor[i] = materials[i].color;
			}
		}
	}

	public bool HasTower() {
		if (tower) {
			return true;
		} 
		return false;
	}
	void OnMouseDown() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			if (!IPointerOverUIObject()) {

				// If user shift clicks a node add it to the group
				if (Input.GetKey(KeyCode.LeftShift)) {
					Debug.Log("This actually works!");

					if (tower == null) return;
					buildManager.SetSecondNode(this);
					return;
				}

				// Open up the tower info UI and set the player's current node to this node
			if (tower != null) buildManager.SetSecondNode(null);

			buildManager.SetSecondNode(null);
			buildManager.SetCurrentNode(this);
			}
		}
	}

	private bool IPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
	void OnMouseEnter() {
		if (!IPointerOverUIObject()) {
			if (rend != null) {
				Material[] materials = rend.materials;
				for (int i = 0; i < materials.Length; i++) {
					materials[i].color = hoverColor;
				} 
				rend.materials = materials;
			}
		}
	}

	void OnMouseExit() {
		if (rend != null) {
			Material[] materials = rend.materials;
			for (int i = 0; i < materials.Length; i++) {
				materials[i].color = originalColor[i];
			} 
			rend.materials = materials;
		}
	}

	public void SetCurrentTower(GameObject newTower) {
		tower = newTower;
	}
}
