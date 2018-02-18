using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float waterHeight = 16.0f;
    [SerializeField] float maximumHeight = 24.0f;
    [SerializeField] float areaSize = 0.5f;
    Area[,,] areas;

    public float WaterHeight { get { return waterHeight; } }
    public Area[,,] Areas { get { return areas; } }

    void Awake()
    {
        var length = Mathf.CeilToInt(2 * maximumHeight / areaSize);

        areas = new Area[length, length, length];

        for (var x = 0; x < length; x++)
        {
            for (var y = 0; y < length; y++)
            {
                for (var z = 0; z < length; z++)
                {
                    areas[x, y, z].Set(new Vector3Int(x, y, z));
                }
            }
        }
    }

    public Area GetArea(Vector3 _position)
    {
        var p = Vector3Int.FloorToInt((_position + Vector3.one * maximumHeight) / areaSize);

        return areas[p.x, p.y, p.z];
    }

    public void AddObject(Transform _transform)
    {
        GetArea(_transform.position).AddObject(_transform);
    }

    public void RemoveObject(Transform _transform)
    {
        GetArea(_transform.position).RemoveObject(_transform);
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
