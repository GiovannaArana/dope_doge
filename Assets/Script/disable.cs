using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    public GameObject branco;

    public void desativar(){
        branco.SetActive(false);
    }
}
