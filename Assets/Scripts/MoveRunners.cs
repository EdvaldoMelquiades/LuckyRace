using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MoveRunners : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;

    private float distanceTravelled;

    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
