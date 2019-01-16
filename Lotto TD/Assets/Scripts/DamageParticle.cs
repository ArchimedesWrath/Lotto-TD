using UnityEngine;

public class DamageParticle : MonoBehaviour {
	public float aliveTime;

	void Start() {
	}

	void Update() {
		aliveTime -= Time.deltaTime;
		if (aliveTime < 0) {
			Die();
		}
	}

	public void SetAliveTime(float time) {
		aliveTime = time;
	}

	public void Die() {
		Debug.Log("Destroying This particle");
		Destroy(this.gameObject);
	}
}
