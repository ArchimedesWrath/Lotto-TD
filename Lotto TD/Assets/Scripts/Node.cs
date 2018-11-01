using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public GameObject tower;
	private Color startColor;
	private Renderer rend;


	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseDown() {
		if (tower != null) {
			// Open up the tower info UI

			// Set the player's current node to this node
			return;
		}

		//TODO: Open up tower builder UI here
		// For right now we will just spawn a tower here.
		Player.instance.SetCurrentNode(this.gameObject);
	}
	void OnMouseEnter() {
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
