using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleHealthBar : MonoBehaviour {
    [SerializeField] private Image m_Bar;
    //public RectTransform m_Button; red knob 

  
    private float m_CurrentHealthValue, m_MaxHealth;

    private bool m_IsEnemy;

    private void Start() 
    {
        if (transform.parent.CompareTag("Enemy"))
        {
            m_IsEnemy = true;
            m_MaxHealth = GetComponentInParent<EnemyHealth>().m_MaxHealth;
        }
        if (transform.parent.CompareTag("Player"))
        {
            m_IsEnemy = false;
            m_MaxHealth = GetComponentInParent<PlayerStats>().m_MaxHealth;
            m_HealthValue = m_MaxHealth;
        }
    }

    void Update () {
        HealthChange(m_CurrentHealthValue);
	}

    private void HealthChange(float healthvalue)
    {
        if (m_IsEnemy == true)
        {
            m_CurrentHealthValue = GetComponentInParent<EnemyHealth>().m_CurrentHealth;
        }
        if (m_IsEnemy == false)
        {
            m_CurrentHealthValue = GetComponentInParent<PlayerStats>().m_CurrentHealth;
        }

        float amount = (healthvalue / m_MaxHealth);
        
        m_Bar.fillAmount = amount / 2f;
    }
}
