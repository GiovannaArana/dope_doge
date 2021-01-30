using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : IMoveBehaviour {

	public void Execute(){}
	public void PseudoUpdate(){}
	public IMoveBehaviour GetMove(GameObject player){return new Empty();}
}