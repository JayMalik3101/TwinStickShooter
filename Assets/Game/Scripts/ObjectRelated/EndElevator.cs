using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndElevator : MonoBehaviour
{
    private Animator m_ElevatorAnimator;
    private void Start()
    {
        m_ElevatorAnimator = GetComponent<Animator>();
        m_ElevatorAnimator.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) == true && other.CompareTag("Player"))
        {
            StatManager.SaveStats();
            m_ElevatorAnimator.enabled = true;
        }
    }
	
}
