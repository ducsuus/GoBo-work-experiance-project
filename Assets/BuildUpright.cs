using UnityEngine;
using System.Collections;

public class BuildUpright : MonoBehaviour {

	void Update () {

		Vector3 rotation = this.transform.rotation.eulerAngles;

		this.transform.rotation = Quaternion.Euler(0, rotation.y, rotation.z);

		Debug.Log("rotation: " + this.transform.rotation);
	
	}
}
