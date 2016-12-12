using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisions : MonoBehaviour
{

	void OnCollisionEnter(Collision other)
	{
		Debug.Log( "collsition at: " + Time.time + " by obj id: " + gameObject.GetInstanceID() );
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log( "trigger at: " + Time.time + " by obj id: " + gameObject.GetInstanceID() );
	}

}
