using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLogic : MonoBehaviour
{
    private GameplaySystem _gameplaySystem;

    private void Awake()
    {
        _gameplaySystem = GetComponent<GameplaySystem>();
    }

    private void FixedUpdate()
    {
        _gameplaySystem.gameTimer += Time.deltaTime;
    }

    public void RestartButtonClicked()
    {
        Application.LoadLevel(0);
    }
}
