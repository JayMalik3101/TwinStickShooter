﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
    [SerializeField] private float m_ShotRange;
    [SerializeField] private float m_OriginalFireRate;
    [SerializeField] private Rigidbody m_Projectile;
    [SerializeField] private float m_InitialForce;
    [SerializeField] private Transform m_PlayerTransform;
    private Transform m_Origin;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 m_Direction;
    private float m_FireRate;


    // Use this for initialization
    void Start () {
        m_Origin = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_Direction = (m_PlayerTransform.position - m_Origin.position).normalized;
        m_FireRate -= Time.deltaTime;
        if (Physics.Raycast(m_Origin.position, m_Direction, out hit, m_ShotRange))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Rigidbody enemyProjectile = Instantiate(m_Projectile, m_Origin.position, m_Origin.rotation);
                enemyProjectile.AddForce(m_Origin.forward * m_InitialForce, ForceMode.Impulse);
                m_FireRate = m_OriginalFireRate;
            }
        }
    }
}
