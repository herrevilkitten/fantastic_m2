
var cam_target : Transform; 
var cam_target_height = 1.0; 
var cam_distance : float = 12; 
var max_cam_distance = 12; 
var min_cam_distance = 12; 
var x_speed = 250.0; 
var y_speed = 120.0; 
var y_min_limit = 45; 
var y_max_limit = 45; 
var zoom_rate = 20; 
var rotation_damping = 5.0; 
private var x = 0.0; 
private var y = 0.0; 

function Start () 
{ 
    var angles = transform.eulerAngles; 
    x = angles.y; 
    y = angles.x; 
   // Make the rigid body not change rotation 
	if (GetComponent.<Rigidbody>()) 
	{
		GetComponent.<Rigidbody>().freezeRotation = true; 
	}
} 

function LateUpdate () 
{ 
   if(!cam_target)
	{   
		return; 
    }
   // If either mouse buttons are down, let them govern camera position 
  if (Input.GetMouseButton(2)) 
   { 
		x += Input.GetAxis("Mouse X") * x_speed * 0.02; 
		y -= Input.GetAxis("Mouse Y") * y_speed * 0.02; 
   // otherwise, ease behind thecam_target if any of the directional keys are pressed 
   } 
   //else if(Input.GetAxis("Vertical") || Input.GetAxis("Horizontal")) 
   //{ 
   //   varcam_targetRotationAngle =cam_target.eulerAngles.y; 
    //  var currentRotationAngle = transform.eulerAngles.y; 
   //   x = Mathf.LerpAngle(currentRotationAngle,cam_targetRotationAngle, rotation_damping * Time.deltaTime); 
   //} 
	cam_distance -= (Input.GetAxis("Mouse ScrollWheel") *20* Time.deltaTime) * zoom_rate;// * Mathf.Abs(cam_distance); 
	cam_distance = Mathf.Clamp(cam_distance, min_cam_distance, max_cam_distance); 
	y = ClampAngle(y, y_min_limit, y_max_limit); 
	var rotation:Quaternion;
	rotation = Quaternion.Euler(y, x, 0);
	var position =cam_target.position - (rotation * Vector3.forward * cam_distance + Vector3(0,-cam_target_height,0)); 
	transform.rotation = rotation; 
	transform.position = position; 
} 

static function ClampAngle (angle : float, min : float, max : float) 
{ 
   if(angle < -360) 
   {
		angle += 360; 
	}
	
   if(angle > 360) 
   {
		angle -= 360; 
	}
	
   return Mathf.Clamp (angle, min, max); 
} 

