using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public int QualitySettingss;

    public void Start()
    {
        if(PlayerPrefs.HasKey("QualitySettingsSave"))
        {
            QualitySettingss = PlayerPrefs.GetInt("QualitySettingsSave");
        }
        else
        {
            PlayerPrefs.SetInt("QualitySettingsSave", 2);
        }
    }

    public void Update()
    {
        QualitySettingss = PlayerPrefs.GetInt("QualitySettingsSave");

        if (QualitySettingss == 0)
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        if(QualitySettingss == 1)
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        if(QualitySettingss == 2)
        {
            QualitySettings.SetQualityLevel(2, true);
        }
    }

    public void BTNHigh()
    {
        PlayerPrefs.SetInt("QualitySettingsSave", 2);
    }

    public void BTNMedium()
    {
        PlayerPrefs.SetInt("QualitySettingsSave", 1);
    }

    public void BTNLow()
    {
        PlayerPrefs.SetInt("QualitySettingsSave", 0);
    }
}
