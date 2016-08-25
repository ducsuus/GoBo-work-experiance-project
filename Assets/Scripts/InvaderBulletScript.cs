using UnityEngine;
using System.Collections;

public class InvaderBulletScript : MonoBehaviour {

	public int BulletDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "Player") { // if hit by a bullet from enemy

			PlayerScript playerScript = col.gameObject.GetComponent<PlayerScript>();

			playerScript.PlayerHealth -= BulletDamage; // player takes damage from bullets

			if(playerScript.PlayerHealth <= 0) { // is you's deaded yet?

				Destroy(col.gameObject); // rip in peace
			}
		}
	}
}
