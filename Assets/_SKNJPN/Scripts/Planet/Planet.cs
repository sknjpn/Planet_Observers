using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float waterHeight = 8.0f;
    [SerializeField] float size = 12.0f;
    List<Creature>[,,] creatures;

    public int ArrayLength { get { return 2 * Mathf.CeilToInt(size); } }
    public float WaterHeight { get { return waterHeight; } }
    public List<Creature>[,,] Creatures { get { return creatures; } }

    void Awake()
    {
        creatures = new List<Creature>[ArrayLength, ArrayLength, ArrayLength];

        for (var x = 0; x < ArrayLength; x++)
        {
            for (var y = 0; y < ArrayLength; y++)
            {
                for (var z = 0; z < ArrayLength; z++)
                {
                    creatures[x, y, z] = new List<Creature>();
                }
            }
        }
    }

    public float GetHeight(Vector3 _position)
    {
        var hits = Physics.RaycastAll(_position.normalized * size, -_position.normalized);

        return hits.First(hit => hit.transform == transform).point.magnitude;
    }

    public Vector3 GetNormal(Vector3 _position)
    {
        var hits = Physics.RaycastAll(_position.normalized * size, -_position.normalized);

        return hits.First(hit => hit.transform == transform).normal;
    }

    public void AddCreature(Creature _creature)
    {
        var p = Vector3Int.FloorToInt(_creature.transform.position) + Vector3Int.one * (ArrayLength / 2);

        creatures[p.x, p.y, p.z].Add(_creature);
    }

    public void RemoveCreature(Creature _creature)
    {
        var p = Vector3Int.FloorToInt(_creature.transform.position) + Vector3Int.one * (ArrayLength / 2);

        creatures[p.x, p.y, p.z].Remove(_creature);
    }
}
