using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledGameObject : MonoBehaviour
{
	private GameObjectPool pool = null;

	public void SetPool( GameObjectPool pool )
	{
		this.pool = pool;
	}

	public void ReturnToPool()
	{
		if( pool != null )
		{
			Debug.Log( "Return to pool" );
			pool.ReturnObject( this.gameObject );
		}
		else
		{
			Debug.LogWarning( "Pooled Object did not belong to a pool on ReturnToPool(). Destroying object" );
			Destroy( this.gameObject );
		}
	}
	
}
