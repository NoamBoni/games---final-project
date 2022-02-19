using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int helath = 100;
    public Text enemyText;
    public static int enemys = 4;
    private GameManager gm = GameManager.Instance;
    private Rigidbody2D rb;
    [SerializeField]
    public Transform player;
    [SerializeField]
    public float moveSpeed = 2f;
    private Vector2 movement;
    public float detectRange = 1f;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        enemyText = GameObject.Find("Canvas/EnemysLeft").GetComponent<Text>();
        enemyText.text = "Enemys Left: " + enemys;
    }

    private void Update() {
        float distsqr = (player.position - transform.position).sqrMagnitude;
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate() {
        float distsqr = (player.position - transform.position).sqrMagnitude;
        if (distsqr <= detectRange) {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void takeDamage(int damage)
    {
        helath -= damage;

        if (helath <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Destroy(this.gameObject);
        enemys--;
        enemyText.text = "Enemys Left: " + enemys;
        isWin();
    }

    private void isWin()
    {
        if(enemys == 0 && Coins.coins == 4)
        {
            gm.updateGameState(GameState.Victory);
        }
    }
}
