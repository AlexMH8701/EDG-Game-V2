using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = .02f;
    public float speed = 10f;
    public float jumpForce = 20f;
    private bool jump = false;
    private int numOfJumps = 0;
    private float horizontalMovement;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D player_collider;
    private bool grounded = true;
    [HideInInspector] public bool flipped = false;
	List<string> platformsToReset = new List<string>();
    public Animator animator;

    public PauseMenu PauseMenu;

    //checks to see if we need P1 or P2 controls
    public bool player1;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        player_collider = GetComponent<BoxCollider2D>();
        _rigidbody.gravityScale = 3;
    }
    void Update()
    {
         //makes sure the game is not paused before letting them move
        if (PauseMenu.GameIsPaused){
            return;
        }
            

        grounded = isGrounded();
        if (grounded)
        {
            numOfJumps = 0;
        }
        if (!grounded && !jump && numOfJumps == 0)
        {
            numOfJumps++;
        }

        if(player1){
            horizontalMovement = Input.GetAxisRaw("HorizontalP1") * speed;
        }else{
             horizontalMovement = Input.GetAxisRaw("HorizontalP2") * speed;
        }
        animator.SetFloat("walkSpeed", Mathf.Abs(horizontalMovement));
        if ((Input.GetKeyDown(KeyCode.W) && player1) || ((Input.GetKeyDown(KeyCode.I) && !player1)))
        {
            jump = true;
        }
        Flip();
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (jump && numOfJumps < 2)
        {
            if (numOfJumps == 1)
            {
                jumpForce = jumpForce - 3;
                _rigidbody.velocity = Vector2.up * jumpForce;
                jumpForce = jumpForce + 3;
            }
            else
            {
                _rigidbody.velocity = Vector2.up * jumpForce;
            }
            numOfJumps++;
        }
        jump = false;
    }

    private bool isGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(player_collider.bounds.center, player_collider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
		if (raycastHit.collider != null && raycastHit.collider.tag.Contains("FloatingPlatform")) {
			if ((Input.GetKeyDown(KeyCode.S))){
				platformsToReset.Add(raycastHit.collider.tag);
				sinkPlayer(raycastHit.collider.tag);
			}
		}
		if (raycastHit.collider == null || !raycastHit.collider.tag.Contains("FloatingPlatform")) {
			if (platformsToReset.Count > 0) {
				for (int i = platformsToReset.Count-1; i >= 0; --i) {
					GameObject.FindGameObjectWithTag(platformsToReset[i]).GetComponent<PlatformEffector2D>().rotationalOffset = 0;
				}
				platformsToReset.Clear();
			}
		}
		
		return raycastHit.collider != null;
    }

    private void Flip()
    {
        if (horizontalMovement > 0 && transform.localScale.x < 0 || horizontalMovement < 0 && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
            flipped = !flipped;
        }
    }

	void sinkPlayer(string platform) {
		GameObject.FindGameObjectWithTag(platform).GetComponent<PlatformEffector2D>().rotationalOffset = 180;
	}
	
}
