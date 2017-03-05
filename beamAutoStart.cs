using UnityEngine;
using System.Collections;

    public class beamAutoStart : MonoBehaviour
    {
        const float FORCEVELO = 2.0f;
        public float speed = 10000.0f;
        public float mass = 0.1f;
        public Rigidbody thisRigidbody;
        public GameObject thisGameObject;
        public GameObject theBody;
        public SphereCollider thisCollider;
        LineRenderer thisLineRenderer;
        float interval = 1f;
        bool isInterval = false;
        // Use this for initialization
        void Start()
        {
            thisRigidbody = GetComponent<Rigidbody>();
            thisGameObject = thisRigidbody.gameObject;
            thisLineRenderer = GetComponent<LineRenderer>();
            thisCollider = GetComponent<SphereCollider>();
            Vector3 bulletForward = theBody.transform.forward;
            thisLineRenderer.SetPosition(0, thisGameObject.transform.position);
            thisRigidbody.AddForce(bulletForward * speed * speed * mass / FORCEVELO);

            //print(bulletForward*speed * speed * mass / FORCEVELO);
        }

        // Update is called once per frame
        void Update()
        {
            //print(thisRigidbody.velocity);
            thisLineRenderer.SetPosition(1, thisGameObject.transform.position);
            if (thisGameObject.transform.position.magnitude > 10000)
            {
                Destroy(thisGameObject);
            }
            if (isInterval)
            {
                interval -= Time.deltaTime;
            }
            if (interval < 0)
            {
                Destroy(thisGameObject);
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            //thisLineRenderer.SetPosition(1, thisGameObject.transform.position);
            //Destroy(thisGameObject);
            isInterval = true;
            //thisRigidbody.Sleep();
            Destroy(thisRigidbody);
            Destroy(thisCollider);
        }
    }