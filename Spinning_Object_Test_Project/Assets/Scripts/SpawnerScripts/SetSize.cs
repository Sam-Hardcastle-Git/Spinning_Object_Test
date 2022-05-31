using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSize : MonoBehaviour
{
    private float minSize, maxSize;
    public Parameters myParameters;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ObjectPooler>().newObjectSpawns += Size;
    }

    private void Size(GameObject spawnedObject)
    {
        minSize = myParameters.minSizeParameter;
        maxSize = myParameters.maxSizeParameter;

        float size = Random.Range(minSize, maxSize);
        spawnedObject.transform.localScale = new Vector3(size, size, size);
    }
}
