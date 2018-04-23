using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {


    [SerializeField] public static bool m_PoisonBullets = false;
    
    private float m_DamageModifier;
    private float m_ReloadModifier;
    private float m_MaxHealth;
    private float m_SpeedModifier;

}
