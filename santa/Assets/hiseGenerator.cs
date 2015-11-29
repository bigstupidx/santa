using UnityEngine;
using System.Collections;

public class hiseGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] Hise;
    GameObject[] seznamHis;
    int stevec = 0;
    Vector3 zacetnaPos;
    float speed = 0;
    public static float speedP = 1; 
	void Start () {
        seznamHis = new GameObject[100];
        
        for (int i=0; i < seznamHis.Length; i++)
        {
            seznamHis[i] = Instantiate(Hise[Random.Range(0, Hise.Length)]);
            seznamHis[i].transform.SetParent(transform);
            
        }
        zacetnaPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * speedP* Time.deltaTime;
        speedP = 1;
	}

    public void dodajHiso(Transform t)
    {
        
        GameObject zac = seznamHis[stevec % seznamHis.Length];
        Vector3 pos = t.transform.position;
        pos.x += t.transform.localScale.x + zac.transform.localScale.x;
        zac.transform.position = pos;
        zac.SetActive(true);


        stevec++;

    }

    public void dodajPrvoHiso()
    {
        GameObject zac = seznamHis[stevec % seznamHis.Length];
        zac.SetActive(true);
        zac.transform.position = zacetnaPos;
        stevec++;
        speed = 3;
    }
}
