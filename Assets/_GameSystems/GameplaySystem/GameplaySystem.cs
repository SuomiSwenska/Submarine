using System;
using UnityEngine;

public class GameplaySystem : MonoBehaviour
{
    #region OnActions
    public Action OnTorpedoDestroy;
    #endregion

    #region GameData
    public int torpedoCount;
    public float gameTimer;
    #endregion
}
