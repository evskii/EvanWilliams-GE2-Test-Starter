using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;

    // Start is called before the first frame update
    void Awake()
    {
        // Put your code here
        for (int i = 0; i < count; i++) {
            Vector3 randomPosInSphere = Random.insideUnitSphere * radius;
            
            Instantiate(prefab, randomPosInSphere, Random.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
