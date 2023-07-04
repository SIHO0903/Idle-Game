using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite[] enemySprites;
    [Header("# Status")]
    public float health;
    [SerializeField] float maxHealth;
    public float damage;
    public float speed;
    float curAttackRate;
    [SerializeField] float attackRate;
    [HideInInspector] public bool isBoss;
    Vector2 dirVec;

    Rigidbody2D rigid;

    CoinDrop coinDrop;
    HealthBar healthBar;
    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        coinDrop = GetComponent<CoinDrop>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    void Start()
    {
        dirVec = GameManager.instance.player.transform.position - transform.position;
    }
    private void OnEnable()
    {
        health = maxHealth;
        speed = 30;
    }
    void Update()
    {
        rigid.velocity = dirVec * speed * Time.deltaTime;
        healthBar.HealthBarUpdate(health, maxHealth);

        if(!GameManager.instance.player.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        if (!isBoss)
            curAttackRate -= Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            collision.gameObject.SetActive(false);
            health -= collision.GetComponent<Weapon>().damage;

            if (health <= 0)
            {
                GameManager.instance.killCount++;
                coinDrop.InvokeRepeatingCoinDrop();
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isBoss)
                return;

            if (curAttackRate < 0)
            {
                GameManager.instance.player.health -= damage;
                curAttackRate = attackRate;
            }
        }
    }
}
