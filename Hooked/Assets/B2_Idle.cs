/*---------The Platformers-------
 * Contributors: Mario
 * Prupose: Hanlde boss idle state. Randomizes next state. Can move to move or attack state
 * GameObjects associated: Boss 2
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;
using Random = UnityEngine.Random;

public class B2_Idle : StateMachineBehaviour
{
    
    private float startTime;
    [SerializeField] private float waitInIdle = 1f;
    [SerializeField] private string[] state;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time >= startTime + waitInIdle)
        {
           RandomAction(animator);
        }
    }

    private void RandomAction(Animator anim)
    {
        int index = Random.Range(0, state.Length);
        anim.SetTrigger(state[index]);
        // switch (index)
        // {
        //     case 0: anim.SetTrigger("FireOrb");
        //         break;
        //     case 1: anim.SetTrigger("Move");
        //         break;
        //     case 2: anim.SetTrigger("FireLaser");
        //         break;
        //     default: break;
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("FireOrb");
        animator.ResetTrigger("Move");
        animator.ResetTrigger("FireLaser");
    }


}
