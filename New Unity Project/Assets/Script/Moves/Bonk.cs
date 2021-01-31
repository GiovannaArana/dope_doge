using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonk : MonoBehaviour, IMoveBehaviour {
    
    private GameObject player;

	public Bonk(GameObject player){

		this.player = player;
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

        if(col2d != null && col2d.gameObject.tag == "Box")
        	col2d.gameObject.GetComponent<BoxBehaviour>().Explode();
    }

    public void PseudoUpdate(){}
}
