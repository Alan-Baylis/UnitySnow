using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowTerrainManager : MonoBehaviour {
    Transform thisTransform;
    public float limitSnowQuantity;
    float respawnTime;
    float snowResourceQuantity;

    public float snowQuantity
    {
        get
        {
            return snowResourceQuantity;
        }
    }
    
    public Color C;
    // Use this for initialization
    void Start () {
        limitSnowQuantity = 100.0f;
        respawnTime = 20.0f;
        snowResourceQuantity = limitSnowQuantity;
        /*
        foreach (Material m in GetComponent<Renderer>().materials)
        {
            
            print(m.name + m.shader.name + m.color);
            if (m.shader.name.Contains("Transparent"))
            {
                C = m.color;
            }
            //C = r.material.color;
        }
        */
        //GetComponent<Renderer>().material.color.a;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Time.deltaTime/ respawnTime;
        Vector3 V= GetComponent<Transform>().localScale;
        //Vector3 nV= new Vector3(1, 1, 1)*x;
        Vector3 V1 = new Vector3(1.0f, 1.0f, 1.0f);
        //Vector3 V05 = new Vector3(0.5f, 0.5f, 0.5f);
        Color C = GetComponent<Renderer>().material.color;
        if (snowResourceQuantity < limitSnowQuantity)
        {
            snowResourceQuantity += limitSnowQuantity * x;
            float percent = snowResourceQuantity / limitSnowQuantity;
            if (percent > 0.5f)
            {
                V = V1 * percent;
                C.a = percent;
            }else
            {
                V = V1 * 0.5f;
                C.a = percent;
            }
            print(snowResourceQuantity.ToString() + percent);

        }
        GetComponent<Transform>().localScale = V;
        GetComponent<Renderer>().material.color = C;
        //print(C.a);
        
    }
    public void useSnow(float useQuantity)
    {
        snowResourceQuantity -= useQuantity;
    }
}
