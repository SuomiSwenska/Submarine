using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TorpedoesPool : MonoBehaviour
{
    private TorpedoSystem _torpedoSystem;
    private List<GameObject> _torpedoes;

    private void Awake()
    {
        _torpedoes = new List<GameObject>();
        _torpedoSystem = GetComponent<TorpedoSystem>();
    }

    private void Start()
    {
        for (int i = 0; i <= _torpedoSystem.preGeneratorTorpedoesCount; i++)
        {
            CreateTorpedoGO();
        }
    }

    private void CreateTorpedoGO()
    {
        GameObject newTorpedoGO = Instantiate(_torpedoSystem.torpedoPrefab);
        _torpedoes.Add(newTorpedoGO);
        newTorpedoGO.SetActive(false);
    }

    public GameObject GetAciveTorpedoGO()
    {
        GameObject foundObject = _torpedoes.FirstOrDefault(go => !go.activeSelf);
        foundObject.SetActive(true);
        return foundObject;
    }
}
