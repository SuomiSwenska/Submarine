using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    private UISystem _uISystem;

    private void Awake()
    {
        _uISystem = GetComponent<UISystem>();
    }

    private void OnEnable()
    {
        _uISystem.OnChangeResultCounter += ChangeResultCounterHandler;
        _uISystem.OnChangeWeapon += ChangeWeaponHandler;
        _uISystem.OnGameOverPanelView += GameOverPanelViewHandler;
        _uISystem.OnResultPanelView += ResultPanelViewHandler;
    }

    private void OnDisable()
    {
        _uISystem.OnChangeResultCounter -= ChangeResultCounterHandler;
        _uISystem.OnChangeWeapon -= ChangeWeaponHandler;
        _uISystem.OnGameOverPanelView -= GameOverPanelViewHandler;
        _uISystem.OnResultPanelView -= ResultPanelViewHandler;
    }

    private void ChangeResultCounterHandler(int count)
    {
        _uISystem.uIController.ChangeResultCounter(count);
    }

    private void ChangeWeaponHandler(string weaponName)
    {
        _uISystem.uIController.ChangeWeapon(weaponName);
    }

    private void GameOverPanelViewHandler()
    {
        _uISystem.uIController.GameOverPanelView();
    }

    private void ResultPanelViewHandler()
    {
        _uISystem.uIController.ResultPanelView();
    }
}
