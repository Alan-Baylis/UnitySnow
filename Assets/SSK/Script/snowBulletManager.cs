using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBulletManager : MonoBehaviour {

    public Rigidbody thisRigidbody;
    public GameObject thisGameObject;
    // Use this for initialization
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisGameObject = thisRigidbody.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //print(thisRigidbody.velocity);
        if (thisGameObject.transform.position.magnitude > 10000)
        {
            Destroy(thisGameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(thisGameObject);

    }
}
