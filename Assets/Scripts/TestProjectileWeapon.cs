using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// TODO: change to specific weapon
[RequireComponent( typeof( GameObjectPool ) )]
public class TestProjectileWeapon : MonoBehaviour, IWeapon
{
	[SerializeField] float timeBetweenShots = 0.2f;

	private GameObjectPool projectilePool;
	private float nextShotTimestamp = 0f;

	void Awake()
	{
		projectilePool = GetComponent< GameObjectPool >();
	}

	public void Use( Vector2 direction )
	{
		if( direction == Vector2.zero || Time.time < nextShotTimestamp )
			return;

		GameObject projectile = projectilePool.TakeObject();
		projectile.transform.position = this.transform.position;

		TestProjectile testProjectile = projectile.GetComponent< TestProjectile >();
		testProjectile.Fire( direction );

		nextShotTimestamp = Time.time + timeBetweenShots;
	}

	public void Equip()
	{
	}

	public void Unequip()
	{
	}

}
