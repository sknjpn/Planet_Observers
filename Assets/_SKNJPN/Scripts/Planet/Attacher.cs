using System;
using UnityEngine;

[RequireComponent(typeof(PlanetObject))]
public sealed class Attacher : MonoBehaviour
{
    PlanetObject planetObject;

    void Awake()
    {
        planetObject = GetComponent<PlanetObject>();

        planetObject.planet =GameObject.Find("Planet").GetComponent<Planet>();

        planetObject.creature = GetComponent<Creature>();
        planetObject.clematis = GetComponent<Clematis>();
    }

    void Start()
    {
        planetObject.planet.PlanetObjects.Add(planetObject);

        planetObject.area = planetObject.planet.GetArea(transform.position);

        if (planetObject.area != null)
        {
            planetObject.area.AddPlanetObject(planetObject); 
}
    }

    void OnDestroy()
    {
        planetObject.planet.PlanetObjects.Remove(planetObject);

        if (planetObject.area != null) { planetObject.area.RemovePlanetObject(planetObject); }
    }

    public void ForEachToNear(float _maxDistance, Action<PlanetObject> _action)
    {
        var positionMin = planetObject.planet.GetArea(transform.position - _maxDistance * Vector3.one).position;
        var positionMax = planetObject.planet.GetArea(transform.position + _maxDistance * Vector3.one).position;

        for (var x = positionMin.x; x <= positionMax.x; x++)
        {
            for (var y = positionMin.y; y <= positionMax.y; y++)
            {
                for (var z = positionMin.z; z <= positionMax.z; z++)
                {
                    planetObject.planet.AreaGrid[x, y, z].planetObjects.ForEach(_action);
                }
            }
        }
    }
}
