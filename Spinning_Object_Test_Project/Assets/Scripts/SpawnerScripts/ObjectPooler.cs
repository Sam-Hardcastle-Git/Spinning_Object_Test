using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public delegate void MyDelegate(GameObject myObject);
    public MyDelegate newObjectSpawns;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public Parameters parameters;

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.parent = transform;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFromPool(parameters.shape.ToString(), Random.insideUnitSphere * 50, Quaternion.identity);
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        //Remove from queue
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        //Set active
        objectToSpawn.SetActive(true);

        //Set attributes
        newObjectSpawns.Invoke(objectToSpawn);

        SetObjectRotation rotation = objectToSpawn.GetComponent<SetObjectRotation>();
        rotation.orbitSpeed = Random.Range(parameters.minOrbit, parameters.maxOrbit);
        rotation.localRotateSpeed = Random.Range(parameters.minLocalRotation, parameters.maxLocalRotation);

        //Set position and rotation
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        //Trigger fading
        objectToSpawn.GetComponent<FadeOut>().Despawn(objectToSpawn);

        //Return to queue
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
