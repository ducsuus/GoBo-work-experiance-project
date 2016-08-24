using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SMG : Tool{

	// Speed of bullet -> Currently used as force multiplier
    public float speed = 100.0f;
    // Bullet prefab to use
    public GameObject bulletPrefab;
    // Bullet origin
    public GameObject bulletOrigin;

    // How long between bullets
    public float delayTime = 0.1f;

    private bool canFire = true;
	
	public override void OnFireHold () {

        if(this.canFire){

            // Instantiate bullet
            GameObject bullet = (GameObject) MonoBehaviour.Instantiate(bulletPrefab, bulletOrigin.transform.position, bulletOrigin.transform.rotation);

            // Give the bullet some force in the direction the bullet origin is "facing in" (up)
            Vector3 force = bulletOrigin.transform.up * speed;

            // Add the force
            bullet.GetComponent<Rigidbody>().AddForce(force);      

            // Make sure we set the shooting timeout
            SetCanFire();

        }
	
	}

    private void FireTimeout(){

        this.canFire = false;

        StartCoroutine(this.SetCanFire());

    }

    IEnumerator SetCanFire() {

        yield return new WaitForSeconds(this.delayTime);

        this.canFire = true;
    }

}