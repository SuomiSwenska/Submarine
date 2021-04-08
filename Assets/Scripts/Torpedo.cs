using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    #region Data
    private int health;
    private readonly float baseSpeed = 0.2f;
    private readonly float baseRotation = 0.02f;
    private float speedCoeff;
    private bool isExplosion;
    #endregion

    #region Components
    private Transform target;
    private Rigidbody rigidbody;
    #endregion

    #region Events
    public delegate void Hit();
    public static Hit _Hit;

    public delegate void Slip();
    public static Slip _Slip;

    public delegate void TorpedoDestroy();
    public static TorpedoDestroy _TorpedoDestroy;
    #endregion

    public void TorpedoInit(int health, Transform target, float speedCoeff)
    {
        this.health = health;
        this.target = target;
        this.speedCoeff = speedCoeff;
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while(!isExplosion)
        {
            rigidbody.AddForce(transform.forward * baseSpeed * speedCoeff, ForceMode.Acceleration);
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion rotTotarget = Quaternion.LookRotation(direction, Vector3.up);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, rotTotarget, baseRotation * speedCoeff);
            rigidbody.MoveRotation(newRotation);
            if (IsASlip()) StartCoroutine(SelfDestruction(2));
            yield return null;
        }
    }

    private bool IsASlip()
    {
        return transform.position.z <= target.position.z - 1f;
    }

    private IEnumerator SelfDestruction(float delay)
    {
        isExplosion = true;

        while (delay > 0)
        {
            rigidbody.AddForce(transform.forward * baseSpeed, ForceMode.Acceleration);
            delay -= Time.deltaTime;
            yield return null;
        }

        _Slip?.Invoke();

        BigBang();
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionHolder(collision);
    }

    private void CollisionHolder(Collision collision)
    {
        isExplosion = true;
        Submarine submarine = collision.transform.GetComponent<Submarine>();
        if (submarine != null) { _Hit?.Invoke(); }
        BigBang();
    }

    private void BigBang()
    {
        Destroy(gameObject, 0.1f);
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0) { _TorpedoDestroy?.Invoke(); BigBang(); }
    }
}
