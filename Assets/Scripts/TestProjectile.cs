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
	bool hasBeenHit = false;
	
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

	void OnEnable()
	{
		hasBeenHit = false;
	}

	void Update()
	{
		if( Time.time > endLifeTimeStamp )
		{
			pooledGameObject.ReturnToPool();
		}
	}

	void OnTriggerEnter2D( Collider2D collider )
	{
		if( !hasBeenHit )
		{
			hasBeenHit = true;
			return;
		}

		IDamageable damageable = collider.gameObject.GetComponent< IDamageable >();
		if( damageable != null )
		{
			damageable.Damage( damage );
			pooledGameObject.ReturnToPool();
		}
	}

}
