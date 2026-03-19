using System.Collections;


using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;

using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour
{
    public int coins;
    public float movespeed = 5f;
    public float jumpForce = 10f;
    public int Health = 100;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image healthImage;
    private bool isGrounded;
    private Rigidbody2D rb;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public int extraJumpsValue = 1;
    public int extraJumps;
    
    private AudioSource audioSource;
    public AudioClip jumpclip;
    public AudioClip hurtClip;

    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        extraJumps = extraJumpsValue;
    }

    void Update()
    {

        if(isGrounded)
        {
            extraJumps=extraJumpsValue;
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * movespeed, rb.linearVelocityY);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                 rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
                 PLaySFX(jumpclip);
            }
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
                extraJumps--;
                PLaySFX(jumpclip);
            }
           
        }
        SetAnimation(moveInput);

        healthImage.fillAmount = Health/100f;
    }

    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if(moveInput == 0)
            {
               animator.Play("Player_anim"); 
            }
            else
            {
                animator.Play("PLayer_Run");
            }
        }
        else
        {
            if(rb.linearVelocityY > 0)
            {
                animator.Play("jump");
            }
            else
            {
                animator.Play("player_fall");
            }
        }
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            PLaySFX(hurtClip);
            Health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            StartCoroutine(BlinkRed());
            if (Health <= 0)
            {
                Die();
            }
        }

    } 
    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds (0.1f);
        spriteRenderer.color = Color.white;
    }
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void PLaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
