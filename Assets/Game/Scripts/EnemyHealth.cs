using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int m_MinCashDrop = 10;
    [SerializeField] private int m_MaxCashDrop = 50;
    public float m_MaxHealth = 40;
    public float m_Health;
    private PlayerStats m_PlayerStats;
    //private StatManager m_StatManager;

    private void Start()
    {
        m_Health = m_MaxHealth;
        m_PlayerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        //m_StatManager = GameObject.Find("StatManager").GetComponent<StatManager>();
    }
    public void TakeDamage(float Damage)
    {
        m_Health = m_Health - Damage;
        if (m_Health <= 0)
        {
            int cashDrop = Random.Range(m_MinCashDrop, m_MaxCashDrop);
            m_PlayerStats.m_Money += cashDrop;
           // if (StatManager != null)
           // {
                StatManager.m_Data.m_TotalCashEarned += cashDrop;
                //m_StatManager.m_TotalCashEarned += cashDrop;
            //}
            Destroy(gameObject);
        }
    }
}
