using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    public float damage;
    Vector3 target;
    Vector2 dirVec;
    Vector3 playerPos;
    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rigid.velocity = Vector2.zero;
        damage = GameManager.instance.player.endDamage;
        playerPos = GameManager.instance.player.transform.position;
        target = NearestTarget.target.transform.position;
        dirVec = (target - playerPos).normalized;
    }
    void FixedUpdate()
    {
        rigid.velocity = dirVec * speed;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dirVec);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
            gameObject.SetActive(false);
    }
}
