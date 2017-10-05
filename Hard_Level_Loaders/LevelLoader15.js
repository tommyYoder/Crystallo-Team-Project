#pragma strict

function Start () {
    GetComponent.<Animation>().Play(GetComponent.<Animation>().clip.name);
    yield WaitForSeconds (GetComponent.<Animation>().clip.length + 2);
    Application.LoadLevel ("BlueTeam_GameOverWin 1");

}


function Update () {
	
}
