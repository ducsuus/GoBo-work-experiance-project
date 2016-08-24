﻿using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {
	
	public GameObject InvaderPrefab; // Prefab for Invader

	public GameObject InvaderSpawn; // Spawn for Invader

	// The object which the invader is currently attracted to
    public GameObject attraction;

	public float TimeDelay; // Time Between spawns

	public int WaveNumber = 1; // Initial Wave

	public int SpawnboxSize = 100;

	public int NoInvadersAlive; // No. Invaders Alive

	void Spawn () {

		Vector3 Postition = new Vector3 ((InvaderSpawn.transform.position.x + Random.Range(-SpawnboxSize, SpawnboxSize)), (InvaderSpawn.transform.position.y), (InvaderSpawn.transform.position.z + Random.Range(-SpawnboxSize, SpawnboxSize))); // Places it in random place in sky

		GameObject invader = (GameObject) Instantiate(InvaderPrefab, Postition, Quaternion.identity); // Spawns the Invader - but better!

		InvaderScript script = invader.GetComponent<InvaderScript>(); // Give it it's script

		script.InvaderScale = Random.Range(1,100); // Gives Invader a scale value

		script.attraction = this.attraction; // Sets Attraction to player <3

		script.InvaderSpawn = this.gameObject; // Sets spawn to object spawning it. 

		NoInvadersAlive++;

	}

	void Wave () {

		for (int i=0; (i < (WaveNumber*3)); i++) {

			Spawn();

		}

		WaveNumber++;

	}

	void Update () {

		// InvokeRepeating("Wave", 0, TimeDelay); // Controls Repetition
        if(NoInvadersAlive == 0) {
        	Wave();
        }

	}
}
