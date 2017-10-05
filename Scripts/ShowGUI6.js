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
        GUI.Label(Rect(400,300,500,80), "To gain extra time collide with thy clocks!", style);
}