using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStateMachineImplementor< Enemy.State >
{
	[SerializeField] float idleTime = 3f;
	//[SerializeField] float patrolTime = 3f;
	[SerializeField] Collider2D sightCollider = null;

	public enum State
	{
		Idle,
		Patrolling,
		Attacking
	}

	private Transform targetTransform = null;
	private StateMachine< Enemy.State > stateMachine;

	public void InitState( State state )
	{
		switch( state )
		{
			case State.Patrolling:
			{
				/*
				Vector3 dir = targetTransform.position - transform.position;
   				dir = targetTransform.InverseTransformDirection( dir );
    			float angle = Mathf.Atan2( dir.y, dir.x ) * Mathf.Rad2Deg;
				*/
				break;
			}
		}
	}

	public void UpdateState( State state )
	{
		switch( state )
		{
			case State.Idle:
				if( stateMachine.GetCurrentStateTime() > idleTime )
				{
					stateMachine.SetNextState( State.Patrolling );
				}
				break;

			case State.Patrolling:
				/*
				if( stateMachine.GetCurrentStateTime() > patrolTime )
				{
					stateMachine.SetNextState( State.Idle );
				}
				*/
				break;
		}
	}

	public void ExitState( State state )
	{
		switch( state )
		{
			case State.Patrolling:
				break;

			case State.Attacking:
				targetTransform = null;
				break;
		}
	}

}
