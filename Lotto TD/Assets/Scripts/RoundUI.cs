using UnityEngine;
using UnityEngine.UI;

public class RoundUI : MonoBehaviour {

	public Text roundText;
	void Update () {
		roundText.text = "Round: " + GameManager.Round.ToString();
	}
}
