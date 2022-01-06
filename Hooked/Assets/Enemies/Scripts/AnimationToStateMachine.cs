/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Helper class to allow animator to attack based on animation
 * GameObjects Associated: Enemy 1 and 2
 * Files Associated: Attack State
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{

    public AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
