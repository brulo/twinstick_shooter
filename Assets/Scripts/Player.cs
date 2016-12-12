using UnityEngine;
using UnityEngine.InputNew;

[RequireComponent( typeof( PlayerInput ) )]
[RequireComponent( typeof( PlayerMovement ) )]
[RequireComponent( typeof( PlayerWeaponManager ) )]
[RequireComponent( typeof( SpriteRenderer ) )]
public class Player : MonoBehaviour, IDamageable, IStateMachineImplementor< Player.State >
{
    [SerializeField] GameObject tempWeapon; // should be an IWeapon
    [SerializeField] int startHealth = 5;
    [SerializeField] float respawnTime = 3f;

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private PlayerWeaponManager weaponManager;
    private PlayerActionMap actionMap;
    private SpriteRenderer spriteRenderer;
    private int health;
    private StateMachine< Player.State > stateMachine;
    public enum State
    {
        Alive,
        Dead
    }

    public void UpdateState( State state )
    {
        switch( state )
        {
            case State.Alive:
            {
                break;
            }

            case State.Dead:
            {
                if( stateMachine.GetCurrentStateTime() >= respawnTime )
                {
                    stateMachine.SetNextState( State.Alive );
                }
                break;
            }
        }
    }
    
    public void InitState( State state )
    {
        switch( state )
        {
            case State.Alive:
            {
                health = startHealth;
                playerInput.enabled = true;
                spriteRenderer.enabled = true;
                break;
            }

            case State.Dead:
            {
                playerInput.enabled = false;
                spriteRenderer.enabled = false;
                break;
            }
        }
    }

    public void ExitState( State state )
    {
        switch( state )
        {
            case State.Alive:
            {
                break;
            }

            case State.Dead:
            {
                break;
            }
        }
    }


    void Awake()
    {
        playerInput = GetComponent< PlayerInput >();
        playerMovement = GetComponent< PlayerMovement >();
        weaponManager = GetComponent< PlayerWeaponManager >();
        spriteRenderer = GetComponent< SpriteRenderer >();

        health = startHealth;
    }

    void Start()
    {
        stateMachine = new StateMachine< Player.State >( this, true );

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

    void Update()
    {
        stateMachine.Update( Time.deltaTime );
    }

    public void Damage( int damage )
    {
        health = Mathf.Max( health - damage, 0 );
        Debug.Log( "Player took " + damage + " damage. Health is now " + health );

        if( health == 0 )
        {
            stateMachine.SetNextState( State.Dead );
        }
    }
    
}
