using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursorOnButton;
    public Vector2 onButtonCursorHotSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorOnButton, onButtonCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorNormal, normalCursorHotSpot, CursorMode.Auto);
    }
}
