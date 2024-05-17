using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [Header("���� ������")]
    [SerializeField]
    private float AttackDamage;

    List<GameObject> targets = new List<GameObject>();

    private CapsuleCollider CapsuleCollider;

    [Header("�ִ� ���� ����")]
    [SerializeField]
    private float AttackArea;

    public float damage { get { return AttackDamage; } }

    //��� �ð�
    private float timer;
    private void Awake()
    {
        CapsuleCollider = GetComponent<CapsuleCollider>();        
    }

    private void OnEnable()
    {
        targets.Clear();
        CapsuleCollider.radius = 0;
        CapsuleCollider.enabled = true;

        StartCoroutine(AugmentAttackArea());
        StartCoroutine(PlayAnimation());
    }

    private void FixedUpdate()
    {
        foreach (var target in targets)
        {
            Debug.Log($"{target.name}���� {AttackDamage}��ŭ�� ������ �ο�");
        }
    }
    

    IEnumerator AugmentAttackArea()
    {
        while(CapsuleCollider.radius < AttackArea)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            CapsuleCollider.radius += 1.5f * Time.deltaTime;            
        }
        CapsuleCollider.enabled = false;
        targets.Clear();
        yield break;
    }

    IEnumerator PlayAnimation()
    {
        while (timer < 30)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            timer += Time.deltaTime;
        }

        transform.parent.gameObject.SetActive(false);
        yield break;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, CapsuleCollider.radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Untagged")) return;
        if(!targets.Contains(other.gameObject))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }

    void OnDisable()
    {
        ItemObjectPool.ReturnToPool(transform.parent.gameObject);
    }
}