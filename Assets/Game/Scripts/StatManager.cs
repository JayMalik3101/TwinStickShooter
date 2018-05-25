using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour {
    public float m_TotalCashEarned;
    public float m_TimesPlayed;
    private float m_HoursPlayed;
    private float m_MinutesPlayed;
    private float m_SecondsPlayed;
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
        LoadStats();
        TimeStuff();
        Display();
        SaveStats();
        Debug.Log(Application.persistentDataPath);
    }

    private void TimeStuff()
    {
        m_SecondsPlayed += Time.deltaTime;

        if (m_SecondsPlayed >= 60)
        {
            m_MinutesPlayed += 1;
            m_SecondsPlayed = 0;
        }
        if (m_MinutesPlayed >= 60)
        {
            m_HoursPlayed += 1;
            m_MinutesPlayed = 0;
        }
    }
    public void Display()
    {
        if (m_TotalTimePlayedText != null)
        {
            m_TotalTimePlayedText.text = m_HoursPlayed + " Hours, " + m_MinutesPlayed + " Minutes, " + Mathf.Round(m_SecondsPlayed) + " Seconds.";
        }
    }

    public void LoadStats()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            m_HoursPlayed = data.m_HoursPlayed;
            m_MinutesPlayed = data.m_MinutesPlayed;
            m_SecondsPlayed = data.m_SecondsPlayed;
            m_TotalCashEarned = data.m_TotalCashEarned;
            m_TimesPlayed = data.m_TimesPlayed;
            file.Close();
        }
    }

    public void SaveStats()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat"/*, FileMode.Open*/);

        PlayerData data = new PlayerData();
        data.m_HoursPlayed = m_HoursPlayed;
        data.m_MinutesPlayed = m_MinutesPlayed;
        data.m_SecondsPlayed = m_SecondsPlayed;
        data.m_TotalCashEarned = m_TotalCashEarned;
        data.m_TimesPlayed = m_TimesPlayed;
        bf.Serialize(file, data);
        file.Close();
    }
}
[Serializable]
class PlayerData
{
    public float m_TotalCashEarned;
    public float m_TimesPlayed;
    public float m_HoursPlayed;
    public float m_MinutesPlayed;
    public float m_SecondsPlayed;
}
