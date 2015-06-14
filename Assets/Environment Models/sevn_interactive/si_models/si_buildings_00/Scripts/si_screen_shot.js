import System.IO;
var key_screenshot:KeyCode=KeyCode.Print;
function Update()
{
	if(Input.GetKeyDown(key_screenshot))
	{
		save_screen( );
	}
}
function save_screen( )
{
	// We should only read the screen bufferafter rendering is complete
	yield WaitForEndOfFrame();

	// Create a texture the size of the screen, RGB24 format
	var width = Screen.width;
	var height = Screen.height;
	var tex = new Texture2D( width, height, TextureFormat.RGB24, false );
	// Read screen contents into the texture
	tex.ReadPixels( Rect(0, 0, width, height), 0, 0 );
	tex.Apply();

	// Encode texture into PNG
	var bytes = tex.EncodeToPNG();
	Destroy( tex );

	// For testing purposes, also write to a file in the project folder
	//System.IO.File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
var str_path=Application.dataPath + "/../SavedScreen.png";
var fs : FileStream = FileStream(str_path, FileMode.CreateNew);
var w : BinaryWriter = BinaryWriter(fs);
w.Write(bytes);
w.Close();
fs.Close();


}