using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineLogic : MonoBehaviour
{
    private SubmarineSystem _submarineSystem;
    private WeaponController _weaponController;
    private UISystem _uISystem;

    private void Awake()
    {
        _submarineSystem = GetComponent<SubmarineSystem>();
        _weaponController = GetComponent<WeaponController>();
        _uISystem = FindObjectOfType<UISystem>();
    }

    private void OnEnable()
    {
        InputController._VerticallMove += VerticalMoveSubmarine;
        InputController._HorizontalMove += HorizontalMoveSubmarine;
        InputController._MouseWheel += SubmarineWeaponSwitcher;
        InputController._MouseButton += SubmarineShot;
    }

    private void OnDisable()
    {
        InputController._VerticallMove -= VerticalMoveSubmarine;
        InputController._HorizontalMove -= HorizontalMoveSubmarine;
        InputController._MouseWheel -= SubmarineWeaponSwitcher;
        InputController._MouseButton -= SubmarineShot;
    }

    private void VerticalMoveSubmarine(InputController.VerticalType type)
    {
        float delta = (type == InputController.VerticalType.Up ? _submarineSystem.verticalSpeed : -_submarineSystem.verticalSpeed);
        _submarineSystem.submarine.Move(new Vector3(0, 0, delta * Time.deltaTime));
    }

    private void HorizontalMoveSubmarine(InputController.HorizontalType type)
    {
        float delta = (type == InputController.HorizontalType.Left ? -_submarineSystem.horizontalSpeed : _submarineSystem.horizontalSpeed);
        _submarineSystem.submarine.Move(new Vector3(delta * Time.deltaTime, 0, 0));
    }

    private void SubmarineWeaponSwitcher(InputController.VerticalType type)
    {
        _submarineSystem.currentWeapon = _weaponController.ChangeWeapon(_submarineSystem.currentWeapon);
        _uISystem.OnChangeWeapon?.Invoke(_submarineSystem.currentWeapon.name);
    }

    private void SubmarineShot()
    {
        _submarineSystem.submarine.Fire(_submarineSystem.currentWeapon, _submarineSystem.currentWeapon.name == "Light" ? Color.green : Color.red);
    }
}
