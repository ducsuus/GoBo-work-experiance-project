using UnityEngine;
using System.Collections;

public class ExplosiveBulletScript : MonoBehaviour {

	public float radius = 5.0F;
    public float power = 10.0F;
    public float timer = 2f;
    float time = 0f;

    public GameObject explosionPrefab;

	void OnCollisionEnter(){

		Destroy(this.gameObject);

	    // Explosion code copied from Peter

	    Vector3 explosionPos = transform.position;
	    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders){
            if (hit) {
                if (hit.GetComponent<Rigidbody>()) {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
        }

        // Particle effects (?) AND DESTROY IT
		Destroy(Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation), 1.0f);

	}
}
