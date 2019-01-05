using UnityEngine;
using UnityEngine.UI;

public class RoundTimerUI : MonoBehaviour {

	public Text roundTimer;

	void Update () {
		if (Spawner.isWaiting) {
			roundTimer.text = "Round Start: " + Spawner.SpawnTimer.ToString("0");
		} else {
			roundTimer.text = "Round End: " + GameManager.RoundTimer.ToString("0");
		}	
	}
}
