using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("# Status")]
    public float damage;
    public float endDamage;
    public float health;
    public float baseHealth;
    public float maxHealth;
    public float healthRecovery;
    [SerializeField] float healthRecoveryRate;
    float curhealthRecoveryRate;
    public float criticalChance;
    public float criticalDamage;
    public float fireRate;
    public float curFireRate;
    public bool isLive=true;

    public Vector3 playerPos;
    float randCritical;
    GameObject dagger;
    Animator anim;
    HealthBar healthBar;

     public float mountingDamage1;
     public float mountingDamage2;
     public float retentionDamage1;
     public float retentionDamage2;

     public float mountingHealth1;
     public float mountingHealth2;
     public float retentionHealth1;
     public float retentionHealth2;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    void Start()
    {
        playerPos = new Vector3(transform.position.x, transform.position.y, 0);
        curFireRate = fireRate;
        baseHealth = health;
        health = maxHealth;
        endDamage = damage;
    }

    void Update()
    {
        TryAttack();
        Attack();
        HealthRecovery();
        Dead();
        healthBar.HealthBarUpdate(health, maxHealth);
        DamageUpdate();
        HealthUpdate();
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
            dagger = PoolManager.instance.Get(PoolManager.PrefabType.Player, 0);
            dagger.transform.position = playerPos;
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
    }
    public void PlayerDamaged()
    {
        anim.SetTrigger("Damaged");
    }
    void DamageUpdate()
    {
        if ((mountingDamage1 + mountingDamage2 + retentionDamage1 + retentionDamage2) / 100 == 0)
            return;
        endDamage = damage * (mountingDamage1+ mountingDamage2+retentionDamage1+retentionDamage2)/100;
    }
    void HealthUpdate()
    {
        if ((mountingHealth1 + mountingHealth2 + retentionHealth1 + retentionHealth2) / 100 == 0)
            return;
        maxHealth = baseHealth * (mountingHealth1+ mountingHealth2+retentionHealth1+retentionHealth2)/100;
    }
}
