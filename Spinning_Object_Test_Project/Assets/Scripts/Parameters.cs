using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterSet", menuName = "ScriptableObjects/ParameterSets", order = 1)]
public class Parameters : ScriptableObject
{
    public float minOrbit, maxOrbit;
    public float minLocalRotation, maxLocalRotation;
    public float minLifeTime, maxLifeTime;
    public float minSizeParameter, maxSizeParameter;
    public float minColour, maxColour;
    public enum ShapeToSpawn { Cube, Sphere, Cylinder, Quad }
    public ShapeToSpawn shape; 
}
