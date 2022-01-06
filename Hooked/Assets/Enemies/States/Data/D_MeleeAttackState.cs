/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Hold data for Melee Attack state for enemies
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: MeleeAttackState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class D_MeleeAttackState : ScriptableObject
{
    public float attackRadius = 0.5f;
    public LayerMask whatIsPlayer;
    public float attackDamage = 10;
}
