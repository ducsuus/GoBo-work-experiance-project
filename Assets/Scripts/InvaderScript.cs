using UnityEngine;
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
    public float bulletSpeed = 10.0f;

    //Fire Rate
    public float bulletTime = 4.0f;

    //Bullet Prefab
    public GameObject InvaderBulletPrefab;

    //Bullet Origin
    public GameObject InvaderBulletOrigin;

	// Use this for initialization
	void Start () {

		InvokeRepeating("Shoot", 0, bulletTime);
	
	}

	void Shoot () { // Pew Pew

		GameObject InvaderBullet = (GameObject) Instantiate(InvaderBulletPrefab, InvaderBulletOrigin.transform.position, InvaderBulletOrigin.transform.rotation); //Creates Instance Of Bullet

		Vector3 force = InvaderBulletOrigin.transform.forward * bulletSpeed * 1;	// Defines direction and magnitude of force

        InvaderBullet.GetComponent<Rigidbody>().AddForce(force); // Adds the force

	}
	
	// Update is called once per frame
	void Update () {

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
			Destroy(this.gameObject, 0.4f);

			// Particle effects (?)
			Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation);

			// Enemy destroyed
			return true;

		} 

		// Enemy not destroyed
		return false;

	}
}
