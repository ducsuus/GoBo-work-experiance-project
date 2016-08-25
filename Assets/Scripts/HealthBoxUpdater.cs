using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBoxUpdater : MonoBehaviour {

	public GameObject Player; // Finds the Player, in order to find its health

	public Text HealthDisplay;

	
	// Update is called once per frame
	void Update () {
	
		HealthDisplay.text = ""+Player.GetComponent<PlayerScript>().PlayerHealth; // Displays the player health, fetching it from PlayerScript

	}
}
