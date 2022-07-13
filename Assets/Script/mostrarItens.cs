using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class mostrarItens : MonoBehaviour
{

    public GameObject doge;
    private PlayerMovement src;    
    private GameObject[] slots;
    private Image[] srp = new Image[4];
    private int slot_certo;
    

    void Start()
    {       
        doge = GameObject.FindWithTag("Dog");
        src = doge.GetComponent<PlayerMovement>();        
        slots = GameObject.FindGameObjectsWithTag("Slot");
        for(int i = 0; i<4;i++){
            slot_certo = Int16.Parse(slots[i].name.Replace("Slot", ""));                                 
            srp[slot_certo-1] = slots[slot_certo-1].GetComponent<Image>();
        }
    }
    //2,1,4,3
    //3,4,1,2
    // Update is called once per frame
    void Update(){
        for(int i = 0; i<4;i++){
            if(src.mvsObj[i] != null && srp[i].color.a != 255){                   
                srp[i].sprite = src.mvsObj[i].GetComponent<SpriteRenderer>().sprite;
                Color temp = srp[i].color;
                temp.a = 255;
                srp[i].color = temp;
            }
            else if(src.mvsObj[i] == null){
                Color temp = srp[i].color;
                temp.a = 0;
                srp[i].color = temp;
            }
        }
        
        
    }
}
