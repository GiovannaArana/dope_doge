using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonk : MonoBehaviour, IMoveBehaviour {
    
    private GameObject player;
    private funcoesDeMovimento funcs;

    public Bonk(GameObject player){

        this.player = player;
        funcs = player.GetComponent<funcoesDeMovimento>();
    }

    public IMoveBehaviour GetMove(GameObject player){

        return new Bonk(player);
    }

    public void Execute(){        

        int signal = 1;

        if(player.transform.localScale.x > 0){
            player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            signal = -1;            
        }
        else{
            player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }       

        Vector3 direction = new Vector3(signal * 2f, 0, 0);
        Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

        if(col2d != null && col2d.gameObject.tag == "Box"){
            col2d.gameObject.GetComponent<BoxBehaviour>().Explode();
            funcs.Bonk(player);
        }
        
        if(col2d != null && col2d.gameObject.tag == "Trash"){            
            col2d.gameObject.GetComponent<Trash>().Explode();
            funcs.Bonk(player);
        }
    }

    public void PseudoUpdate(){}
}
