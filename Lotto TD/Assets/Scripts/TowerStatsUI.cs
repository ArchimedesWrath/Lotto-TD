using UnityEngine;
using UnityEngine.UI;

public class TowerStatsUI : MonoBehaviour {
	public GameObject ui;

	private Text rangeText;
	void Start () {
		ui.SetActive(false);
		rangeText = ui.transform.GetChild(2).gameObject.GetComponent<Text>();
		SetText();
	}

	public void SetText() {
		rangeText.text = "Display Text";
	}

	public void Hide() {
		ui.SetActive(false);
	}

	public void Show(Tower tower) {
		rangeText.text = "Range: " + tower.range.ToString("#");
		ui.SetActive(true);
	}
}
