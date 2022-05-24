using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IMove {

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

    [Header("Animaciones")]
    [SerializeField]
    private Animator animator;
    [Header("Hub personaje")]
    [SerializeField]
    private GameObject personHub;

    private Rigidbody2D rigidbody;
    private float horizontal;

    [Header("Image Hub personaje")]
    [SerializeField]
    private Image imgHub;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        
    }

    private void Flip(bool status)
    {
        spriteRenderer.flipX = status;
    }
    private void Jump()
    {
        rigidbody.AddForce(Vector2.up * jumpForce);
        isJump = true;
    }

    private void setNameHub(string text){
        personHub.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
    }

    private void FixedUpdate() {
        horizontal = Input.GetAxis("Horizontal");


        animator.SetBool("isRun", horizontal != 0.0f);

        if (horizontal > 0.0f) Flip(false);
        if (horizontal < 0.0f) Flip(true);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!isJump)
                Jump();
        }

        Move();

        setNameHub($"Vel: {Mathf.FloorToInt(rigidbody.velocity.x)} - {Mathf.FloorToInt(rigidbody.velocity.y)}\n{isJump}");
    }

    private IEnumerator Slow(float tempSpeed)
    {
        while (isJump)
        {
            tempSpeed -= 2;
            rigidbody.velocity = new Vector2(horizontal * tempSpeed, rigidbody.velocity.y);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = !(collision.collider.tag == "Floor");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ammo")
            return;

        var spriteTemp = collision.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(collision.name);
        imgHub.overrideSprite = spriteTemp.sprite;
        Destroy(collision.gameObject);
        Debug.Log(collision.name);
    }

    public void Move()
    {
        Debug.DrawRay(transform.position, Vector2.down * 1.4f, Color.green);

        var hit2D = Physics2D.Raycast(transform.position, Vector2.down, 1.4f);
        if (hit2D.collider != null && hit2D.collider.tag == "Floor")
        {
            Debug.Log("Esta en piso");
            rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
            return;
        }
        Debug.Log("Saltando?");

        Slow(speed);
    }
}