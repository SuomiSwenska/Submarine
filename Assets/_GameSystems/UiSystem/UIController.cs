using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanelGO;
    [SerializeField] private GameObject resultPanelGO;

    private ResultPanel resultPanel;

    private void Awake()
    {
        resultPanel = resultPanelGO.GetComponent<ResultPanel>();
    }

    public void ChangeWeapon(string name)
    {
        resultPanel.ChangeWeapon(name);
    }

    public void ChangeResultCounter(int count)
    {
        resultPanel.UpdateTorpedoCounter(count);
    }

    public void GameOverPanelView()
    {
        resultPanelGO.SetActive(false);
        gameOverPanelGO.SetActive(true);
    }

    public void ResultPanelView()
    {
        resultPanelGO.SetActive(true);
    }
}
