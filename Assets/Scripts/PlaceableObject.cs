using UnityEngine;
using System.Collections;

public class PlaceableObject : Tool {

	// The object
	public GameObject placeable;

	// The place to instantiate objects
	public GameObject placeableSpawn;

	// Material to preview objects with
	public Material previewMaterial;

	public Material previewMaterialInvalid;

	// Cost of the object
	public int cost;

	private PlayerScript playerScript;

	private GameObject placeableInstance;
	
	public override void OnOpen(){

		this.placeableInstance = (GameObject) MonoBehaviour.Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation);

		this.placeableInstance.transform.parent = placeableSpawn.transform;

		this.CleanPlaceable();
	
	}
	
	public override void OnFire () {

		PlayerScript playerScript = this.player.GetComponent<PlayerScript>(); // finds PlayerScript for access to the player's score

		if (playerScript.playerScore >= this.cost) { // If player has the required score

			Instantiate(this.placeable, this.placeableSpawn.transform.position, this.placeableSpawn.transform.rotation); // place item

			playerScript.playerScore -= cost; // take cost from score

			// Update the object so it turns red if we cannot place it (a tad inefficient here :( )
			this.CleanPlaceable();

		}
	}

	// Get rid of all rigid bodies -> we don't want physics on any previews
	private void CleanPlaceable(){

		Rigidbody[] rigidBodies = this.placeableInstance.GetComponentsInChildren<Rigidbody>();

		foreach(Rigidbody rigidBody in rigidBodies){

			Destroy(rigidBody);
		} 

		Collider[] colliders = this.placeableInstance.GetComponentsInChildren<Collider>();

		foreach(Collider collider in colliders){

			Destroy(collider);
		}

		Renderer[] renderers = this.placeableInstance.GetComponentsInChildren<Renderer>();

		Material material;

		if( this.player.GetComponent<PlayerScript>().playerScore > this.cost){
			material = this.previewMaterial;
		}else{
			material = this.previewMaterialInvalid;
		}

		foreach(Renderer renderer in renderers){

			renderer.material = material;
		} 

	}
}
