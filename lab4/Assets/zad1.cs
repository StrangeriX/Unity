using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public List<Material> materials = new List<Material>();
    public float delay = 1.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    private Random rnd = new Random();

    public int count = 15;

    void Start()
    {

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(count));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, 20).OrderBy(x => Guid.NewGuid()).Take(count));
        
        
        for(int i=0; i<count; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
            
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            int m = rnd.Next(0, materials.Count);
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            this.block.GetComponent<Renderer>().material = materials[m];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}