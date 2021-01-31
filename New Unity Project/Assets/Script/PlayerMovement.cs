using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public Transform movePoint;
	public bool hasMoved;
	public bool enable;	

	public IMoveBehaviour[] mvs;
	public GameObject[] mvsObj;
	private KeyCode[] key;

    void Start(){

        movePoint.parent = null;
        enable = true;
        mvs = new IMoveBehaviour[4];		

        key = new KeyCode[6] {KeyCode.E, KeyCode.Q, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F};

        for(int i = 0; i < mvs.Length; i++){

        	if(mvsObj[i] == null)
        		mvs[i] = new Empty();

        	else{
        		mvs[i] = mvsObj[i].GetComponent<IMoveBehaviour>().GetMove(gameObject);
        		mvsObj[i].SetActive(false);
        	}
        }
    }

    void Update(){

    	if(!PauseMenu.isPaused){
	    	transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

	    	for(int i = 0; i < mvs.Length; i++)
	    		mvs[i].PseudoUpdate();

	        Collider2D col2d = Physics2D.OverlapBox(transform.position, new Vector2(1f, 1f), 1f, 1);

	        // if(col2d != null && col2d.gameObject.tag == "Move")
	        // 	if(Input.GetKey(key[0]))
	        // 		StartCoroutine(ChangeMove(col2d));

	    	if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
	            hasMoved = false;

	        else if(!hasMoved){

	        	hasMoved = true;

		    	if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f && enable){

		    		if(Input.GetKey(key[0]))
		    			if(col2d != null && col2d.gameObject.tag == "Move")
		    				StartCoroutine(ChangeMove(col2d));

			        if(Input.GetKey(key[2]))
			        	mvs[0].Execute();

			        if(Input.GetKey(key[3]))
			        	mvs[1].Execute();

			        if(Input.GetKey(key[4]))
			        	mvs[2].Execute();

			        if(Input.GetKey(key[5]))
			        	mvs[3].Execute();

			        if(Input.GetKey(key[1])){
			        	if(col2d == null)
			        		StartCoroutine(ChangeMove(null));
			        }
			    }
			}
		}
    }

    private IEnumerator ChangeMove(Collider2D col2d) {

	    yield return waitForKeyPress(col2d);	    	
	}
 
	private IEnumerator waitForKeyPress(Collider2D col2d){

	    bool done = false;
	    int pos = -1;
	    float delayTime = Time.time + 0.25f;

	    //IMoveBehaviour[] clone = AllEmpty(mvs);
	    enable = false;

	    while(!done){

	    	if(Time.time > delayTime){
		        pos = GetPosByKey();

		        if(pos != -1){
		        	break;
		        }
		    }

	        yield return null;
	    }

	    //mvs = clone;

	    if(pos != 4){

		    DropMove(pos);

		    if(col2d != null){
			    mvs[pos] = col2d.gameObject.GetComponent<IMoveBehaviour>().GetMove(gameObject);
			    mvsObj[pos] = col2d.gameObject;
			    col2d.gameObject.SetActive(false);
			}
		}

		enable = true;
	}

	public void DropMove(int pos){

		if(mvsObj[pos] != null){

			mvs[pos] = new Empty();
	    	mvsObj[pos].transform.position = transform.position;
	    	mvsObj[pos].SetActive(true);
	    	mvsObj[pos] = null;
	    }
	}

	public int GetPosByKey(){

		if(Input.GetKey(key[2]))
        	return 0;

        if(Input.GetKey(key[3]))
        	return 1;

        if(Input.GetKey(key[4]))
        	return 2;

        if(Input.GetKey(key[5]))
        	return 3;

        if(Input.GetKey(key[1]))
        	return 4;

        return -1;
	}

	public IMoveBehaviour[] AllEmpty(IMoveBehaviour[] original){

		IMoveBehaviour[] clone = new IMoveBehaviour[original.Length];

		for(int i = 0; i < original.Length; i++){
			clone[i] = original[i];
			original[i] = new Empty();
		}

		return clone;
	}
}