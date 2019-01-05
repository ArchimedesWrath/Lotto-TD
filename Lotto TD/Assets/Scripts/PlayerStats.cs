using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	private int startMoney = 2;
	private int startLives = 20;
	public static int Lives;
	public static int Money;

	// Use this for initialization
	void Start () {
		Lives = startLives;
		Money = startMoney;
	}
}
