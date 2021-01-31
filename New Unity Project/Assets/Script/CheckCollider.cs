using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollider : MonoBehaviour {

	public GameObject endHud;

    void Start()
    {
        
    }

    
    void Update() {
        
        // Collider2D col2d = Physics2D.OverlapBox(transform.position + new Vector3(0f, -2f, 0f), new Vector2(1f, 1f), 1f, 1);
        Collider2D col2d = Physics2D.OverlapBox(transform.position, new Vector2(1f, 1f), 1f, 1);

        if(col2d != null && col2d.gameObject.tag == "KillFloor"){

        	if(tag != "Dog")
        		Destroy(gameObject);
        	else
        		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(col2d != null && col2d.gameObject.tag == "EndGameFlag"){
        	
        	if(tag == "Dog")
        		endHud.SetActive(true);
        }
    }
}
