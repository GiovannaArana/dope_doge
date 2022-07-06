using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour, IMoveBehaviour {
    
    private GameObject player;
    public float moveSpeed;
	public Transform movePoint;
	public GameObject prefabBox;
	public GameObject prefabBoxMove;

	public BoxBehaviour(GameObject player){

		this.player = player;
	}

	public IMoveBehaviour GetMove(GameObject player){

		BoxBehaviour newBox = new BoxBehaviour(player);
		newBox.prefabBox = this.prefabBox;
		newBox.prefabBoxMove = this.prefabBoxMove;

		return newBox;
	}

	public bool MoveToDirection(Vector3 direction){

		if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f){

			Vector3 pos = transform.position + direction;
	        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

	    	if(col2d == null){
		    	if(!GetComponent<GridGravity>().onAir){
		        	movePoint.position += direction;
		        	return true;
		    	}
	    	}
		}

		return false;
		// transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
	}

    public void Execute(){

    	int signal = 1;
    	int aPos = -1;

    	if(!player.GetComponent<SpriteRenderer>().flipX)
    		signal = -1;

    	Vector3 direction = new Vector3(signal * 2f, 0, 0);
    	Vector3 pos = player.transform.position + direction;
        Collider2D col2d = Physics2D.OverlapBox(pos, new Vector2(1f, 1f), 1f, 1);

    	if(col2d == null){

    		for(int i = 0; i < player.GetComponent<PlayerMovement>().mvs.Length; i++){
    			if(player.GetComponent<PlayerMovement>().mvs[i].GetType() == typeof(BoxBehaviour)){
    				aPos = i;
    				break;
    			}
    		}

    		if(aPos != -1){

    			Vector3 newPos = pos;
    			newPos.y = pos.y + 0.15f;

				InstantiateGambiarra.Instant(prefabBox, newPos);
    			player.GetComponent<PlayerMovement>().mvs[aPos] = new Empty();
		    	player.GetComponent<PlayerMovement>().mvsObj[aPos] = null;
    		}
    	}
    }

    public void Explode(){

    	Vector3 newPos = transform.position;
    	newPos.y = transform.position.y - 0.22f;
    	Instantiate(prefabBoxMove, transform.position, gameObject.transform.rotation);
    	Destroy(gameObject);
    	//gameObject.SetActive(false);
    }

    public void PseudoUpdate(){}

    void Start(){

    	movePoint.parent = null;
    }

    void Update(){

    	transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}
