using System;
using UnityEngine;

public sealed class PlanetObject : MonoBehaviour
{
    [HideInInspector] public Planet planet;
    [HideInInspector] public Area area;
    [HideInInspector] public Creature creature;
    [HideInInspector] public Plant plant;
    [HideInInspector] public Animal animal;
    [HideInInspector] public Clematis clematis;

    void Awake()
    {
        planet = GetComponentInParent<Planet>();
        creature = GetComponent<Creature>();
        plant = GetComponent<Plant>();
        animal = GetComponent<Animal>();
        clematis = GetComponent<Clematis>();
    }

    void Start()
    {
        planet.PlanetObjects.Add(this);

        area = planet.GetArea(transform.position);

        if (area != null) { area.AddPlanetObject(this); }
    }

    void OnDestroy()
    {
        planet.PlanetObjects.Remove(this);

        if (area != null) { area.RemovePlanetObject(this); }
    }

    public void ForEachToNear(float _maxDistance, Action<PlanetObject> _action)
    {
        var positionMin = planet.GetArea(transform.position - _maxDistance * Vector3.one).position;
        var positionMax = planet.GetArea(transform.position + _maxDistance * Vector3.one).position;

        for (var x = positionMin.x; x <= positionMax.x; x++)
        {
            for (var y = positionMin.y; y <= positionMax.y; y++)
            {
                for (var z = positionMin.z; z <= positionMax.z; z++)
                {
                    planet.AreaGrid[x, y, z].planetObjects.ForEach(_action);
                }
            }
        }
    }

    public static float Distance(PlanetObject _a, PlanetObject _b)
    {
        return Vector3.Distance(_a.transform.position, _b.transform.position);
    }
}
