using UnityEngine;
using UnityEngine.InputNew;

[RequireComponent( typeof( PlayerInput ) )]
[RequireComponent( typeof( PlayerMovement ) )]
[RequireComponent( typeof( PlayerWeaponManager ) )]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] GameObject tempWeapon; // should be an IWeapon
    [SerializeField] int startHealth = 5;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private PlayerWeaponManager weaponManager;
    private PlayerActionMap actionMap;
    private int health;


    void Awake()
    {
        // get components
        playerInput = GetComponent< PlayerInput >();
        playerMovement = GetComponent< PlayerMovement >();
        weaponManager = GetComponent< PlayerWeaponManager >();

        health = startHealth;
    }

    void Start()
    {
        // setup input
        actionMap = playerInput.GetActions<PlayerActionMap>();

        playerMovement.MoveInput = actionMap.move;
        weaponManager.FireInput = actionMap.attack;
        weaponManager.ChangeWeaponInput = actionMap.changeWeapon;
        weaponManager.AimInput = actionMap.aim;

        // add weapon to weaponmanager for testing
        IWeapon weapon = tempWeapon.GetComponent< IWeapon >();
        if( weapon != null )
            weaponManager.AddWeapon( weapon );
    }

    public void Damage( int damage )
    {
        health = Mathf.Max( health - damage, 0 );
        Debug.Log( "Player took " + damage + " damage. Health is now " + health );

        if( health == 0 )
        {
            Debug.Log( "Player died!" );
        }
    }
    
}
