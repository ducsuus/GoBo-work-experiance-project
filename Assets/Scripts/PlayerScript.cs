using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// defines initial health
	public int PlayerHealth = 20;

	void Start () {

		Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update () {

		}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "InvaderBullet") { // if hit by a bullet from enemy

			PlayerHealth--; //is currently subtract one, should include the damage of InvaderBullets

			if(PlayerHealth <= 0) { // is you's deaded yet?

				Destroy(gameObject); // rip in peace
	
			}
		}

	}
}
