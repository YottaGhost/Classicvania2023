using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;

    GameObject player;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    void Update()
    {
        player = GameObject.FindWithTag("Player");
        AtaquePlayer chi = player.GetComponent<AtaquePlayer>();
        if (chi.block == false && chi.atacando == false){
            horizontal = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("speed", Mathf.Abs(horizontal));
            //animator.SetBool("Chao", IsGrounded);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
             rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();
        }else{rb.velocity =new Vector2(0,0);}
    }

    private void FixedUpdate()
    {
        player = GameObject.FindWithTag("Player");
        AtaquePlayer chi = player.GetComponent<AtaquePlayer>();
        if (chi.block == false && chi.atacando == false){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}