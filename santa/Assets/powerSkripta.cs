using UnityEngine;
using System.Collections;

public class powerSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject[] powers;
    GameObject[] powers2;
    float nextPowerUp;
    public static float skalar = 0;
	void Start () {
        powers2 = new GameObject[powers.Length];
        for(int i=0; i < powers2.Length; i++)
        {
            powers2[i] = Instantiate(powers[i]);
        }
        nextPowerUp = Random.Range(5, 20);
	}
	
	// Update is called once per frame
	void Update () {
        nextPowerUp -= skalar * Time.deltaTime;
        if (nextPowerUp < 0)
        {
            sproziPower();
        }
	}

    void sproziPower()
    {
        int i = Random.Range(0, powers2.Length);
        powers2[i].SetActive(true);
        powers2[i].transform.position = transform.position;
        nextPowerUp = Random.Range(5, 20);
    }
}
