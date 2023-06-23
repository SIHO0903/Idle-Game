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
    GameObject coinObject;
    [SerializeField] int coinCount;
    int curCoinCount=0;
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
        curCoinCount= 0;
        health = maxHealth;
        coinCount = Random.Range(2, 4);
    }
    void Update()
    {
        rigid.velocity = dirVec * speed * Time.deltaTime;

    }
    void CoinPopUp()
    {
        coinObject = PoolManager.instance.PlayerGet(1);
        coinObject.transform.position = transform.position;
        curCoinCount++;
        if (curCoinCount >= coinCount)
            CancelInvoke("CoinPopUp");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            collision.gameObject.SetActive(false);
            health -= collision.GetComponent<Weapon>().damage;

            if (health <= 0)
            {
                InvokeRepeating("CoinPopUp", 0f, 0.1f);
                gameObject.SetActive(false);
            }
        }
    }
}
