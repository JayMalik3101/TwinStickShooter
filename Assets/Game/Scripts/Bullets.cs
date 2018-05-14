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
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamge(m_Damage);
        }
        Destroy (gameObject);
    }


}
