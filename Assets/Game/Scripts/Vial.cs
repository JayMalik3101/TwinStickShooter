using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vial : MonoBehaviour {
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) == true)
        {
            PlayerStats.m_PoisonBullets = true;
            DestroyObject(this.gameObject);
        }
    }

}
