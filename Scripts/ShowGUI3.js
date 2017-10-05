var ShowGUI : boolean;
var style : GUIStyle;

function OnTriggerEnter(Col : Collider)
    {

    if(Col.CompareTag("Player"))
    {

        ShowGUI = true;
    }
}




function OnTriggerExit(Col : Collider)
    {
        if(Col.CompareTag("Player"))
        {
            ShowGUI = false;
            Destroy(gameObject);
        }
    }

function OnGUI()
{
    if(ShowGUI == true)
        GUI.Label(Rect(400,300,500,80), "To move the camera move your mouse left or right!", style);
}