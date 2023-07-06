using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float alphaSpeed;
    [SerializeField][Range(0, 1f)] float disappearSpeed;
    TextMeshPro text;
    Color alpha;
    void Awake()
    {
        text= GetComponent<TextMeshPro>();
        alpha = text.color;
    }
    private void OnEnable()
    {
        alpha.a = 1;
    }
    void Update()
    {
        transform.Translate(new Vector3(0,moveSpeed*Time.deltaTime,0));
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        text.color = alpha;
        if(alpha.a<= disappearSpeed)
            gameObject.SetActive(false);
    }
    void SetUp(float damage)
    {
        text.text = damage.ToString();
    }
    public static DamageText Create(Vector2 pos, float damage)
    {
        GameObject damageTextObj = PoolManager.instance.PlayerGet(3);
        DamageText damageText = damageTextObj.GetComponent<DamageText>();
        damageTextObj.transform.position = pos + Vector2.up * 1f;
        damageText.SetUp(damage);
        return damageText;
    }
}
