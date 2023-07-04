using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator anim;
    Enemy enemy;
    [SerializeField] float attackRate;
    WaitForSeconds attackPointTime;
    float curAttackRate;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();
        attackPointTime = new WaitForSeconds(0.35f);
    }
    private void Start()
    {
        curAttackRate = attackRate;
        enemy.isBoss= true;
    }
    void Update()
    {
        curAttackRate -= Time.deltaTime;
        if (anim.GetBool("isTouch"))
        {
            enemy.speed = 0;
            if (curAttackRate <= 0)
            {
                anim.SetTrigger("Attack");
                StartCoroutine(AttackPoint());
                curAttackRate = attackRate;
            }
        }
    }
    IEnumerator AttackPoint()
    {
        yield return attackPointTime;
        GameManager.instance.player.health -= enemy.damage;
        GameManager.instance.player.PlayerDamaged();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("isTouch", true);

        }
    }
}
