using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcoesDeMovimento : MonoBehaviour
{

   public void AndarComecou(GameObject dog){
        Animator anim = dog.GetComponent<Animator>();
        anim.SetTrigger("Andar");
    }

    public void Bonk(GameObject player){
        Animator anim = player.GetComponent<Animator>();      
        anim.SetTrigger("Bonk");
    }
}
