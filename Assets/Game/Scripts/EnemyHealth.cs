using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private float m_Health = 40;

    public void TakeDamage(float Damage)
    {
        m_Health =- Damage;
    }

    private void Update()
    {
        if(m_Health <= 0)
        {
            DestroyObject(this.gameObject);
        }
    }
}
