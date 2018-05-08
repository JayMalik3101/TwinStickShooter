using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float m_MaxHealth = 40;
    public float m_CurrentHealth;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }
    public void TakeDamage(float Damage)
    {
        m_CurrentHealth = m_CurrentHealth - Damage;
        if (m_CurrentHealth <= 0)
        {
            DestroyObject(this.gameObject);
        }
    }
}
