using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private float alpha = 1, duration;
    public Renderer renderer;
    public Parameters myParameter;

    // Update is called once per frame
    void Update()
    {
        if (renderer.material.color != null)
        {
            Color colour = renderer.material.color;
            renderer.material.color = new Color(colour.r, colour.g, colour.b, alpha);
        }
    }

    public void Despawn(GameObject spawnedObject)
    {
        float duration = Random.Range(myParameter.minLifeTime, myParameter.maxLifeTime);

        StartCoroutine(Fade(duration, spawnedObject));
    }

    private IEnumerator Fade(float duration, GameObject spawnedObject)
    {
        yield return new WaitForSeconds(1);

        //Set up time parameters
        float startTime = Time.time;
        float endTime = startTime + duration;

        yield return null;

        //Reduce the alpha over time
        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / duration;
            alpha = Mathf.Lerp(1f, 0f, progress);
            yield return null;
        }

        //Reset object
        spawnedObject.SetActive(false);
        alpha = 1;

        //Replace object
        transform.parent.GetComponent<ObjectPooler>().SpawnFromPool(myParameter.shape.ToString(), 
            Random.insideUnitSphere * 50, Quaternion.identity);
    }
}
