using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Collider2D ) ) ]
public class Zombie : MonoBehaviour
{
	[SerializeField] Transform target = null;

	void Start ()
	{
	}
	
	void Update ()
	{
		transform.LookAt( target );
	}
}
