using UnityEngine;
using System.Collections;

public class InvaderScript : MonoBehaviour {

    public float speed = 1.0f;

    public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movement = new Vector3(0.0f, -speed, 0.0f) * Time.deltaTime;

        transform.Translate(movement);
	
	}
}
