using UnityEngine;
using System;
using System.Collections;

public class TestShootScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject attraction;

	// Speed of bullet -> Currently used as force multiplier
    public float speed = 100.0f;

	// How long between bullets
    public float delayTime = 0.1f;

    private bool canFire = true;

    float GetShootingAngle(){

    	// x distance
    	float xDistance = transform.position.x - this.attraction.transform.position.x;
    	// y distance
    	float yDistance = transform.position.y - this.attraction.transform.position.y;
    	// z distance
    	float zDistance = transform.position.z - this.attraction.transform.position.z;

    	// Horizontal distance
    	float d = (float) Math.Sqrt( Math.Pow(xDistance, 2) + Math.Pow(zDistance, 2) );

    	// Vertical distance
    	float h = yDistance;

    	// Starting speed
    	float u = this.speed;

    	// Gravity (should be dynamic at some point -> physics.gravity?)
    	float g = 9.81f;

    	/* REMEMBER JOE THERE IS A PLUS OR MINUS HERE WE ARE USING PLUS RIGHT NOW BUT IT MAKES NOT A SENSE IF WE HAVE TWO CASES WHERE ONE MIGHT BE BROKE */

    	//                 --> \/ <-- Plus or minus goes here
    	double tanAlpha = ( -d + Math.Sqrt( Math.Pow(d, 2) + 2 * h * g * Math.Pow(d, 2) / Math.Pow(u, 2) - Math.Pow(g, 2) * Math.Pow(d, 4) / Math.Pow(u, 4) ) ) / ( -1 * g * Math.Pow(d, 2) / Math.Pow(u, 2) );

    	// Correct
    	float alpha = Mathf.Rad2Deg * Mathf.Atan((float) tanAlpha);

    	Debug.Log("tanAlpha: " + alpha);
    	Debug.Log("d: " + d + " h: " + h + " u: " + u + " g: " + g);

    	return 90.0f - alpha;

    }

	void Update () {

		if (this.canFire){

			//Quaternion rotation = Quaternion.Euler(90 - this.GetShootingAngle(), 90, 0);
			Debug.Log("Rotation = " + this.GetShootingAngle());
			Quaternion rotation = Quaternion.Euler(this.GetShootingAngle(), 90, 0);
			//Quaternion rotation = Quaternion.Euler(0, 0, 0);

			GameObject bullet = (GameObject) MonoBehaviour.Instantiate(bulletPrefab, this.transform.position, rotation); 

		    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up.normalized * this.speed;

		    // Make sure we set the shooting timeout
		    this.FireTimeout();

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
