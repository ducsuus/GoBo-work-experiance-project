using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour {

	// Position of hand
	public GameObject handLocation;

	// List of tools available
	public List<GameObject> tools = new List<GameObject>();

	// Currently tool selected index
	private int selectedTool = 0;

	// Current tool's GameObject
	private GameObject currentTool;
	// Current tool's script -> No enforcing to make sure this script is here when adding, not sure if tool script should be refetched every time it is referenced or set to variable here (probably here -> efficiency?)
	private Tool currentToolScript;
	 

	void Start () {

		this.ChangeTool();
	
	}

	// Update is called once per frame
	void Update () {

		// Tool select

		float mouseScroll = (float) Input.GetAxis("Mouse ScrollWheel");

		if (mouseScroll != 0.0f){

			int slotChange;

			if (mouseScroll > 0.0f)
				slotChange = 1;
			else
				slotChange = -1;

			// Add the amount moved by mouse and make sure it loops around if need be
			this.selectedTool = this.selectedTool + slotChange;

			// Modulus is somewhat broken, loop around
			if (this.selectedTool < 0)
				this.selectedTool = this.tools.Count - 1;
			else if(this.selectedTool >= this.tools.Count)
				this.selectedTool = 0;

			Debug.Log("Selected tool: " + this.selectedTool + " slotChange: " + slotChange);

			this.currentToolScript.OnClose();

			Destroy(this.currentTool);

			this.ChangeTool();


		}

		// Fire1
		if (Input.GetButtonDown("Fire1")) {

			// Send "fire" to the tool
			this.currentToolScript.OnFire();

		}

		// Fire2
		if (Input.GetButtonDown("Fire2")) {

			// Send "fire" to the tool
			this.currentToolScript.OnFireSecondary();

		}

	
	}

	// Change to the tool index specified, otherwise change to the currently select tool (TODO: ? add system to get another tools index, so the game can select a tool for the player)
	public void ChangeTool(int toolIndex = -1){

		if (toolIndex < 0)
			toolIndex = this.selectedTool;

		this.currentTool = (GameObject) Instantiate(this.tools[toolIndex], this.handLocation.transform.position, this.handLocation.transform.rotation);

		this.currentTool.transform.parent = this.handLocation.transform;

		this.currentToolScript = this.currentTool.GetComponent<Tool>();

		this.currentToolScript.OnOpen();
		
	}
}
