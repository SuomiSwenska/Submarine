using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region GameObjects
    [SerializeField] private GameObject submarineGO;
    #endregion

    #region SubmarineSettingsData
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;
    #endregion

    #region GameData
    private int torpedoCount;
    private float gameTimer;
    [SerializeField] private BulletConfig currentWeapon;
    #endregion

    #region Components
    [SerializeField] private UIController uIController;
    private Submarine submarine;
    private TorpedoGenerator torpedoGenerator;
    private WeaponController weaponController;
    #endregion

    private void Awake()
    {
        InputController._VerticallMove += VerticalMoveSubmarine;
        InputController._HorizontalMove += HorizontalMoveSubmarine;
        InputController._MouseWheel += SubmarineWeaponSwitcher;
        InputController._MouseButton += SubmarineShot;

        Torpedo._Hit += SubmarineHit;
        Torpedo._Slip += TorpedoSlip;
        Torpedo._TorpedoDestroy += TorpedoDestroy;

        submarine = submarineGO.GetComponent<Submarine>();
        torpedoGenerator = GetComponent<TorpedoGenerator>();
        weaponController = GetComponent<WeaponController>();
    }

    private void Start()
    {
        torpedoGenerator.GetNewTorpedo(gameTimer, submarineGO.transform);
        currentWeapon = weaponController.ChangeWeapon(null);
        uIController.ChangeWeapon(currentWeapon.name);
    }

    private void FixedUpdate()
    {
        gameTimer += Time.deltaTime;
    }

    private void OnDestroy()
    {
        InputController._VerticallMove -= VerticalMoveSubmarine;
        InputController._HorizontalMove -= HorizontalMoveSubmarine;
        InputController._MouseWheel -= SubmarineWeaponSwitcher;
        InputController._MouseButton -= SubmarineShot;
        Torpedo._Hit -= SubmarineHit;
        Torpedo._Slip -= TorpedoSlip;
        Torpedo._TorpedoDestroy -= TorpedoDestroy;
    }

    public void RestartButtonClicked()
    {
        Application.LoadLevel(0);
    }

    private void VerticalMoveSubmarine(InputController.VerticalType type)
    {
        float delta = (type == InputController.VerticalType.Up ? verticalSpeed : -verticalSpeed);
        submarine.Move(new Vector3(0, 0, delta * Time.deltaTime));
    }

    private void HorizontalMoveSubmarine(InputController.HorizontalType type)
    {
        float delta = (type == InputController.HorizontalType.Left ? -horizontalSpeed : horizontalSpeed);
        submarine.Move(new Vector3(delta * Time.deltaTime, 0, 0));
    }

    private void SubmarineWeaponSwitcher(InputController.VerticalType type)
    {
        currentWeapon = weaponController.ChangeWeapon(currentWeapon);
        uIController.ChangeWeapon(currentWeapon.name);
    }

    private void SubmarineShot()
    {
        submarine.GetComponent<Submarine>().Fire(currentWeapon);
    }

    private void SubmarineHit()
    {
        GameOver();
    }

    private void GameOver()
    {
        uIController.GameOverPanelView();
    }

    private void TorpedoSlip()
    {
        torpedoGenerator.GetNewTorpedo(gameTimer, submarineGO.transform);
    }

    private void TorpedoDestroy()
    {
        torpedoCount++;
        Saver.instance.SaveResult(torpedoCount);
        uIController.ChangeResultCounter(torpedoCount);
        torpedoGenerator.GetNewTorpedo(gameTimer, submarineGO.transform);
    }
}
