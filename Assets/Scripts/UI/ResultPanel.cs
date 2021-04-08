using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Text torpedoCounterText;
    [SerializeField] private Text bestResultText;
    [SerializeField] private Text currentWeaponText;

    private void Start()
    {
        UpdateTorpedoCounter(0);
    }

    public void UpdateTorpedoCounter(int count)
    {
        string result = "Result: " + count.ToString();
        string bestResult = "Best result: " + Saver.instance.GetBestResult().ToString();
        torpedoCounterText.text = result;
        bestResultText.text = bestResult;
    }

    public void ChangeWeapon(string name)
    {
        string weaponText = "Type: " + name;
        currentWeaponText.text = weaponText;
    }
}
