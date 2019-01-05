using UnityEngine;

public class TowerStatsUI : MonoBehaviour {
	public GameObject ui;
	void Start () {
		ui.SetActive(false);
	}

	public void Hide() {
		ui.SetActive(false);
	}

	public void Show() {
		ui.SetActive(true);
	}
}
