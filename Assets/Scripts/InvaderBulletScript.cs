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

			int PlayerHealth = col.gameObject.GetComponent<PlayerScript>().PlayerHealth;

			PlayerHealth -= BulletDamage; // player takes

			if(PlayerHealth <= 0) { // is you's deaded yet?

				//Destroy(col.gameObject); // rip in peace
			}
		}
	}
}
