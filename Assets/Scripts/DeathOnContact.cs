using UnityEngine;
using System.Collections;

public class DeathOnContact : MonoBehaviour {

	// Explosion effect (particle system)
    public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {

		Destroy(gameObject); // rip in peace
		
		Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation); // Particle effect

	}
}
