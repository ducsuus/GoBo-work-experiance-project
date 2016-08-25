using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tool : MonoBehaviour {

	public GameObject player;

	public Tool(){

		return;
	}

	public virtual void OnOpen(GameObject player){

		this.player = player;

		return; 
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

	public virtual void OnFireHold(){

		return;
	}

	public virtual void OnFireSecondary(){

		return;
	}

}