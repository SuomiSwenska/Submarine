using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    [SerializeField] private Transform barrelPoint;

    public void Move(Vector3 movingDelta)
    {
        transform.position += movingDelta;
    }

    public void Fire(BulletConfig weapon)
    {
        GameObject bulletGO = Instantiate(weapon.BulletPrefab, barrelPoint.position, Quaternion.identity);
        bulletGO.GetComponent<Bullet>().BulletInit(weapon);
    }
}
