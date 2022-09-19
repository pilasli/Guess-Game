using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursorOnButton;
    public Vector2 onButtonCursorHotSpot;
  
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorOnButton, onButtonCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, normalCursorHotSpot, CursorMode.Auto);
    }
}
