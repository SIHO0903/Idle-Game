using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] AnimatorOverrideController[] bossAnimators;
    [SerializeField] float attackRate;
    WaitForSeconds attackPointTime;
    float curAttackRate;

    int whichBoss;

    Animator anim;
    Enemy enemy;
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
    private void OnEnable()
    {
        whichBoss = Random.Range(-1, 4);
        if (whichBoss == -1)
            return;
        else
            anim.runtimeAnimatorController = bossAnimators[whichBoss];
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
        DamageText.Create(GameManager.instance.player.transform.position, enemy.damage);
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
