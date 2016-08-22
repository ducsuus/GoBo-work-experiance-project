using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    // Speed of bullet -> Currently used as force multiplier
    public float speed = 100.0f;
    // Bullet prefab to use
    public GameObject bulletPrefab;
    // Bullet origin
    public GameObject bulletOrigin;

	void Start () {
	
	}
	
	void Update () {
        
        // Check for fire 1 button down + temporary automatic fire (because fun)
        if (Input.GetButtonDown("Fire1")) {// || Input.GetButton("Fire1")) {

            // Instantiate bullet
            GameObject bullet = (GameObject) Instantiate(bulletPrefab, bulletOrigin.transform.position, bulletOrigin.transform.rotation);

            // Give the bullet some force in the direction the bullet origin is "facing in" (up)
            Vector3 force = bulletOrigin.transform.up * speed;

            // Add the force
            bullet.GetComponent<Rigidbody>().AddForce(force);

        }
	
	}
}
