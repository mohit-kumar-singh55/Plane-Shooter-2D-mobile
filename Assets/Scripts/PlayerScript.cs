using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 10f;
    public float padding = 0.8f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    public GameObject explosion;
    public PlayerHealthBar playerHealthBar;

    public float health = 20f;
    float fillAmount = 1f;
    float damage = 0;

    public GameObject damageEffect;
    public CoinCount coinCount;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        FindBoundaries();
        damage = fillAmount / health;
    }

    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            fillAmount -= damage;
            playerHealthBar.SetAmount(fillAmount);
        }
    }

    // clamping player b/w the boundaries
    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        // moving player using Input Manager
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject effectDamage = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(effectDamage, 0.2f);
            if (health <= 0)
            {
                gameController.GameOver();
                Destroy(gameObject);
                GameObject blast = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(blast, 2f);
            }
        }

        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCount.AddCoin();
        }
    }
}
