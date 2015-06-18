#pragma strict

/**
* Script made by OMA [www.oma.netau.net]
**/


var sand: AudioClip [];

var floor: AudioClip [];
var grass: AudioClip [];

private var step : boolean = true;
var audioStepLengthWalk : float = 0.45;
var audioStepLengthRun : float = 0.25;


function OnControllerColliderHit (hit : ControllerColliderHit) {
var controller : CharacterController = GetComponent(CharacterController);

if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Sand" && step == true) {
		WalkOnSand();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Sand" && step == true) {
		RunOnSand();			
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Floor" && step == true) {
		WalkOnFloor();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Floor" && step == true) {
		RunOnFloor();	
	} else if (controller.isGrounded && controller.velocity.magnitude < 7 && controller.velocity.magnitude > 5 && hit.gameObject.tag == "Grass" && step == true) {
		WalkOnGrass();
	} else if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Grass" && step == true) {
		RunOnGrass();
				
																
	}		
}


////////////////////////////////// SAND ///////////////////////////////////////////////
function WalkOnSand() {	
	step = false;
	GetComponent.<AudioSource>().clip = sand[Random.Range(0, sand.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnSand() {
	step = false;
	GetComponent.<AudioSource>().clip = sand[Random.Range(0, sand.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}


////////////////////////////////// FLOOR ///////////////////////////////////////////////
function WalkOnFloor() {	
	step = false;
	GetComponent.<AudioSource>().clip = floor[Random.Range(0, floor.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnFloor() {
	step = false;
	GetComponent.<AudioSource>().clip = floor[Random.Range(0, floor.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}

////////////////////////////////// GRASS ///////////////////////////////////////////////
function WalkOnGrass() {	
	step = false;
	GetComponent.<AudioSource>().clip = grass[Random.Range(0, grass.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnGrass() {
	step = false;
	GetComponent.<AudioSource>().clip = grass[Random.Range(0, grass.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}



@script RequireComponent(AudioSource)