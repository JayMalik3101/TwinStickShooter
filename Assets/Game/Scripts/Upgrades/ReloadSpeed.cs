using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadSpeed : MonoBehaviour {
    [SerializeField] private float m_UpgradeCost;
    [SerializeField] private int m_MaxLevel;
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) == true && other.CompareTag("Player"))
        {
            if (m_UpgradeCost * StatManager.m_Data.m_ReloadLevel <= StatManager.m_Data.m_CurrentMoney && StatManager.m_Data.m_ReloadLevel <= m_MaxLevel)
            {
                StatManager.m_Data.m_CurrentMoney -= m_UpgradeCost * StatManager.m_Data.m_ReloadLevel;
                UpgradeEffect(other);
            }
            else if (m_UpgradeCost * StatManager.m_Data.m_ReloadLevel > StatManager.m_Data.m_CurrentMoney)
            {
                // input not having enough money here
            }

        }
    }
    private void UpgradeEffect(Collider other)
    {
        StatManager.m_Data.m_ReloadModifier -= 0.1f;
        StatManager.m_Data.m_SpeedLevel += 1;
    }
}
