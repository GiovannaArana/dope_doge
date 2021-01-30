using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehaviour {
    
    void Execute();
    void PseudoUpdate();
    IMoveBehaviour GetMove(GameObject player);
}