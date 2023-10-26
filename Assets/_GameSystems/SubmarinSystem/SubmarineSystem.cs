using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineSystem : MonoBehaviour
{
    #region SubmarineGameObjects
    public GameObject submarineGO;
    public Submarine submarine;
    #endregion

    #region SubmarineSettingsData
    public float verticalSpeed;
    public float horizontalSpeed;
    public BulletConfig currentWeapon;
    #endregion
}
