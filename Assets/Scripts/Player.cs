using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# Status")]
    public float damage;
    public float endDamage;
    public float health;
    public float maxHealth;
    public float healthRecovery;
    [SerializeField] float healthRecoveryRate;
    float curhealthRecoveryRate;
    public float criticalChance;
    public float criticalDamage;
    public float fireRate;
    public float curFireRate;
    public bool isLive=true;

    float randCritical;
    GameObject dagger;
    Animator anim;
    HealthBar healthBar;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    void Start()
    {
        curFireRate = fireRate;
        health = maxHealth;
    }

    void Update()
    {
        TryAttack();
        Attack();
        HealthRecovery();
        Dead();
        healthBar.HealthBarUpdate(health, maxHealth);

    }

    void Dead()
    {
        if (health <= 0)
        {
            isLive= false;
            gameObject.SetActive(false);
        }
    }
    void TryAttack()
    {
        if (isLive)
            curFireRate -= Time.deltaTime;
    }
    private void Attack()
    {
        if (curFireRate <= 0 && NearestTarget.target != null)
        {
            CriticalHit();
            dagger = PoolManager.instance.PlayerGet(0);
            dagger.transform.position = transform.position;
            curFireRate = fireRate;
        }
    }
    void HealthRecovery()
    {
        curhealthRecoveryRate -= Time.deltaTime;
        if (health < maxHealth && curhealthRecoveryRate < healthRecoveryRate)
        {
            health += healthRecovery;
        }
        if (health > maxHealth)
            health = maxHealth;
    }
    void CriticalHit()
    {
        randCritical = Random.Range(0f, 1f);
        if(criticalChance/100 >= randCritical)
        {
            endDamage = damage + damage * criticalDamage;
        }
        else
        {
            endDamage = damage;
        }
    }
    public void PlayerDamaged()
    {
        anim.SetTrigger("Damaged");
    }
}
