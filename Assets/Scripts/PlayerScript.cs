using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// defines initial health
	public int PlayerHealth = 100;

	public int playerScore = 0;

	void Start () {

		Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update () {

	}
}
