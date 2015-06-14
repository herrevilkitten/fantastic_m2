#pragma strict

private var move_speed:float=2.0;

function Update ()
{
	transform.rotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0); 	
	transform.Translate(Vector3(Input.GetAxis ("Horizontal") * move_speed * Time.deltaTime, 0,Input.GetAxis("Vertical") * move_speed * Time.deltaTime), transform);
}

