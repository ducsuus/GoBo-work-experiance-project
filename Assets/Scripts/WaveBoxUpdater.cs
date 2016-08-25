using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveBoxUpdater : MonoBehaviour {

	public GameObject InvaderSpawn; // Finds the Player, in order to find its health

	public Text WaveDisplay;

	
	// Update is called once per frame
	void Update () {
	
		WaveDisplay.text = ""+InvaderSpawn.GetComponent<EnemySpawnScript>().WaveNumber; // Displays the player health, fetching it from PlayerScript

	}
}
