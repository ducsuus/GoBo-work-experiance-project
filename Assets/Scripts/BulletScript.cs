using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public int bulletDamage = 25;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter (Collision collider){

    	// If we hit an invader -> this could be a generic mob property, but in this case is not worth implementing (? -> we can only have one tag, how can we see if another thing hit is derived from mob classy thing?)
        if(collider.gameObject.tag == "Invader"){

            // Get the instance of invader script
            InvaderScript invaderScript = collider.gameObject.GetComponent<InvaderScript>();

            // Hit the invader
            invaderScript.Hit(this.bulletDamage);

        }

    }

}
