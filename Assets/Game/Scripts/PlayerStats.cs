using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public bool m_PoisonBullets = false;

    public float m_MaxHealth = 100;
    public float m_CurrentHealth;
    public int m_CurrentKeyCards;
    public bool m_ArmourActive = false;

    private float m_DamageModifier;
    private float m_ReloadModifier;
    private float m_SpeedModifier;

    GameObject m_DeathMenu;
    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
        m_DeathMenu = GameObject.Find("DeathMenu");
        m_DeathMenu.SetActive(false);
    }

    private void Update()
    {
        TakeDamge(0);
        if (Input.GetKeyDown(KeyCode.U))
        {
            m_CurrentHealth = 9999999999;
        }
    }

    public void TakeDamge(float Damage)
    {   if(m_ArmourActive == false)
        {
            m_CurrentHealth = m_CurrentHealth - Damage;
        }
        if(Damage > 0 && m_ArmourActive == true)
        {
            m_ArmourActive = false;
        }
        
        
        if (m_CurrentHealth <= 0)
        {   
            m_DeathMenu.SetActive(true);

            Destroy(gameObject);
        }
    }
}
