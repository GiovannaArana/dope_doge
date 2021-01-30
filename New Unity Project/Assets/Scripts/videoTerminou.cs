using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoTerminou : MonoBehaviour{

    private VideoPlayer video;    
    
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();        
    }

    // Update is called once per frame
    void Update()
    {
        if((ulong)video.frame == (video.frameCount - 1)){
            Debug.Log("entrou aqui");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            Debug.Log((ulong)video.frame + " !=" + video.frameCount);
            
        }
    }
}
