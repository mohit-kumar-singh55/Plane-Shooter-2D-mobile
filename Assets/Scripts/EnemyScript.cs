using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public GameObject enemyBullet;
    public Transform []gunPoint;
    public GameObject flash;
    public float bulletSpawnTime = 1f;
    public float speed = 2f;
    public GameObject enemyExplosionPrefab;
    public HealthBar healthBar;
    public float health = 10f;

    float barSize = 1f;
    float damage = 0;

    public GameObject damageEffect;
    public GameObject coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject effectDamage = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(effectDamage, 0.2f);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.5f);

                // spawning coin
                Instantiate(coin, transform.position, Quaternion.identity);
            }
        }
    }

    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
        damage = barSize / health;
    }

    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize -= damage;
            healthBar.SetSize(barSize);
        }
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    void Fire()
    {
        for (int i = 0; i < gunPoint.Length; i++)  {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
        }
    }

    // corutine
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            flash.SetActive(true);

            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }
}
