using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	void Start () {

        Debug.Log("We started");
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter (Collision collider){

        if(collider.gameObject.tag == "Enemy"){

            Debug.Log("Noot noot");

        }

    }

}
