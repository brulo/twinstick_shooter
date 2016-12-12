using UnityEngine;
using UnityEngine.InputNew;

[RequireComponent( typeof( PlayerInput ) )]
[RequireComponent( typeof( PlayerMovement ) )]
[RequireComponent( typeof( PlayerWeaponManager ) )]
public class Player : MonoBehaviour
{
    [SerializeField] public GameObject tempWeapon; // should be an IWeapon

    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private PlayerWeaponManager weaponManager;
    private PlayerActionMap actionMap;

    void Start()
    {
        // get components
        playerInput = GetComponent< PlayerInput >();
        actionMap = playerInput.GetActions<PlayerActionMap>();
        playerMovement = GetComponent< PlayerMovement >();
        weaponManager = GetComponent< PlayerWeaponManager >();

        // setup input
        playerMovement.MoveInput = actionMap.move;
        weaponManager.FireInput = actionMap.attack;
        weaponManager.ChangeWeaponInput = actionMap.changeWeapon;
        weaponManager.AimInput = actionMap.aim;

        // add weapon to weaponmanager for testing
        
        IWeapon weapon = tempWeapon.GetComponent< IWeapon >();
        if( weapon != null )
            weaponManager.AddWeapon( weapon );
    }
    
}
