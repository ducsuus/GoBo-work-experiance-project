using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	Pistol pistol;

	private List<Tool> tools = new List<Tool>();

	void Start () {

		Pistol pistol = new Pistol();
		this.tools.add(pistol)

		pistol.OnOpen();
	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1")) {

			this.pistol.OnFire();

		}
	
	}
}

public class Tool {

	public Tool(){

		Debug.Log("Created tool");

	}

}

public class Pistol : Tool{

	// Speed of bullet -> Currently used as force multiplier
    public float speed = 100.0f;
    // Bullet prefab to use
    public GameObject bulletPrefab;
    // Bullet origin
    public GameObject bulletOrigin;

    public void OnOpen(){

    	Debug.Log("Pistol opened!");

    }
	
	public void OnFire () {

        // Instantiate bullet
        GameObject bullet = (GameObject) MonoBehaviour.Instantiate(bulletPrefab, bulletOrigin.transform.position, bulletOrigin.transform.rotation);

        // Give the bullet some force in the direction the bullet origin is "facing in" (up)
        Vector3 force = bulletOrigin.transform.up * speed;

        // Add the force
        bullet.GetComponent<Rigidbody>().AddForce(force);      
	
	}

}