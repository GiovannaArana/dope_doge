using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour, IMoveBehaviour {

	private GameObject player;
	private Vector3 direction = new Vector3(-2f, 0, 0);

	public MoveLeft(GameObject player){

		this.player = player;
	}

	public IMoveBehaviour GetMove(GameObject player){

		return new MoveLeft(player);
	}

    public void Execute(){

    	Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

    	if(col2d == null  || (col2d != null && col2d.gameObject.tag == "Move")){

	    	if(!player.GetComponent<GridGravity>().onAir || (player.GetComponent<GridGravity>().onAir && !player.GetComponent<GridGravity>().hasMovedOnAir)){

	        	player.GetComponent<PlayerMovement>().movePoint.position += new Vector3(-2f, 0f, 0f);
	        	player.GetComponent<SpriteRenderer>().flipX = false;
	        	player.GetComponent<GridGravity>().hasMovedOnAir = true;
	        }
	    }
    }

    public void PseudoUpdate(){}
}