using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class zad5 : MonoBehaviour
{

    public GameObject myPref;

    public int count = 10;
    public int min = -10;
    public int max = 10;
    // Nie wiem czemu, ale max musi być >= count, żeby scrypt się nie wykrzaczył

    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<int,int> pkt =Losowanie(min,max,count);
        for (int i = 0; i< count; i++)
        {
            Instantiate(myPref, new Vector3(pkt.Keys.ElementAt(i), 0, pkt.Values.ElementAt(i)),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Dictionary<int,int> Losowanie(int a, int b,int c)
    {
        Dictionary<int,int> pkt = new Dictionary<int, int>();
        List<int> zakres = new List<int>();
        for (int i = a; i < b + 1; i++)
        {
            zakres.Add(i);
        }

        
        

        int[] xValues = new int[c];
        int[] zValues = new int[c];
        for (int i = 0; i < c; i++)
        {
            List<int> xZakres = zakres;
            int x = rnd.Next(a, b);
            if (xZakres.Contains(x))
            {
                xValues[i] = x;
                xZakres.Remove(x);
            }
            else
            {
                i--;
            }
        }
        for (int i = 0; i < c; i++)
        {
            List<int> zZakres = zakres;
            int z = rnd.Next(a, b);
            if (zZakres.Contains(z))
            {
                zValues[i] = z;
                zZakres.Remove(z);
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < xValues.Length; i++)
        {
            pkt.Add(xValues[i],zValues[i]);
        }

        return pkt;
    }
}

