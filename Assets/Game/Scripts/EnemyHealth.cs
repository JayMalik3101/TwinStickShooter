using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
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
            Destroy(gameObject);
        }
    }
}
