using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public Action<string> OnChangeWeapon;
    public Action<int> OnChangeResultCounter;
    public Action OnGameOverPanelView;
    public Action OnResultPanelView;

    public UIController uIController;
}
