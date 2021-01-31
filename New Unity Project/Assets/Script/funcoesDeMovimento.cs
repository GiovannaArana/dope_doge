using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcoesDeMovimento : MonoBehaviour
{
    public void AndarComecou(){
        GameObject dog = GameObject.FindWithTag("Dog");
        Animator anim = dog.GetComponent<Animator>();
        anim.SetTrigger("Andar");
    }
}
