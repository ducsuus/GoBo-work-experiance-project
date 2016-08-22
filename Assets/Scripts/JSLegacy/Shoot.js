#pragma strict

var Speed : float = 10f; 
var BulletPrefab : GameObject;

function Update () {

    // We're going cwazy :D
	if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) {

    	var bullet = Instantiate(BulletPrefab, gameObject.Find("BulletOrigin").transform.position, transform.rotation);
    	bullet.GetComponent.<Rigidbody>().AddForce(transform.up * Speed);

	}

}