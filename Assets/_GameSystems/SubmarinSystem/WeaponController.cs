using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
   [SerializeField] private List<BulletConfig> bullets;

    private void Start()
    {
        ChangeWeapon(null);
    }

    public BulletConfig ChangeWeapon(BulletConfig currentBullet)
    {
        if (currentBullet == null) return bullets[0];

        foreach (var item in bullets)
        {
            if (item != currentBullet) return item;
        }

        return null;
    }
}
