using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public bool m_PoisonBullets = false;

    public float m_MaxHealth = 100;
    public float m_CurrentHealth;

    private float m_DamageModifier;
    private float m_ReloadModifier;
    private float m_SpeedModifier;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }


}
