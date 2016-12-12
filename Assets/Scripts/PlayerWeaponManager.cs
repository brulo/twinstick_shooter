using UnityEngine;
using UnityEngine.InputNew;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponManager : MonoBehaviour
{
	[SerializeField] private int maxNumberOfWeapons = 2;

	private ButtonInputControl fireInput;
	public ButtonInputControl FireInput { set { fireInput = value; } }

	private ButtonInputControl changeWeaponInput;
	public ButtonInputControl ChangeWeaponInput { set { changeWeaponInput = value; } }

	private Vector2InputControl aimInput;
	public Vector2InputControl AimInput { set { aimInput = value; } }

	private IWeapon equippedWeapon;
	private List< IWeapon > weapons;
	private int NumberOfWeapons { get { return weapons.Count + ( equippedWeapon == null ? 0 : 1 ); } }
	
	void Awake()
	{
		equippedWeapon = null;
		weapons = new List< IWeapon >();
	}

	void FixedUpdate()
	{
		if( equippedWeapon == null ) 
			return;

		// fire
		if( fireInput.isHeld )
		{
			equippedWeapon.Use( aimInput.vector2 );
		}

		// change weapon
		if( changeWeaponInput.wasJustPressed )	
		{
			if( equippedWeapon != null && weapons.Count > 0 )
			{
				equippedWeapon.Unequip();
				weapons.Add( equippedWeapon );

				equippedWeapon = weapons[ 0 ];
				weapons.RemoveAt( 0 );
				equippedWeapon.Equip();
			}
		}
	}
	
	public void AddWeapon( IWeapon weapon )
	{
		if( NumberOfWeapons >= maxNumberOfWeapons )
			return;

		// immediately equip if weapon is not already equipped
		if( equippedWeapon == null )
		{
			weapon.Equip();
			equippedWeapon = weapon;
		}
		else
		{
			weapons.Add( weapon );
		}
	}
	
}
