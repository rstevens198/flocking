using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject fishPrefab;
    public static Vector3 goalPos = Vector3.zero;

    static int numFish = 20;
    public static GameObject[] allFish = new GameObject[numFish];
    public float tankSizeX = 59;
    public float tankSizeZ = 27;

	// Use this for initialization
	void Start ()
    {
		for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSizeX, tankSizeX), 0, Random.Range(-tankSizeZ, tankSizeZ));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].transform.Rotate(90, 0, 0);
        }
	}

    void Update()
    {
        if   (Random.Range(0, 1000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSizeX, tankSizeX),
                                  0,
                                  Random.Range(-tankSizeZ, tankSizeZ));
        }
    }
}
