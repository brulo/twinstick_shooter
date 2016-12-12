using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputNew;

[RequireComponent (typeof( Rigidbody2D ))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 10f;

	// TODO (bruce): move to a RequireComponent? is actionMap a MonoBehaviour?
	public Vector2InputControl MoveInput { set { moveInput = value; } }
	private Vector2InputControl moveInput = null;

	private Rigidbody2D rigidBody;

	void Awake()
	{
		rigidBody =  GetComponent< Rigidbody2D >();
	}

	void FixedUpdate()
	{
		if( moveInput != null )
		{
			rigidBody.velocity = moveInput.vector2 * moveSpeed;
		}
	}
	
}
