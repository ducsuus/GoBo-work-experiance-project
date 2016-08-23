using UnityEngine;
using System.Collections;

public class ObjectPlace : MonoBehaviour {

	// The wall
	public GameObject wall;

	// The place to instantiate objects
	public GameObject placeableSpawn;
	// Material to preview objects with
	public Material previewMaterial;

	// Use this for initialization
	void Start () {

		GameObject wall = (GameObject) Instantiate(this.wall, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

		wall.transform.parent = placeableSpawn.transform;

		this.CleanObject(wall);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire2")){

			Instantiate(this.wall, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

		}

	}

	// Get rid of all rigid bodies -> we don't want physics on any previews
	void CleanObject(GameObject placeable){

		Rigidbody[] rigidBodies = placeable.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody rigidBody in rigidBodies){

			Destroy(rigidBody);
		} 

		Collider[] colliders = placeable.GetComponentsInChildren<Collider>();

		foreach(Collider collider in colliders){

			Destroy(collider);
		}

		Renderer[] renderers = placeable.GetComponentsInChildren<Renderer>();

		foreach(Renderer renderer in renderers){

			renderer.material = previewMaterial;
		} 

	}
}
