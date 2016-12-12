using UnityEngine;
using System.Collections;

public interface IWeapon
{
    void Use( Vector2 direction );
    void Equip();
    void Unequip();
}

public interface IPickupable
{
    void Pickup();
}

public interface IDamageable
{
    void Damage( int damage );
}
