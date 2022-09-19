using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursorOnButton;
    public Vector2 onButtonCursorHotSpot;

    [SerializeField] private Text restartButtonText;
 
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorOnButton, onButtonCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, normalCursorHotSpot, CursorMode.Auto);
    }

    public void OnRestartButtonCursorEnter()
    {
        restartButtonText.gameObject.SetActive(true);
    }

    public void OnRestartButtonCursorExit()
    {
        restartButtonText.gameObject.SetActive(false);
    }
}
