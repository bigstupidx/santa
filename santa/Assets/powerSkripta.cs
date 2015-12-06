using UnityEngine;
using System.Collections;

public class powerSkripta : MonoBehaviour {

    // Use this for initialization
    public GameObject[] powers;
    GameObject[] powers2;
    public float nextPowerUp;
    public static float skalar = 0;
    int enable = 1;
    RectTransform rectCanvas;
	void Start () {
        GameObject canvas = GameObject.Find("Canvas");
        rectCanvas = canvas.GetComponent<RectTransform>();
        powers2 = new GameObject[powers.Length];
        for(int i=0; i < powers2.Length; i++)
        {
            powers2[i] = Instantiate(powers[i]);
            powers2[i].transform.SetParent(canvas.transform, false);
            powers2[i].GetComponent<subPower>().power = GetComponent<powerSkripta>();
        }
        nextPowerUp = Random.Range(1, 5);
	}
	
	// Update is called once per frame
	void Update () {
        nextPowerUp -= skalar * Time.deltaTime*enable;
        if (nextPowerUp < 0)
        {
            sproziPower();
            enable = 0;
        }
	}

    void sproziPower()
    {
        int i = Random.Range(0, powers2.Length);
        
        Vector3 pos = powers2[i].GetComponent<RectTransform>().localPosition;
        pos = Vector3.zero;
        pos.y = GetComponent<RectTransform>().localPosition.y;
        pos.x = rectCanvas.sizeDelta.x / 2 + powers2[i].GetComponent<RectTransform>().sizeDelta.x / 2;
        powers2[i].GetComponent<RectTransform>().localPosition = pos;
        powers2[i].SetActive(true);
        nextPowerUp = Random.Range(1, 5);
    }

    public void nastaviSkalar()
    {
        enable = 1;
    }
}
