using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    [SerializeField]
    private float playerSpeed = 10f;
    [SerializeField]
    private float jump = 20f;
    private Animator animator;
    private BoxCollider2D box;
    [SerializeField]
    private float climbspeed = 2f;
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public int currentHelath;
    [SerializeField]
    public HelathBar helathBar;
    private GameManager gm = GameManager.Instance;
    [SerializeField]
    public Shoot shoot;
    [SerializeField]
    public Transform firePoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        currentHelath = maxHealth;
        helathBar.setMaxHelath(maxHealth);

    }

    void Update()
    {
        run();
        flip();
        climb();
        pauseMenu();
        isDead();
    }

    private void OnMove(InputValue v)
    {
        moveInput = v.Get<Vector2>();

    }

    private void run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * playerSpeed,rb.velocity.y);
        rb.velocity = playerVelocity;
        bool hasHorSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", true);
        if(!hasHorSpeed)
        {
            animator.SetBool("Running", false);
        }
    }

    private void flip()
    {
        bool hasHorSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(hasHorSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
            if (transform.localScale[0] != firePoint.localScale[0])
            {
                firePoint.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
                firePoint.Rotate(0,180,0);
            }
        }

        
    }

    private void OnJump(InputValue v)
    {
        if(!box.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        if(v.isPressed)
        {
            rb.velocity += new Vector2(0f,jump);
        }
    }

    private void climb()
    {
        if(!box.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            animator.SetBool("Climb", false);
            return;

        }
        Vector2 climbVelocity = new Vector2 (rb.velocity.x, moveInput.y * climbspeed);
        rb.velocity = climbVelocity;
        animator.SetBool("Climb", true);

    }

    private void pauseMenu()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            gm.updateGameState(GameState.PauseMenu);
        }

    }

    private void takeDamage(int damage){
        currentHelath -= damage;
        helathBar.setHelath(currentHelath);
    }

    private bool gainHelath(int amount){
        if(currentHelath + amount <= maxHealth)
        {
            currentHelath += amount;
            helathBar.setHelath(currentHelath);
            return true;
        }
        return false;

    }

    public void isDead()
    {
        if (currentHelath <= 0)
        {
            gm.updateGameState(GameState.Death);
        }
    }

    public void grabAmmo(int amount){
        shoot.updateAmmo(amount);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "Ammo"){
            Destroy(other.gameObject);
            grabAmmo(10);
        }


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            takeDamage(15);
        }

        if (other.gameObject.tag == "Lava"){
            takeDamage(10);
        }

        if (other.gameObject.tag == "Mushroom"){
            if(gainHelath(40))
                Destroy(other.gameObject);
        }
    }
    
}
