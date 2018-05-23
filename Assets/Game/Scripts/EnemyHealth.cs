using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int m_MinCashDrop;
    [SerializeField] private int m_MaxCashDrop;
    public float m_MaxHealth = 40;
    public float m_Health;

    private void Start()
    {
        m_Health = m_MaxHealth;
    }
    public void TakeDamage(float Damage)
    {
        m_Health = m_Health - Damage;
        if (m_Health <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerStats>().m_Money += Random.Range(m_MinCashDrop, m_MaxCashDrop);
            Destroy(gameObject);
        }
    }
}
