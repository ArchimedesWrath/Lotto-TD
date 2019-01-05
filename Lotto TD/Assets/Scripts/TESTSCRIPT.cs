using UnityEngine;

public class TESTSCRIPT : MonoBehaviour {

	public GameObject button;

	void Start() {
		for (int i = 0; i < 12; i ++) {
			Instantiate(button, transform, false);
		}
	}
}
