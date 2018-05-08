using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour {
    [SerializeField] private List<Transform> m_WayPoints;
    [SerializeField] private Transform m_PlayerTransform;
    [SerializeField] [Range(5f, 30f)] private float m_RayLength;

    private Transform m_GuardTransform;
    /*
    private Ray ray;
    private RaycastHit hit;
    private Vector3 m_Direction;
    private NavMeshAgent m_NavMesh;
    private int m_Location;
    private string m_TargetName;

    private int m_GoTo = 0;
    // Use this for initialization
    void Start () {
        m_NavMesh = GetComponent<NavMeshAgent>();
        m_NavMesh.SetDestination(m_PostOne.position);
        m_TargetName = m_PlayerLocation.name;
    }
	
	// Update is called once per frame
	void Update () {
        m_Direction = (m_PlayerLocation.position - m_GuardLocation.position).normalized;

        if (Physics.Raycast(m_GuardLocation.position, m_Direction, out hit, m_RayLength))
        {
            if (hit.transform.name == m_TargetName)
            {
                Debug.DrawLine(m_GuardLocation.position, m_PlayerLocation.position, Color.red);
            }
            else if (hit.transform.name == "Obstacle")
            {
                Debug.DrawLine(m_GuardLocation.position, m_PlayerLocation.position, Color.grey);
            }

            if (hit.transform.name == m_TargetName)
            {
                m_NavMesh.SetDestination(m_PlayerLocation.position);
            }
            else if (m_Location == 1)
            {
                m_NavMesh.SetDestination(m_PostOne.position);
            }
            else if (m_Location == 2)
            {
                m_NavMesh.SetDestination(m_PostTwo.position);
            }
        }
        else
        {
            Debug.DrawLine(m_GuardLocation.position, m_PlayerLocation.position, Color.green);
        }
       


        
        

        if (m_GuardLocation.position.x >= m_PostOne.position.x -10 && m_GuardLocation.position.x <= m_PostOne.position.x + 10 && m_GuardLocation.position.z >= m_PostOne.position.z - 10 && m_GuardLocation.position.z <= m_PostOne.position.z + 10)
        {
            m_Location = 2;
        }
        if (m_GuardLocation.position.x >= m_PostTwo.position.x - 10 && m_GuardLocation.position.x <= m_PostTwo.position.x + 10 && m_GuardLocation.position.z >= m_PostTwo.position.z - 10 && m_GuardLocation.position.z <= m_PostTwo.position.z + 10)
        {
            m_Location = 1;
        }
        
        
    }
    */
}
