using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite[] enemySprites;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] float damage;
    [SerializeField] float speed;

    Vector2 dirVec;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        dirVec = GameManager.instance.player.transform.position - transform.position;
    }
    private void OnEnable()
    {
        health = maxHealth;
    }
    void Update()
    {
        rigid.velocity = dirVec * speed * Time.deltaTime;
        if (health <= 0)
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            collision.gameObject.SetActive(false);
            health -= collision.GetComponent<Weapon>().damage;
        }
    }
}
