using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcoesDeMovimento : MonoBehaviour
{
<<<<<<< HEAD
    public void AndarComecou(GameObject player){  
        Animator anim = player.GetComponent<Animator>();      
=======
    public void AndarComecou(){
        GameObject dog = GameObject.FindWithTag("Dog");
        Animator anim = dog.GetComponent<Animator>();
>>>>>>> parent of dc9bdad... Mudanças ULTRA mega SUPER Radicais
        anim.SetTrigger("Andar");
    }

    public void Bonk(GameObject player){
        Animator anim = player.GetComponent<Animator>();      
        anim.SetTrigger("Bonk");
    }
}
