using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public bool m_PoisonBullets = false;

    public float m_MaxHealth = 100;
    public float m_Money;
    public float m_CurrentHealth;
    public int m_CurrentKeyCards;
    public bool m_ArmourActive = false;

    private Text m_MoneyCount;
    private Text m_KilledByText;
    public bool ArmorActive
    {
        set
        {
            m_ArmourActive = value;
            if (value == true)
                m_ShieldAnimator.SetTrigger("Activate");
            else
                m_ShieldAnimator.SetTrigger("Deactivate");
        }
    }

    private float m_DamageModifier;
    private float m_ReloadModifier;
    private float m_SpeedModifier;

    private Animator m_ShieldAnimator;
    [SerializeField] private GameObject m_Shield;
    private void Start()
    {
        m_MoneyCount = GameObject.Find("MoneyCount").GetComponent<Text>();
        m_KilledByText = GameObject.Find("KilledBy").GetComponent<Text>();
        m_ShieldAnimator = m_Shield.GetComponent<Animator>();
        m_CurrentHealth = m_MaxHealth;
        m_MoneyCount.text = m_Money.ToString();
        m_Shield.SetActive(true);
    }

    private void Update()
    {
        TakeDamage(0, "Debugging");
        if (Input.GetKeyDown(KeyCode.U))
        {
            m_CurrentHealth = 9999999999;
        }
        m_MoneyCount.text = m_Money.ToString();
    }

    public void TakeDamage(float Damage, string Owner)
    {
        if (m_ArmourActive == false)
        {
            m_CurrentHealth = m_CurrentHealth - Damage;
        }
        if (Damage > 0 && m_ArmourActive == true)
        {
            ArmorActive = false;
        }


        if (m_CurrentHealth <= 0)
        {
            m_KilledByText.text = "Killed by: " + Owner;
            Destroy(gameObject);
        }
    }
}
