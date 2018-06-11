using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : MonoBehaviour {
    [SerializeField] private float m_UpgradeCost;
    [SerializeField] private int m_MaxLevel;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) == true && other.CompareTag("Player"))
        {
            if (m_UpgradeCost * StatManager.m_Data.m_LuckLevel <= StatManager.m_Data.m_CurrentMoney && StatManager.m_Data.m_DamageLevel <= m_MaxLevel)
            {
                StatManager.m_Data.m_CurrentMoney -= m_UpgradeCost * StatManager.m_Data.m_LuckLevel;
                UpgradeEffect(other);
            }
            else if (m_UpgradeCost > StatManager.m_Data.m_CurrentMoney * StatManager.m_Data.m_LuckLevel)
            {
                // input not having enough money here
            }

        }
    }
    private void UpgradeEffect(Collider other)
    {
        StatManager.m_Data.m_LuckModifier += 1f;
        StatManager.m_Data.m_LuckLevel += 1;
    }
}
