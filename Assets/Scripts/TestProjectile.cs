using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
[RequireComponent( typeof( PooledGameObject ) )]
public class TestProjectile : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	[SerializeField] private int damage = 1;
	[SerializeField] private float lifeTime = 5f;

	private Rigidbody2D rigidBody;
	private PooledGameObject pooledGameObject;
	private float endLifeTimeStamp;
	
	public void Fire( Vector2 direction )
	{
		gameObject.SetActive( true );
		rigidBody.velocity = speed * direction;
		endLifeTimeStamp = Time.time + lifeTime;
	}

	void Awake()
	{
		rigidBody = GetComponent< Rigidbody2D >();
		pooledGameObject = GetComponent< PooledGameObject >();
	}

	void Update()
	{
		if( Time.time > endLifeTimeStamp )
		{
			pooledGameObject.ReturnToPool();
		}
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		IDamageable damageable = collision as IDamageable;
		if( damageable != null )
		{
			damageable.Damage( damage );
			pooledGameObject.ReturnToPool();
		}
	}

}
