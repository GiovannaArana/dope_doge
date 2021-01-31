using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {
	
    public Animator anim;
    public float delayTime;
    public bool isPet;
    public GameObject HUD;

    void Start(){

    	delayTime = Time.time + 1f;
    } 

    void Update(){

    	if(Time.time > delayTime){
	    	if (Input.anyKey){
	            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	            if(isPet)
	            	HUD.SetActive(false);
	            else
	            	SceneManager.LoadScene(0);
	        }
	    }
    }

    public void proximoNivel(){

        anim.SetBool("fadeToWhite", true);
    }

    public void onFadeComplete(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
