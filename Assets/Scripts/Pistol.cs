using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pistol : Tool{

	// Speed of bullet -> Currently used as force multiplier
    public float speed = 100.0f;
    // Bullet prefab to use
    public GameObject bulletPrefab;
    // Bullet origin
    public GameObject bulletOrigin;

    public override void OnOpen(){

    	Debug.Log("Pistol opened!");

    }

    public override void OnClose(){

    	Debug.Log("Pistol opened!");

    }
	
	public override void OnFire () {

		Debug.Log("Pistol fired");

        // Instantiate bullet
        GameObject bullet = (GameObject) MonoBehaviour.Instantiate(bulletPrefab, bulletOrigin.transform.position, bulletOrigin.transform.rotation);

        // Give the bullet some force in the direction the bullet origin is "facing in" (up)
        Vector3 force = bulletOrigin.transform.up * speed;

        // Add the force
        bullet.GetComponent<Rigidbody>().AddForce(force);      
	
	}

}