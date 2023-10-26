using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletConfig weapon;
    private Rigidbody rigidbody;
    private bool isHit;

    public void BulletInit(BulletConfig weapon)
    {
        this.weapon = weapon;
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveForward());
        Destroy(gameObject, 3f);
    }

    private IEnumerator MoveForward()
    {
        while (!isHit)
        {
            rigidbody.AddForce(transform.forward * weapon.Speed * 12, ForceMode.Acceleration);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isHit = true;
        Torpedo torpedo = other.transform.GetComponent<Torpedo>();
        if (torpedo != null) torpedo.GetDamage(weapon.Damage);
        Destroy(gameObject);
    }
}
