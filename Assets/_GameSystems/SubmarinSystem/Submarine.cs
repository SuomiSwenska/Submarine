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

    public void Fire(BulletConfig weapon, Color color)
    {
        GameObject bulletGO = Instantiate(weapon.BulletPrefab, barrelPoint.position, Quaternion.identity);
        MeshRenderer bulletMeshRenderer = bulletGO.GetComponent<MeshRenderer>();
        Material newMaterial = bulletMeshRenderer.sharedMaterial;
        newMaterial.color = color;
        bulletMeshRenderer.sharedMaterial = newMaterial;
        bulletGO.GetComponent<Bullet>().BulletInit(weapon);
    }
}
