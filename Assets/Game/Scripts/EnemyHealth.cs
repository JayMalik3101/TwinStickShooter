using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public float m_Health = 40;

    public void TakeDamage(float Damage)
    {
        m_Health = m_Health - Damage;
        if (m_Health <= 0)
        {
            DestroyObject(this.gameObject);
        }
    }
}
