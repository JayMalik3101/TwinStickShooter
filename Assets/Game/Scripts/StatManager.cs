using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StatManager : MonoBehaviour {
    public static PlayerData m_Data;
    void Start () {
        DontDestroyOnLoad(this.gameObject);
 
        LoadStats();
        if (m_Data.m_DamageModifier <= 1) m_Data.m_DamageModifier = 1;
        if (m_Data.m_SpeedModifier <= 1) m_Data.m_SpeedModifier = 1;
        if (m_Data.m_ReloadModifier >= 1) m_Data.m_ReloadModifier = 1;
    }
	
	// Update is called once per frame
	void Update () {
        TimeStuff();
    }

    private void TimeStuff()
    {
        m_Data.m_SecondsPlayed += Time.deltaTime;

        if (m_Data.m_SecondsPlayed >= 60)
        {
            m_Data.m_MinutesPlayed += 1;
            m_Data.m_SecondsPlayed = 0;
        }
        if (m_Data.m_MinutesPlayed >= 60)
        {
            m_Data.m_HoursPlayed += 1;
            m_Data.m_MinutesPlayed = 0;
        }
    }

    private void LoadStats()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            m_Data = data;
            file.Close();
        }
    }

    public static void SaveStats()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"/*, FileMode.Open*/);

        PlayerData data = new PlayerData();
        data = m_Data;
        bf.Serialize(file, data);
        file.Close();
    }
}
[Serializable]
public class PlayerData
{
    public float m_TotalCashEarned;
    public float m_TimesPlayed;
    public float m_HoursPlayed;
    public float m_MinutesPlayed;
    public float m_SecondsPlayed;
    public float m_MaxHealthModifier;
    public float m_DamageModifier;
    public float m_ReloadModifier;
    public float m_SpeedModifier;
    public float m_HealthLevel;
    public float m_DamageLevel;
    public float m_ReloadLevel;
    public float m_SpeedLevel;
    public float m_CurrentMoney;
}