using UnityEngine;
using System.Collections;

public class Despawn : MonoBehaviour {

	public int Time = 5;

	// Use this for initialization
	void Start () {

		Destroy(gameObject, Time);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
