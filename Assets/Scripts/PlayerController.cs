using UnityEngine;

public class PlayerController : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public float speed;
    private Rigidbody2D rigidbody;
    private float horizontal;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        horizontal = Input.GetAxis("Horizontal");

        //var vector = horizontal > 0f ? new Vector2(1f, 0f) : new Vector2(-1f, 0f);
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

        var position = gameObject.transform.position;
        if(horizontal> 0.0f)
            rigidbody.AddForce(new Vector2(position.x + speed, 0.0f));
        if (horizontal < 0.0f)
            rigidbody.AddForce(new Vector2(position.x + speed * -1, 0.0f));
        Debug.Log(gameObject.transform.position);
    }
}