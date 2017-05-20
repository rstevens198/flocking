using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject fishPrefab;

    static int numFish = 10;
    public GameObject[] allFish = new GameObject[numFish];
    public float tankSizeX = 59;
    public float tankSizeY = 27;

	// Use this for initialization
	void Start ()
    {
		for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSizeX, tankSizeX), 0, Random.Range(-tankSizeY, tankSizeY));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
