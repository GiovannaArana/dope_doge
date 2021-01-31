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

    public void Despausar(){        
        Time.timeScale = 1f;        
        menu.SetActive(false);
    }

    public void Pausar(){        
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void trocarEstado(){
        estado = !estado;
    }
}