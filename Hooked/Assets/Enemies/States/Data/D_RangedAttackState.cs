/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for RangedAttack state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: RangedAttackState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float projectileSpeed = 12;
    public float projectileTravelDistance;
}
