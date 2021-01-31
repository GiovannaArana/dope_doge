using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGambiarra : MonoBehaviour {

    public static void Instant(GameObject go, Vector3 pos){

    	Instantiate(go, pos, go.transform.rotation);
    }
}
