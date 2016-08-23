using UnityEngine;
using System.Collections;

public class InvaderExplodes : MonoBehaviour {

	void Start () {

	gameObject.GetComponent<ParticleSystem>().emissionRate = 0;
	gameObject.GetComponent<ParticleSystem>().Emit(30);
	Destroy(gameObject);

	}

//	public void Die () {
//
//			gameObject.GetComponent<ParticleSystem>().Emit(30);
//			Destroy(gameObject);
//		
//		}
	
}