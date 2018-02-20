using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Attacher))]
public class PlanetObject : MonoBehaviour
{
    public int age = 0;
    public int updateInterval = 1;
    [HideInInspector] public Area area;
    [HideInInspector] public Planet planet;
    [HideInInspector] public Creature creature;
    [HideInInspector] public Clematis clematis;

    public float Height { get { return transform.position.magnitude; } }

    public virtual void ManagedUpdate() { }

    public void ForEach(float _maxDistance, Action<PlanetObject> _action)
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

    public bool Any(float _maxDistance, Func<PlanetObject, bool> _action)
    {
        var positionMin = planet.GetArea(transform.position - _maxDistance * Vector3.one).position;
        var positionMax = planet.GetArea(transform.position + _maxDistance * Vector3.one).position;

        for (var x = positionMin.x; x <= positionMax.x; x++)
        {
            for (var y = positionMin.y; y <= positionMax.y; y++)
            {
                for (var z = positionMin.z; z <= positionMax.z; z++)
                {
                    if (planet.AreaGrid[x, y, z].planetObjects.Any(_action)) { return true; }
                }
            }
        }

        return false;
    }

    public static float Distance(PlanetObject _a, PlanetObject _b)
    {
        return Vector3.Distance(_a.transform.position, _b.transform.position);
    }
}
