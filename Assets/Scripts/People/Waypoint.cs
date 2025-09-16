using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public enum Destination { Path, Shop, Table, End }

    public Destination destination;
}
