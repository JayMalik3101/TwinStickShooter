using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotFire : MonoBehaviour {
    [SerializeField] private float m_InitialForce = 1500;
    [SerializeField] private Transform m_Origin;
    [SerializeField] private Rigidbody m_Projectile;
    [SerializeField] private float m_OriginalTimeForReload;

    private float m_TimeForReload;

    private void Start()
    {
        m_TimeForReload = m_OriginalTimeForReload;
    }
    private void Update()
    {
        m_Origin = this.transform;
        m_TimeForReload -= Time.deltaTime;
        if (Input.GetMouseButton(0) && m_TimeForReload <= 0)
        {
            Rigidbody newProjectile = Instantiate(m_Projectile, m_Origin.position, m_Origin.rotation);
            newProjectile.GetComponent<Renderer>().material.color = GetComponentInParent<PlayerStats>().m_PoisonBullets ? Color.green : Color.white; 
            newProjectile.AddForce(transform.forward * m_InitialForce, ForceMode.Impulse);
            m_TimeForReload = m_OriginalTimeForReload;
        }
    }
}
