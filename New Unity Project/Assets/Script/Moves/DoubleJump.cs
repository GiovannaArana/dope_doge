using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour, IMoveBehaviour {

	private GameObject player;
	private Vector3 direction = new Vector3(0, 2f, 0);
	private int numJumps;
	private float delayTime;
	private bool alreadyZero;

	public DoubleJump(GameObject player){

		this.player = player;
		numJumps = 2;
		delayTime = Time.time + 0.5f;
		alreadyZero = false;
	}

	public IMoveBehaviour GetMove(GameObject player){

		return new DoubleJump(player);
	}

    public void Execute(){

        Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

    	if(col2d == null || (col2d != null && col2d.gameObject.tag == "Move")){

	    	if(!player.GetComponent<GridGravity>().onAir){
	    		Jump();
	        	numJumps = 1;
	    	}

	        else if(numJumps < 2){
	        	Jump();
	        	numJumps = 2;
	        }
	    }
    }

    public void PseudoUpdate(){

    	if(delayTime < Time.time){
    		if(!player.GetComponent<GridGravity>().onAir && !alreadyZero){
    			alreadyZero = true;
    			numJumps = 0;
    		}

    		delayTime = Time.time + 0.5f;
    	}
    }

    private void Jump(){

    	player.GetComponent<PlayerMovement>().movePoint.position += direction;
    	player.GetComponent<GridGravity>().hasMovedOnAir = false;
    	alreadyZero = false;
    	delayTime = Time.time + 0.5f;
    }
}
