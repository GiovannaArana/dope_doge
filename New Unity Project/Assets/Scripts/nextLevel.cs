using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public string proxNivel;

    public Animator anim;   
     
    public void proximoNivel(){

        anim.SetBool("fadeToWhite", true);
    }

    public void onFadeComplete(){
        SceneManager.LoadScene(proxNivel);
    }
    
}
