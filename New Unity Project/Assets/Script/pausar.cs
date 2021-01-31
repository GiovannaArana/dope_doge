using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausar : MonoBehaviour{

    private GameObject menu;

    public bool estado;

    public void Start(){
        menu = GameObject.FindWithTag("Pause");
        estado = false;
    }

    public void Update(){        
        if (Input.GetKeyDown(KeyCode.Escape)){
            estado = !estado;            
        }
        if(estado){Pausar();}
        else{Despausar();}
    }

<<<<<<< HEAD
    public void Despausar(){               
=======
    public void Despausar(){        
>>>>>>> parent of dc9bdad... Mudanças ULTRA mega SUPER Radicais
        Time.timeScale = 1f;        
        menu.SetActive(false);
    }

    public void Pausar(){        
<<<<<<< HEAD
        //Time.timeScale = 0;
=======
        Time.timeScale = 0;
>>>>>>> parent of dc9bdad... Mudanças ULTRA mega SUPER Radicais
        menu.SetActive(true);
    }

    public void trocarEstado(){
        estado = !estado;
    }
}