using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollider : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update() {
        
        Collider2D col2dFall = Physics2D.OverlapBox(transform.position + new Vector3(0f, -2f, 0f), new Vector2(1f, 1f), 1f, 1);

        if(col2dFall != null && col2dFall.gameObject.tag == "KillFloor")
        	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
