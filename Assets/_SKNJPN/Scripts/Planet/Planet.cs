using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float maximumHeight = 24.0f;
    [SerializeField] float waterHeight = 16.0f;
    [SerializeField] float areaSize = 0.5f;
    int frameCount;
    Area[,,] areaGrid;
    List<PlanetObject> planetObjects = new List<PlanetObject>();

    public float MaximumHeight { get { return maximumHeight; } }
    public float WaterHeight { get { return waterHeight; } }
    public float AreaSize { get { return areaSize; } }
    public Area[,,] AreaGrid { get { return areaGrid; } }
    public List<PlanetObject> PlanetObjects { get { return planetObjects; } }

    void Awake()
    {
        var length = Mathf.CeilToInt(2 * maximumHeight / areaSize);

        areaGrid = new Area[length, length, length];

        for (var x = 0; x < length; x++)
        {
            for (var y = 0; y < length; y++)
            {
                for (var z = 0; z < length; z++)
                {
                    areaGrid[x, y, z] = new Area(new Vector3Int(x, y, z));
                }
            }
        }
    }

    void FixedUpdate()
    {
        foreach (var planetObject in planetObjects)
        {
            if(frameCount % planetObject.updateInterval == 0)
            {
                planetObject.ManagedUpdate(); planetObject.age++;
            }
        }

        frameCount++;
    }

    public Area GetArea(Vector3 _position)
    {
        var p = Vector3Int.FloorToInt((_position + Vector3.one * maximumHeight) / areaSize);

        return areaGrid[p.x, p.y, p.z];
    }

    public float GetHeight(Vector3 _position)
    {
        var hits = Physics.RaycastAll(_position.normalized * maximumHeight, -_position.normalized);

        return hits.First(hit => hit.transform == transform).point.magnitude;
    }

    public Vector3 GetNormal(Vector3 _position)
    {
        var hits = Physics.RaycastAll(_position.normalized * maximumHeight, -_position.normalized);

        return hits.First(hit => hit.transform == transform).normal;
    }
}
