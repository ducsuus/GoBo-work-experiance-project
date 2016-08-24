using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tool : MonoBehaviour {

	public Tool(){

		Debug.Log("Created tool");

	}

	public virtual void OnOpen(){

		return;
	}

	public virtual void OnClose(){

		return;
	}

	public virtual void OnFire(){

		return;
	}

	public virtual void OnFireSecondary(){

		return;
	}

}