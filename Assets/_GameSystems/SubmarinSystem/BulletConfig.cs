using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletScriptable")]
public class BulletConfig : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private GameObject bulletPrefab;

    public string Name { get => name; }
    public float Speed { get => speed; }
    public int Damage { get => damage; }
    public GameObject BulletPrefab { get => bulletPrefab; }
}
