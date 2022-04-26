using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Nematode : MonoBehaviour
{
    public int length = 5;

    public float minWidth, maxWidth;
    
    public Material material;

    void Awake() { 
        // Put your code here!
        Transform prevTrasform = null;
        for (int i = 0; i < length; i++) {
            GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newSphere.transform.rotation = transform.rotation;
            newSphere.transform.parent = transform;
            
            float scaleVal = i < length / 2 ? Mathf.Lerp(minWidth, maxWidth, (float)i / (length / 2)) : Mathf.Lerp(maxWidth, minWidth, (float)(i - length/2) / (length / 2));
            newSphere.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);

            float gap = 0;
            if (prevTrasform != null) {
                gap = (prevTrasform.position.z) - ((prevTrasform.localScale.z / 2) + (scaleVal / 2));
            } else {
                gap = transform.position.z - scaleVal / 2;
            }
            newSphere.transform.position += new Vector3(transform.position.x, transform.position.y,  gap);
            prevTrasform = newSphere.transform;
            
            Material sphereMat = new Material(Shader.Find("Specular"));
            sphereMat.color = Color.HSVToRGB(Random.Range(0f,1f), 1f, 1f);
            newSphere.GetComponent<Renderer>().material = sphereMat;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
