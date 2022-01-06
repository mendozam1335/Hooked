/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Parent class for Enemies RangedAttack state. Inherits from AttackState
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: AttackState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class RangedAttackState : AttackState
{
    protected D_RangedAttackState stateData;

    protected GameObject projectile;
    protected Projectile projectileScript;
    
    public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attacakPosition, D_RangedAttackState stateData) : base(entity, stateMachine, animBoolName, attacakPosition)
    {
        this.stateData = stateData;
    }
    
    public override void FinishAttack()
    {
        base.FinishAttack();

        projectile = GameObject.Instantiate(stateData.projectile, attacakPosition.position, attacakPosition.rotation);
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
    }
}
