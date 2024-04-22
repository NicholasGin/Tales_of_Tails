using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private TrailRenderer tr;
  
    private bool canDash = true;
    private bool isDashing;
    public float dashPower = 24f;
    public float dashTime = 0.2f;

    public float cooldown = 1f;


    public LayerMask jumpableGround;

    private float dirX = 0f;
    public float moveSpeed;
    public float jumpForce;

  private bool isFacingRight;
  private bool isFacingLeft;
    


  private enum MovementState { idle, running, jumping }

    [SerializeField] private AudioSource jumpSFX;

		// Start is called before the first frame update
		private void Awake()
		{
        DontDestroyOnLoad(this.gameObject);
		}
		private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponent<SpriteRenderer>();
    coll = GetComponent<BoxCollider2D>();
    tr = GetComponent<TrailRenderer>(); 
    
  }

  // Update is called once per frame
  private void Update()
  {
    

    if (isDashing)
    {
      return;
    }
    dirX = Input.GetAxisRaw("Horizontal");

    rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

    if (Input.GetButtonDown("Vertical") && IsGrounded()) // takes from unity project structure
    {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
    {
            Debug.Log("dash");
      StartCoroutine(Dash());
    }

    UpdateAnimationState();

  }

  private void UpdateAnimationState()
  {
    MovementState state;
    if (dirX > 0f)
    {
      state = MovementState.running;
      sprite.flipX = false;

    }
    else if (dirX < 0f)
    {
      state = MovementState.running;
      sprite.flipX = true;
    }
    else
    {
      state = MovementState.idle;
    }

    if (rb.velocity.y > 0.1f)
    {
      state = MovementState.jumping;
    }

        anim.SetInteger("state", (int)state);
    }

  private bool IsGrounded()
  {
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
  }

  private IEnumerator Dash()
  {
    canDash = false;
    isDashing = true;
    float ogGravity = rb.gravityScale;
    rb.gravityScale = 0f;
    tr.emitting = true;
    rb.velocity = new Vector2(rb.velocity.x * dashPower, 0f);
    yield return new WaitForSeconds(dashTime);
    tr.emitting = false;
    rb.gravityScale = ogGravity;
    isDashing = false;
    yield return new WaitForSeconds(cooldown);
    canDash = true;
  }
}
