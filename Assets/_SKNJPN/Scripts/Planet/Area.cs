using System.Collections.Generic;
using UnityEngine;

public struct Area
{
    public Vector3Int position;
    public List<Transform> transforms;
    public List<Creature> creatures;

    public void Set(Vector3Int _position)
    {
        position = _position;
        transforms = new List<Transform>();
        creatures = new List<Creature>();
    }

    public void AddObject(Transform _transform)
    {
        transforms.Add(_transform);

        if (_transform.HasComponent<Creature>()) { creatures.Add(_transform.GetComponent<Creature>()); }
    }

    public void RemoveObject(Transform _transform)
    {
        transforms.Remove(_transform);

        if (_transform.HasComponent<Creature>()) { creatures.Remove(_transform.GetComponent<Creature>()); }
    }
}