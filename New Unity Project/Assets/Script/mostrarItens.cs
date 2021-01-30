using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarItens : MonoBehaviour
{

    public GameObject doge;
    private PlayerMovement src;    
    private GameObject[] slots;
    private Image[] srp = new Image[4];
    

    void Start()
    {
        doge = GameObject.FindWithTag("Dog");
        src = doge.GetComponent<PlayerMovement>();        
        slots = GameObject.FindGameObjectsWithTag("Slot");
        for(int i = 0; i<4;i++){
            srp[i] = slots[i].GetComponent<Image>();
        }

    }

    // Update is called once per frame
    void Update(){
        for(int i = 0; i<4;i++){
            if(src.mvsObj[i] != null){         
                srp[i].sprite = src.mvsObj[i].GetComponent<SpriteRenderer>().sprite;
                Color temp = srp[i].color;
                temp.a = 255;
                srp[i].color = temp;
            }
            else{
                Color temp = srp[i].color;
                temp.a = 0;
                srp[i].color = temp;
            }
        }
        
        
    }
}
