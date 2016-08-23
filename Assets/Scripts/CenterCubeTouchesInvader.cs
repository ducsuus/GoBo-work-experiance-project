using UnityEngine;
using System.Collections;

public class CenterCubeTouchesInvader : MonoBehaviour {

	public int CubeHealth = 5;

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "Invader") {

			//col.gameObject.GetComponent<ParticleSystem>().Emit(30);
			Destroy(col.gameObject);

			this.CubeHealth--;

			if(this.CubeHealth <= 0) {

				Destroy(this.gameObject);
			
			}


		}
	}
}
