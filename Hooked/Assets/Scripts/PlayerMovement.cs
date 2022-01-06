/*---------The Platformers-------
 * Contributors: Patrick, Mario Mendoza
 * Prupose: Main class to handle player movements and animation transitions. Also handles if the
 *	player falls of the map. Calls gameover if dead and respawn if falls of map.
 * GameObjects: FallDetector, grapple Gun
 * Files Associated: PlayerEnum, Player stat
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	//start Patrick's additions
	public static bool isCutscene;
	public float movementSpeed;
	public Rigidbody2D rb;
	
	
	public float jumpForce = 10f;
	public Transform feet;
	public LayerMask groundLayers;
	private BoxCollider2D coll;

	private PlayerStats playerStatsObject;   //use for player taking damage

	private float mx = 0f;
	//end Patrick's additions

	private Animator anim;

	//use for respawning player when hitting fallDetector- Patrick Sepnio
	private Vector3 respawnPoint;
	public GameObject fallDetector;

	private PlayerEnums state;
	private bool isFlipped;
	private Tutorial_GrapplingGun grapplGunScript;
	private void Start()
	{
		//healthBar.SetMaxHealth(maxHealth);
		coll = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		isFlipped = false;
		grapplGunScript = GetComponentInChildren<Tutorial_GrapplingGun>();

		respawnPoint = transform.position;//have fallDetector follow the player

		playerStatsObject = GetComponent<PlayerStats>();
		isCutscene = false;
	}

	// Update is called once per frame
    void Update()
    {
	    if (!isCutscene)
	    {
			//start Patrick's additions
		    mx= Input.GetAxisRaw("Horizontal");
		
		    if (Input.GetButtonDown("Jump") && IsGrounded()){
			
			    Jump();
		    }
		    //fallDetector will follow the player on the X axis
		    fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
			//end Patrick's additions
	    }
	    else
	    {
		    mx = 0f;
	    }
	    UpdateAnimation();
	}  //end update method
	
	//start Patrick's additions
	private void FixedUpdate(){
		Vector2 movement = new Vector2(mx*movementSpeed, rb.velocity.y);
		rb.velocity = movement;
	} //end FixedUpdate method
	
	void Jump(){
		Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
		
		rb.velocity = movement;
	} //end jump method
	
	public bool IsGrounded(){
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayers);
	} //IsGrounded boolean variable
	//end Patrick's additions

	/**Update the animator based on what the player is doing. Uses PlayerEnums to more accurately transition between  */
	private void UpdateAnimation()
	{

		if (PlayerStats.isDead)
		{
			state = PlayerEnums.Dead;
		}
		// will flip if goign right and jason is looking left
		else if (mx > 0f)
		{
			state = PlayerEnums.Moving;
			if (isFlipped)
			{
				Flip();
				isFlipped = false;
			}
		}
		//will flip if going left and jason is facing right
		else if (mx < 0f)
		{
			state = PlayerEnums.Moving;
			if (!isFlipped)
			{
				Flip();
				isFlipped = true;
			}
		}
		//Only fire arrows iif not in cutscene 
		else if (Input.GetButtonDown("Fire2") && !isCutscene)
		{
			int quadrant = CheckQuadrant();
			Debug.Log(Tutorial_GrapplingGun.currentAngle);
			if (!isFlipped && (quadrant == 1 || quadrant == 2))
			{ //if the player is facing right and shooting left
				Flip();
				isFlipped = true;
			}

			if (isFlipped && (quadrant == 0 || quadrant == 3))
			{ //if the player is facing left and shooting right. this code works-Pat
				Flip();
				isFlipped = false;
			}

			state = PlayerEnums.Attacking;

		}
		else
		{
			state = PlayerEnums.Idle;
		}
		anim.SetInteger("state", (int)state);
	}

	/**Flip the sprite of the player to face the direction he is moving. Only flips on the y axis*/
	private void Flip()
	{
		transform.Rotate(0f, 180f, 0f);
	}

	private int CheckQuadrant()
	{
		float an = Tutorial_GrapplingGun.currentAngle;
		if (an >= 1 && an <= 91)
		{
			return 0;
		}
		else if (an >= 91 && an <= 179)
		{
			return 1;
		}
		else if (an >= -179 && an <= -91)
		{
			return 2;
		}
		else if (an >= -91 && an <= -1)
		{
			return 3;
		}
		else
			return 4;
	}

	public void Attack()
	{
		grapplGunScript.Attack();
	}

	//for fallDetector, detects collision when one object enters another objects collider- 
	//Method added by Patrick Sepnio
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "FallDetector")
		{
			transform.position = respawnPoint;
			playerStatsObject.Damage(10);
		}
		else if (collision.tag == "Checkpoint")
		{
			respawnPoint = transform.position;  //this updates the respawn point to the checkpoint
		}
	}

	/**Used by Timeline to stop player movement when a cutscene is playing.
	 * isCutscene is true at the begining of the cutscene and false at the end.
	 */
	public void toggleMovement()
	{
		isCutscene = !isCutscene;
	}

	/**Called by animator after death animation is player. Will set player at respawn point and reset his health.
	 * Triggers respawn in animator to exit from his current animation and reset animator.
	 */
	public void Respawn()
	{
		transform.position = respawnPoint;
		PlayerStats.isDead = false;
		playerStatsObject.resetHealth();
		anim.SetTrigger("respawn");
	}

	public void GameOver(string gameOver)
	{
		PlayerStats.isDead = false;
		playerStatsObject.resetHealth();
		anim.SetTrigger("respawn");
		SceneManager.LoadScene(gameOver);
	}


} //end playermovement script
