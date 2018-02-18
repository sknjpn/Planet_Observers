using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    bool onGround;

    public bool OnGround { get { return onGround; } }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Planet>() != null) { onGround = true; }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Planet>() != null) { onGround = false; }
    }
}
