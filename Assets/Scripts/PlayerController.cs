using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [Header("Jhon")]
    public SpriteRenderer spriteRenderer;
    [Header("Velocidad y Fuerza")]
    [SerializeField]
    [Range(1,10)]
    private float speed;
    [SerializeField]
    [Range(300,500)]
    [Min(300)]
    private float jumpForce;

    [SerializeField]
    private bool isJump;


    private Rigidbody2D rigidbody;
    private float horizontal;
    [Header("Animaciones")]
    [SerializeField]
    private Animator animator;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        horizontal = Input.GetAxis("Horizontal");

        //var vector = horizontal > 0f ? new Vector2(1f, 0f) : new Vector2(-1f, 0f);

        animator.SetBool("isRun", horizontal != 0.0f);

        if (horizontal > 0.0f)
            Flip(false);

        if (horizontal < 0.0f)
            Flip(true);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!isJump)
                Jump();
        }
    }

    private void Flip(bool status)
    {
        spriteRenderer.flipX = status;
    }
    private void Jump()
    {
        rigidbody.AddForce(Vector2.up * jumpForce);
        isJump = true;
        Debug.Log("saltando sin parar....");
    }

    private void FixedUpdate() {

        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = !(collision.collider.tag == "Floor");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}