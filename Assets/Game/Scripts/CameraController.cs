using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform m_PlayerPosition;
    [SerializeField] private Transform m_CameraPosition;
	

	void Update () {
        m_CameraPosition.position = new Vector3(m_PlayerPosition.position.x, m_PlayerPosition.position.y + 9.190001f, m_PlayerPosition.position.z - 10.85f);	
	}
}
