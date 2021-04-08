using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject torpedoPrefab;

    public void GetNewTorpedo(float gameTime, Transform target)
    {
        int rndHealth = Random.Range(1, 4);
        int coeff = GetSpeedCoefficient(gameTime);
        Vector3 instantiatePosition = GetRandomPosition();
        GameObject torpedoGO = Instantiate(torpedoPrefab, instantiatePosition, Quaternion.identity);
        torpedoGO.transform.LookAt(target);
        torpedoGO.GetComponent<Torpedo>().TorpedoInit(rndHealth, target, coeff);
    }

    private int GetSpeedCoefficient(float gameTime)
    {
        int coeff = (int)(gameTime / 10);
        if (coeff < 1) coeff = 1;

        return coeff;
    }

    private Vector3 GetRandomPosition()
    {
        float minX = startPoint.position.x;
        float maxX = endPoint.position.x;

        float rndXPos = Random.Range(minX, maxX);

        return new Vector3(rndXPos, 0, startPoint.position.z);
    }
}
