/*---------The Platformers-------
 * Contributors: Mario
 * Prupose: Boss movement towards player and determines next state to move to based on distance
 *  between player and boss
 * GameObjects associated: Boss, Player
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;

public class B1_Run : StateMachineBehaviour
{

    [SerializeField] private D_BossData bossData;
    private Transform player;
    private Boss boss;
    private Rigidbody2D rb;
    private float distance;
    
    private float startTime;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        startTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.transform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossData.moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        distance = Vector2.Distance(player.position, rb.position);
        
        if (distance <= bossData.closeRangeAttackRadius && Time.time >= startTime + bossData.closeRangeAttackCoolDown)
        {
            animator.SetTrigger("CloseRangeAttack");
        }
        else if (distance >= bossData.longRangeAttackRadius && Time.time >= startTime + bossData.longRangeAttackCoolDown)
        {
            animator.SetTrigger("LongRangeAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("LongRangeAttack");
        animator.ResetTrigger("CloseRangeAttack");
        
    }


}
