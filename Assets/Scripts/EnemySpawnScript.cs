using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {
	
	public GameObject InvaderPrefab; // Prefab for Invader

	public GameObject InvaderSpawn; // Spawn for Invader

	// The object which the invader is currently attracted to
    public GameObject attraction;

	public float TimeDelay; // Time Between spawns

	public int WaveNumber = 1; // Initial Wave

	public int SpawnboxSize = 100;

	void Spawn () {

		Vector3 Postition = new Vector3 ((InvaderSpawn.transform.position.x + Random.Range(-SpawnboxSize, SpawnboxSize)), (InvaderSpawn.transform.position.y), (InvaderSpawn.transform.position.z + Random.Range(-SpawnboxSize, SpawnboxSize)));

		//InvaderScript invader = (InvaderScript) Instantiate(InvaderPrefab, Postition, Quaternion.identity); // Spawns the Invader

		GameObject invader = (GameObject) Instantiate(InvaderPrefab, Postition, Quaternion.identity); // Spawns the Invader - but better!

		InvaderScript script = invader.GetComponent<InvaderScript>();

		script.attraction = this.attraction;

	}

	void Wave () {

		for (int i=0; (i < (WaveNumber*3)); i++) {

			Spawn();

		}

		WaveNumber++;

	}

	void Start () {

		InvokeRepeating("Wave", 0, TimeDelay); // Controls Repetition
	
	}
}
