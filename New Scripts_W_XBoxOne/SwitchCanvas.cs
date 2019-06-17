using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject onCanvas;
    public GameObject offCanvas;
    public GameObject firstObject;

    public void Switch()
    {
        onCanvas.SetActive(false);
        offCanvas.SetActive(true);
        GameObject.Find ("EventSystem").GetComponent<EventSystem> ().SetSelectedGameObject (firstObject, null);
    }
}
