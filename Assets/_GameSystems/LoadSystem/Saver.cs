using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver instance;

    private void Awake()
    {
        instance = this;
    }

    public void SaveResult(int result)
    {
        int bestResult = PlayerPrefs.GetInt("BestResult");
        if (result > bestResult) PlayerPrefs.SetInt("BestResult", result);
    }

    public int GetBestResult()
    {
        return PlayerPrefs.GetInt("BestResult");
    }
}
