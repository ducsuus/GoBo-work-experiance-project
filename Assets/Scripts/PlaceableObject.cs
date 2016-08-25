using UnityEngine;
using System.Collections;

public class PlaceableObject : Tool {

	// The object
	public GameObject placeable;

	// The place to instantiate objects
	public GameObject placeableSpawn;

	// Material to preview objects with
	public Material previewMaterial;

	// Cost of the object
	public int cost;
	
	public override void OnOpen(){

		GameObject placeable = (GameObject) MonoBehaviour.Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

		placeable.transform.parent = placeableSpawn.transform;

		this.CleanObject(placeable);

		base.OnOpen();
	
	}
	
	public override void OnFire () {

		PlayerScript playerScript = this.player.GetComponent<PlayerScript>(); // finds PlayerScript for access to the player's score

		if (playerScript.playerScore >= cost) { // If player has the required score

			Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation); // place item

			playerScript.playerScore -= cost; // take cost from score

		}
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
