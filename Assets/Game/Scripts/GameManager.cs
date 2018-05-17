using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private GameObject m_DeathMenu;
    private GameObject m_PauseMenu;
    private PlayerStats m_PlayerStats;

    private bool m_CurrentlyPauzed;
	void Start () {
        m_DeathMenu = GameObject.Find("DeathMenu");
        m_PauseMenu = GameObject.Find("PauseMenu");
        m_PlayerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        m_PauseMenu.SetActive(false);
        m_DeathMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape) && m_PlayerStats.m_CurrentHealth >0)
        {
            if(m_CurrentlyPauzed == false)
            {
                m_PauseMenu.SetActive(true);
                m_CurrentlyPauzed = true;
            }
            else if(m_CurrentlyPauzed == true)
            {
                m_PauseMenu.SetActive(false);
                m_CurrentlyPauzed = false;
            }
        }

        if(m_PlayerStats.m_CurrentHealth <= 0)
        {
            m_DeathMenu.SetActive(true);
        }
	}
}
