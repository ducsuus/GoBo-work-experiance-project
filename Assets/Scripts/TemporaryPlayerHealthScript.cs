// This ENTIRE script should not be here, used as placeholder till PlayerScript is implemented.


using UnityEngine;
using System.Collections;

public class TemporaryPlayerHealthScript : MonoBehaviour {

	public int PlayerHealth = 20; // defines initial health
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {

		Debug.Log("Noot Nooot");

		if(col.gameObject.tag == "InvaderBullet") { // if hit by a bullet from enemy

			Debug.Log("Hope This Shows...");

			PlayerHealth--; //is currently subtract one, should include the damage of InvaderBullets

			if(PlayerHealth <= 0) { // is you's deaded yet?

				Debug.Log("Dead."); // Replace this with game over screen?
				Destroy(gameObject); // Murderkilling fun...

			}

		}
	
	}
}
