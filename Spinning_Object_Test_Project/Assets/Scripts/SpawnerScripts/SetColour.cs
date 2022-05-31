using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColour : MonoBehaviour
{
    private float minColour, maxColour;
    public Parameters myParameters;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ObjectPooler>().newObjectSpawns += ColourIn;
    }

    void ColourIn(GameObject spawnedObject)
    {
        minColour = myParameters.minColour;
        maxColour = myParameters.maxColour;

        Renderer renderer = spawnedObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", GetRandomColor());
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(minColour, maxColour),
            Random.Range(minColour, maxColour),
            Random.Range(minColour, maxColour));
    }
}
