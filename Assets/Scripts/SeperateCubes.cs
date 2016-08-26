using UnityEngine;
using System.Collections;

public class SeperateCubes : MonoBehaviour {

	public float tension = 1; // Sets force between cubes

	// Update is called once per frame
	void Update () {

		Debug.Log(this.transform.parent);
	
	}

	void OnCollisionEnter (Collision col) {

		this.transform.parent = null; // Breaks away from group

		Destroy(this.gameObject, 1f);

	}
}
