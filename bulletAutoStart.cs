using UnityEngine;
using System.Collections;

public class bulletAutoStart : MonoBehaviour {
    const float FORCEVELO= 2.0f;
    public float speed = 20.0f;
    public float mass = 1.0f;
    public float bulletUpAngle = 5f;
    public Rigidbody thisRigidbody;
    public GameObject thisGameObject;
    public GameObject theBody;
    // Use this for initialization
	void Start () {
        thisRigidbody = GetComponent<Rigidbody>();
        thisGameObject = thisRigidbody.gameObject;
        Vector3 bulletForward = theBody.transform.forward;
        bulletForward= Quaternion.Euler(theBody.transform.right* -bulletUpAngle) * bulletForward;
        
        thisRigidbody.AddForce(bulletForward * speed * speed * mass / FORCEVELO);
        //print(bulletForward*speed * speed * mass / FORCEVELO);
    }
	
	// Update is called once per frame
	void Update () {
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
