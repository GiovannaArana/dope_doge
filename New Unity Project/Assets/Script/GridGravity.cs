using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGravity : MonoBehaviour
{	

	private Vector3 direction;
	private BoxCollider2D col;
	private Vector3 pos;
	private Collider2D col2d;

	public float onAirTime;
	public bool onAir;
	public bool hasMovedOnAir;

    void Start(){

        col = GetComponent<BoxCollider2D>();
        pos = transform.position;
        hasMovedOnAir = true;

        col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

        if(col2d == null)
        	onAir = true;

        else
        	onAir = false;
    }

    void Update(){

        direction = new Vector3(0, -2f, 0);
        pos = transform.position + direction;

        col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

        if(col2d == null || (col2d != null && col2d.gameObject.tag == "Move") || (col2d != null && col2d.gameObject.tag == "Box" && col2d.GetComponent<GridGravity>().onAir)){

        	if(!onAir){
        		onAirTime = Time.time + 1f;
        	}

        	onAir = true;

        	if(Time.time > onAirTime){

                if(tag == "Dog")
                    GetComponent<PlayerMovement>().movePoint.position += new Vector3(0f, -2f, 0f);

                else if(tag == "Box")
                    GetComponent<BoxBehaviour>().movePoint.position += new Vector3(0f, -2f, 0f);

        		onAirTime = Time.time + 1f;
        		hasMovedOnAir = false;
        	}
        }

        else{
        	onAir = false;
        }
    }
}
