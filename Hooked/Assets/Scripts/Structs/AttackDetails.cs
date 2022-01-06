/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Struct to handle damage from projectiles
 * GameObjects associated: Branch, Arrow
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;

public struct AttackDetails
{
    public Vector2 position;
    public float damageAmount;
    public float stunDamageAmount;
}
