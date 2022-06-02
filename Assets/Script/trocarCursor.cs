using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocarCursor : MonoBehaviour

{

    public Texture2D seta;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(seta,Vector2.zero, CursorMode.ForceSoftware);
    }

    
}
