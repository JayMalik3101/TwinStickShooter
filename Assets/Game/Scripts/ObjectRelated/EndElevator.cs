using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndElevator : MonoBehaviour
{
    [SerializeField] private float m_ElevatorGoal;
    private Transform m_ElevatorTransform;
    private bool m_GoingUp = false;

    private void Start()
    {
        m_ElevatorTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position.y <= m_ElevatorGoal && m_GoingUp == true) {
            m_ElevatorTransform.position = new Vector3(m_ElevatorTransform.position.x, m_ElevatorTransform.position.y + 2 * Time.deltaTime, m_ElevatorTransform.position.z);
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) == true && other.CompareTag("Player"))
        {
            m_GoingUp = true;
        }
    }
}
