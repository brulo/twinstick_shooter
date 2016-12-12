using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameObjectPool : MonoBehaviour
{
	[SerializeField] PooledGameObject prefab = null;
	[SerializeField] int initialSize = 0;
	[SerializeField] Transform parentTransform = null;

	private Stack< GameObject > objects = new Stack< GameObject >();

	void Awake()
	{
		while( objects.Count < initialSize )
		{
			AddNewObject();
		}
	}

	public GameObject TakeObject()
	{
		if( objects.Count < 1 )
		{
			Debug.LogWarning( "GameObjectPool: TakeObject() called on empty pool! Adding new instance to pool." );
			AddNewObject();
		}

		return objects.Pop();
	}

	public void ReturnObject( GameObject obj )
	{
		obj.SetActive( false );
		objects.Push( obj );
	}
	
	private void AddNewObject()
	{
		if( prefab != null )
		{
			GameObject obj = GameObject.Instantiate( prefab.gameObject );

			obj.GetComponent< PooledGameObject >().SetPool( this );
			
			if( parentTransform != null )
				obj.transform.parent = parentTransform;
				
			obj.SetActive( false );

			objects.Push( obj );
		}
	}
	
}
