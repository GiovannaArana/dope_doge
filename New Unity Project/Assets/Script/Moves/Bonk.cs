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

    	if(!player.GetComponent<SpriteRenderer>().flipX)
    		signal = -1;

    	Vector3 direction = new Vector3(signal * 2f, 0, 0);
    	Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

        if(col2d != null && col2d.gameObject.tag == "Box"){
			funcs.Bonk(player);
        	col2d.gameObject.GetComponent<BoxBehaviour>().Explode();
		}
		if(col2d != null && col2d.gameObject.tag == "Trash"){
			funcs.Bonk(player);
			col2d.gameObject.GetComponent<Trash>().Explode();
		}
    }

    public void PseudoUpdate(){}
}
