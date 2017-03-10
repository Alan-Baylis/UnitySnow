using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallManager : MonoBehaviour {
    const float FORCEVELO = 2.0f;
    public float speed = 20.0f;
    public float mass = 1.0f;
    public float bulletUpAngle = 5f;
    public GameObject theBody;
    public Vector3 forward;
    public Rigidbody thisRigidbody;
    public GameObject thisGameObject;
    public AudioSource hitAudioSource;
    // Use this for initialization
    bool isHit = false;
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisGameObject = thisRigidbody.gameObject;
        
        foreach (AudioSource audio in GetComponents<AudioSource>()){
            if (audio.clip.name == "snowBallHit")
                hitAudioSource = audio;

        }
        //theBody = thisGameObject.transform.parent.gameObject;
        Vector3 bulletForward = forward;
        bulletForward = Quaternion.Euler(theBody.transform.right * -bulletUpAngle) * bulletForward;

        thisRigidbody.AddForce(bulletForward * speed * speed * mass / FORCEVELO);
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print(thisRigidbody.velocity);
        if (thisGameObject.transform.position.magnitude > 10000)
        {
            Destroy(thisGameObject);
        }
        if (isHit && !hitAudioSource.isPlaying)
            Destroy(thisGameObject);

    }
    void OnCollisionEnter(Collision collision)
    {
        hitAudioSource.Play();
        Destroy(GetComponent<SphereCollider>());
        Destroy(GetComponent<MeshRenderer>());
        isHit = true;
        

    }
}
