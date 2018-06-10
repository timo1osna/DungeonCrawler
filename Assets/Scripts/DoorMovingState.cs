using UnityEngine;
using System.Collections;

public class DoorMovingState : MonoBehaviour {
	public bool isMoving=false;

	void SwitchMovingState(int id)
	{
		isMoving = !isMoving;
		//Debug.Log (id);
	}

	void Test(Rigidbody tes)
	{
		isMoving = !isMoving;
		//Debug.Log (id);
	}
}
