using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
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

    private void Update()
    {
       
        if (PlayerStats.m_PoisonBullets == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
