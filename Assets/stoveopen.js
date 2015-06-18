#pragma strict
var doorclosed = true;

function OnMouseOver(){
   if(Input.GetMouseButtonDown(0)){
       if (doorclosed == true) {
       transform.Rotate(new Vector3(0,0,-90));
       doorclosed = false;
       }
       else if (doorclosed == false) {
       transform.Rotate(new Vector3(0,0,90));
       doorclosed = true;
       }
  }
   
 }