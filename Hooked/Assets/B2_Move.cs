/*---------The Platformers-------
 * Contributors:  Mario
 * Prupose: Randomly chooses between 1 and 3 points on the map to move between every time.
 *  Then transitions to attack the player. Calls Boss class to always face the player
 * GameObjects associated: Boss 2, Player
 * Files Associated: WaypointLinker
 * Source:
 *--------------------------------*/
using System.Collections.Generic;
using UnityEngine;

public class B2_Move : StateMachineBehaviour
{

    private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private Boss2 boss2;
    private Rigidbody2D rb;
    private int currentWaypointIndex = 0;
    private Queue<int> nextWayPoint;
    private Transform nextPoint;
    [SerializeField] private D_BossData bossData;
    private int count;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextWayPoint = new Queue<int>();        
        rb = animator.GetComponent<Rigidbody2D>();
        boss2 = animator.GetComponent<Boss2>();
        if (waypoints == null)
        {
            waypoints = animator.gameObject.GetComponent<B2_WaypointLinker>().waypoints;
            foreach (var waypoint in waypoints)
            {
                Debug.Log(waypoint.gameObject.name);
            }
        }

        count = Random.Range(1, 4);
        for (int i = 0; i < count ; i++)
        {
            nextWayPoint.Enqueue(Random.Range(0,waypoints.Length));
        }

        currentWaypointIndex = nextWayPoint.Dequeue();
        count--;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2.LookAtPlayer();
        
        nextPoint = waypoints[currentWaypointIndex].transform;
       
        //Reached next waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, rb.position) < .1f)
        { 
            if (count == 0 )
            {
                animator.SetTrigger("FireOrb");
                return;
            }
            currentWaypointIndex = nextWayPoint.Dequeue();
            nextPoint = waypoints[currentWaypointIndex].transform;
            count--;
        }
        
            Vector2 target = new Vector2(nextPoint.position.x, nextPoint.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossData.moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("FireOrb");
    }


}
