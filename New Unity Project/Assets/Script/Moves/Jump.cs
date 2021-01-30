using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IMoveBehaviour {

	private GameObject player;
	private Vector3 direction = new Vector3(0, 2f, 0);

	public Jump(GameObject player){

		this.player = player;
	}

	public IMoveBehaviour GetMove(GameObject player){

		return new Jump(player);
	}

    public void Execute(){

        Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

    	if(col2d == null  || (col2d != null && col2d.gameObject.tag == "Move")){

	    	if(!player.GetComponent<GridGravity>().onAir){

	        	player.GetComponent<PlayerMovement>().movePoint.position += direction;
	        	player.GetComponent<GridGravity>().hasMovedOnAir = false;
	        }
	    }
    }

    public void PseudoUpdate(){}
}