using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour {

	public float delayTime;

    void Start()
    {
        delayTime = Time.time + 2f;
    }

    void Update() {

    	if(Time.time > delayTime)
	    	if (Input.anyKey)
	            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
