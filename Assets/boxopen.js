#pragma strict
var doorclosed = true;

function OnMouseOver(){
   if(Input.GetMouseButtonDown(0)){
       if (doorclosed == true) {
       //transform.Rotate(new Vector3(90,0,0));
       transform.Translate(0,0,1);
       doorclosed = false;
       }
       else if (doorclosed == false) {
       //transform.Rotate(new Vector3(-90,0,0));
       transform.Translate(0,0,-1);
       doorclosed = true;
       }
  }
   
 }