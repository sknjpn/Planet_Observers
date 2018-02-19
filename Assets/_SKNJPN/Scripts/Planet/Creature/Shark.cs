using UnityEngine;
using System.Collections;

public class Shark : Animal
{
    PlanetObject planetObject;
    float angle;

    void Start()
    {
        planetObject = GetComponent<PlanetObject>();
    }

    void FixedUpdate()
    {
        angle += 1f;
        var planet = planetObject.planet;

        transform.rotation = Quaternion.AngleAxis(angle, transform.position.normalized) * Quaternion.FromToRotation(Vector3.up, transform.position.normalized);

        transform.position += 0.1f * transform.forward;

        transform.position = transform.position.normalized * planet.WaterHeight;
    }
}
