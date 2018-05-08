using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    [SerializeField] float m_Damage;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(m_Damage);
        }
        DestroyObject(this.gameObject);
    }

    private void Start()
    {
        if (PlayerStats.m_PoisonBullets == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
