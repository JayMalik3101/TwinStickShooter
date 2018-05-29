using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StatManager : MonoBehaviour {
    public PlayerData m_Data;
    private Text m_TotalTimePlayedText;
    private Text m_TotalCashEarnedText;
    private Text m_TimesPlayedText;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        LoadStats();
        m_TotalCashEarnedText = GameObject.Find("MoneyEarnedText").GetComponent<Text>();
        m_TotalTimePlayedText = GameObject.Find("TimePlayedText").GetComponent<Text>();
        m_TimesPlayedText = GameObject.Find("TimesPlayedText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        TimeStuff();
        Display();
        // save stats at set moments
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
    public void Display()
    {
        if (m_TotalTimePlayedText != null)
        {
            m_TotalTimePlayedText.text = m_Data.m_HoursPlayed + " Hours, " + m_Data.m_MinutesPlayed + " Minutes, " + Mathf.Round(m_Data.m_SecondsPlayed) + " Seconds.";
        }
        if (m_TimesPlayedText != null)
        {
            m_TimesPlayedText.text = "You have played " + m_Data.m_TimesPlayed + " times.";
        }
        if (m_TotalCashEarnedText != null)
        {
            m_TotalCashEarnedText.text = "You have earned " + m_Data.m_TotalCashEarned + "$.";
        }
    }

    public void PlayingNow()
    {
        m_Data.m_TimesPlayed += 1;
    }

    public void LoadStats()
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

    public void SaveStats()
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
}