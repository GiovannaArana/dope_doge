using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour {

    //Stores input from the PlayerInput
    private Vector3 direction;
    bool hasMoved;

    void Update() {

        if(Input.GetAxisRaw("Horizontal") == 0)
            hasMoved = false;

        else if (Input.GetAxisRaw("Horizontal") != 0 && !hasMoved) {
            hasMoved = true;
            GetMovementDirection();
        }

    }

    public void GetMovementDirection(){

        if (Input.GetAxisRaw("Horizontal") < 0){

            direction = new Vector3(-2, 0, 0);

            transform.position += direction;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0){

            direction = new Vector3(2, 0, 0);

            transform.position += direction;
        }
    }

    // public void OnMove(InputValue value){
    //     movementInput = value.Get<Vector2>();
    // }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     transform.position -= direction;
    // }
}
