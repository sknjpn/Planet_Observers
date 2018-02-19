using System.Collections.Generic;
using UnityEngine;

public class Area
{
    public Vector3Int position;
    public List<PlanetObject> planetObjects = new List<PlanetObject>();

    public Area(Vector3Int _position)
    {
        position = _position;
    }

    public void AddPlanetObject(PlanetObject _planetObject)
    {
        planetObjects.Add(_planetObject);
    }

    public void RemovePlanetObject(PlanetObject _planetObject)
    {
        planetObjects.Remove(_planetObject);
    }
}