using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcoesDeMovimento : MonoBehaviour
{
<<<<<<< HEAD
    public void AndarComecou(GameObject player){  
        Animator anim = player.GetComponent<Animator>();      
=======
    public void AndarComecou(GameObject player){

        Animator anim = player.GetComponent<Animator>();
>>>>>>> pr/12
        anim.SetTrigger("Andar");
    }

    public void Bonk(GameObject player){
        Animator anim = player.GetComponent<Animator>();      
        anim.SetTrigger("Bonk");
    }
}
