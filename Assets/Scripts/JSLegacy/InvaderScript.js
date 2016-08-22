#pragma strict

var speed : float = 1.0;

function Start () {

}

function Update () {

	var movement = Vector3(0, -speed, 0) * Time.deltaTime;

	transform.Translate(movement);

}