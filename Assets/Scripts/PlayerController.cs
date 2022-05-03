using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    [SerializeField]
    [Range(1,10)]
    private float speed;


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
    }

    private void Flip(bool status)
    {
        spriteRenderer.flipX = status;
    }

    private void FixedUpdate() {

        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
}