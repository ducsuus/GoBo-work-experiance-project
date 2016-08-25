using UnityEngine;
using System;
using System.Collections;

public class InvaderScript : MonoBehaviour {

	// Speed of invader
    public float speed = 1.0f;

    // Health of invader
    public int health = 100;

    // The object which the invader is currently attracted to
    public GameObject attraction;

    // The closest point at which the invader will still move towards its attraction
    public float closestApproach = 10.0f;

    // Explosion effect (particle system)
    public GameObject explosionPrefab;

    // Bullet Speed
    public float bulletSpeed = 100.0f;

    //Fire Rate
    public float bulletTime = 4.0f;

    //Bullet Prefab
    public GameObject InvaderBulletPrefab;

    //Bullet Origin
    public GameObject InvaderBulletOrigin;

    //Invader Scale (Bit Like A Level?)
    public int InvaderScale; 

    //Invader Spawn Point
    public GameObject InvaderSpawn;

	// Use this for initialization
	void Start () {

		InvokeRepeating("Shoot", 0, bulletTime);

		this.transform.localScale = new Vector3(InvaderScale, InvaderScale, InvaderScale); //SET SIZE\

		this.health = InvaderScale * 25;

		this.speed = InvaderScale / 12;
	
	}

	void Shoot () { // Pew Pew

        // Fancy rotation
        //Quaternion rotation = Quaternion.Euler(this.GetShootingAngle(), 90, 0);
        Quaternion rotation = Quaternion.Euler(this.GetShootingAngle(), this.InvaderBulletOrigin.transform.rotation.eulerAngles.y, this.InvaderBulletOrigin.transform.rotation.eulerAngles.z);

        Debug.Log("Rotation y: " + this.InvaderBulletOrigin.transform.rotation.y);

        // Fancy bullet
		GameObject bullet = (GameObject) MonoBehaviour.Instantiate(this.InvaderBulletPrefab, this.InvaderBulletOrigin.transform.position, rotation); 

		// Fancy speed
	    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up.normalized * this.bulletSpeed;

	    // Change bullet damage
	    bullet.GetComponent<InvaderBulletScript>().BulletDamage = this.InvaderScale / 10;

	}
	
	// Update is called once per frame
	void Update () {

		if(this.attraction == null)
			return;

		// Direction to travel in
		Vector3 direction = this.attraction.transform.position - this.transform.position;

		// We don't want to move unless we are a certain distance away from the player
		if(direction.magnitude > closestApproach){

			// Rotate to face the target (this should be step based at some point?)
			this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, 100.0f, 0.0f));

			// We want to move forwards, with the our spped, dependent on the length of frame
	        Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f) * this.speed * Time.deltaTime;

	        // Move invader
	        transform.Translate(movement);



		}
	
	}

	public bool Hit(int damage){

		// Take the damage
		this.health -= damage;

		// If health less than 0 invader is dead
		if (this.health <= 0){

			// Destroy self in 0.4 second
			Destroy(this.gameObject, 0.1f);

			// Particle effects (?)
			Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation);

			// Total invader count - 1
			InvaderSpawn.GetComponent<EnemySpawnScript>().NoInvadersAlive--;

			// Enemy destroyed
			return true;

		} 

		// Enemy not destroyed
		return false;

	}

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
    	float u = this.bulletSpeed;
    	//float u = 10.0f;

    	// Gravity (should be dynamic at some point -> physics.gravity?)
    	float g = 9.81f;

    	/* REMEMBER JOE THERE IS A PLUS OR MINUS HERE WE ARE USING PLUS RIGHT NOW BUT IT MAKES NOT A SENSE IF WE HAVE TWO CASES WHERE ONE MIGHT BE BROKE */

    	//                 --> \/ <-- Plus or minus goes here
    	double tanAlpha = ( -d + Math.Sqrt( Math.Pow(d, 2) + 2 * h * g * Math.Pow(d, 2) / Math.Pow(u, 2) - Math.Pow(g, 2) * Math.Pow(d, 4) / Math.Pow(u, 4) ) ) / ( -1 * g * Math.Pow(d, 2) / Math.Pow(u, 2) );

    	// Correct
    	float alpha = Mathf.Rad2Deg * Mathf.Atan((float) tanAlpha);

    	Debug.Log("tanAlpha: " + tanAlpha);
    	Debug.Log("d: " + d + " h: " + h + " u: " + u + " g: " + g);

    	Debug.Log("Square root: " +  (Math.Pow(d, 2) + 2 * h * g * Math.Pow(d, 2) / Math.Pow(u, 2) - Math.Pow(g, 2) * Math.Pow(d, 4) / Math.Pow(u, 4) ));
    	Debug.Log("Without minus: " +  (Math.Pow(d, 2) + 2 * h * g * Math.Pow(d, 2) / Math.Pow(u, 2) ));
    	Debug.Log("Minus part: " +  (Math.Pow(g, 2) * Math.Pow(d, 4) / Math.Pow(u, 4)));

    	return 90.0f - alpha;

    }
}
