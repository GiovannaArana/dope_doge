using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour, IMoveBehaviour {

	private GameObject player;
	private funcoesDeMovimento funcs;
	private Vector3 direction = new Vector3(-2f, 0, 0);

	public MoveLeft(GameObject player){

		this.player = player;
		funcs = player.GetComponent<funcoesDeMovimento>();
	}

	public IMoveBehaviour GetMove(GameObject player){

		return new MoveLeft(player);
	}

    public void Execute(){

		funcs.AndarComecou(player);
    	Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);
        bool isPossible = true;
		if(player.transform.localScale.x < 0){
        	player.transform.localScale = new Vector3(player.transform.localScale.x * -1, player.transform.localScale.y, player.transform.localScale.z);
		}

        // player.GetComponent<PlayerMovement>().bonk.GetComponent<SpriteRenderer>().flipX = false;
        // player.GetComponent<PlayerMovement>().bonkSmoke.GetComponent<SpriteRenderer>().flipX = false;

    	if(col2d == null  || ((col2d != null && (col2d.gameObject.tag == "Move" || col2d.gameObject.tag == "Box" || col2d.gameObject.tag == "EndGameFlag")))){

	    	if(!player.GetComponent<GridGravity>().onAir || (player.GetComponent<GridGravity>().onAir && !player.GetComponent<GridGravity>().hasMovedOnAir)){

	    		if(col2d != null && col2d.gameObject.tag == "Box"){
	        		isPossible = col2d.gameObject.GetComponent<BoxBehaviour>().MoveToDirection(direction);
	        	}

	        	if(isPossible){
		        	player.GetComponent<PlayerMovement>().movePoint.position += new Vector3(-2f, 0f, 0f);
		        	player.GetComponent<GridGravity>().hasMovedOnAir = true;
	        	}
	        }
	    }
    }

    public void PseudoUpdate(){}
}