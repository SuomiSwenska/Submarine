using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoLogic : MonoBehaviour
{
    private UISystem _uISystem;
    private GameplaySystem _gameplaySystem;
    private TorpedoGenerator _torpedoGenerator;
    private SubmarineSystem _submarineSystem;

    private void Awake()
    {
        _gameplaySystem = FindObjectOfType<GameplaySystem>();
        _torpedoGenerator = GetComponent<TorpedoGenerator>();
        _submarineSystem = FindObjectOfType<SubmarineSystem>();
        _uISystem = FindObjectOfType<UISystem>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        _torpedoGenerator.GetNewTorpedo(_gameplaySystem.gameTimer, _submarineSystem.submarineGO.transform);
    }

    private void OnEnable()
    {
        Torpedo._Hit += SubmarineHit;
        Torpedo._Slip += TorpedoSlip;
        Torpedo._TorpedoDestroy += TorpedoDestroy;
    }

    private void OnDisable()
    {
        Torpedo._Hit -= SubmarineHit;
        Torpedo._Slip -= TorpedoSlip;
        Torpedo._TorpedoDestroy -= TorpedoDestroy;
    }

    private void SubmarineHit()
    {
        _uISystem.OnGameOverPanelView?.Invoke();
    }

    private void TorpedoSlip()
    {
        _torpedoGenerator.GetNewTorpedo(_gameplaySystem.gameTimer, _submarineSystem.submarineGO.transform);
    }

    private void TorpedoDestroy()
    {
        _gameplaySystem.torpedoCount++;
        Saver.instance.SaveResult(_gameplaySystem.torpedoCount);
        _gameplaySystem.OnTorpedoDestroy?.Invoke();
        _uISystem.OnChangeResultCounter?.Invoke(_gameplaySystem.torpedoCount);
        _torpedoGenerator.GetNewTorpedo(_gameplaySystem.gameTimer, _submarineSystem.submarineGO.transform);
    }
}
