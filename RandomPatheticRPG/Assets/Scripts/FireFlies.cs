using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlies : MonoBehaviour {

    public GameObject fireFlyPrefab;
    public int minimumFireFlies = 2;
    public int maximumFireFlies = 4;
    public float minimumHeight = 0.5f;
    public float maximumHeight = 1f;

    GameObject[] fireFlies;
    Vector3[] originalPosition;
    float[] fireFlieOffset;

    float t = 0;

	// Use this for initialization
	void Start () {

        int nOfFireFlies = Random.Range(minimumFireFlies, maximumFireFlies + 1);
        fireFlies = new GameObject[nOfFireFlies];
        originalPosition = new Vector3[nOfFireFlies];
        fireFlieOffset = new float[nOfFireFlies];

        for(int i = 0; i < nOfFireFlies; i++)
        {
            originalPosition[i] = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(minimumHeight, maximumHeight), Random.Range(-0.5f, 0.5f));
            fireFlies[i] = new GameObject("FireFly");
            fireFlies[i].transform.parent = transform;
            fireFlieOffset[i] = Random.Range(0f, Mathf.PI * 2);
            fireFlies[i].transform.position = originalPosition[i] + transform.position + Vector3.up * CalculateYOffset(i);
            Light l = fireFlies[i].AddComponent<Light>();
            l.intensity = 0.2f;
            l.range = 1;
            l.lightmapBakeType = LightmapBakeType.Realtime;
        }

	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;

        for (int i = 0; i < fireFlies.Length; i++)
        {

            fireFlies[i].transform.position = originalPosition[i] + transform.position + Vector3.up * CalculateYOffset(i);

        }
    }

    float CalculateYOffset(int i)
    {
        return Mathf.Sin(fireFlieOffset[i] + t) * minimumHeight * 0.9f;
    }
}
