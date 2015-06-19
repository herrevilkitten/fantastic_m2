#pragma strict
var drawerclosed = true;

function OnMouseOver(){
   if(Input.GetMouseButtonDown(0)){
       if (drawerclosed == true) {
       transform.Translate(-.5,0,0);
       drawerclosed = false;
       }
       else if (drawerclosed == false) {
       transform.Translate(.5,0,0);
       drawerclosed = true;
       }
  }
   
 }