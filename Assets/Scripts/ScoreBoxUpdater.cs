using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoxUpdater : MonoBehaviour {

	public GameObject Player; // Finds the Player, in order to find its Score

	public Text ScoreDisplay;

	
	// Update is called once per frame
	void Update () {
	
		ScoreDisplay.text = ""+Player.GetComponent<PlayerScript>().playerScore; // Displays the player Score, fetching it from PlayerScript

	}
}
