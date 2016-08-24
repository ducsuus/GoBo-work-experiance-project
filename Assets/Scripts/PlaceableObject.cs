using UnityEngine;
using System.Collections;

public class PlaceableObject : Tool {

	// The object
	public GameObject placeable;

	// The place to instantiate objects
	public GameObject placeableSpawn;
	// Material to preview objects with
	public Material previewMaterial;

	public override void OnOpen(){

		GameObject placeable = (GameObject) MonoBehaviour.Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

		placeable.transform.parent = placeableSpawn.transform;

		this.CleanObject(placeable);
	
	}
	
	public override void OnFire () {

		Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

	}

	// Get rid of all rigid bodies -> we don't want physics on any previews
	private void CleanObject(GameObject placeable){

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
