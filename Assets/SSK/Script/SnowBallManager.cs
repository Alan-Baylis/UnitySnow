using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallManager : MonoBehaviour {
    const float FORCEVELO = 2.0f;
    public float speed;
    public float mass;
    public float bulletUpAngle;
    //public GameObject theBody;
    public Vector3 forward;
    public Rigidbody thisRigidbody;
    public GameObject thisGameObject;
    public AudioSource hitAudioSource;
    // Use this for initialization
    bool isHit = false;
    int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisGameObject = thisRigidbody.gameObject;

        foreach (AudioSource audio in GetComponents<AudioSource>())
        {
            if (audio.clip.name == "snowBallHit")
            {
                hitAudioSource = audio;

            }

        }
        Vector3 bulletForward = forward;
        thisRigidbody.AddForce(bulletForward * speed * speed * thisRigidbody.mass / FORCEVELO);
        //theBody = thisGameObject.transform.parent.gameObject;

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(thisRigidbody.velocity);
        if (thisGameObject.transform.position.magnitude > 1000)
        {
            Destroy(thisGameObject);
        }
        if (isHit && !hitAudioSource.isPlaying)
            Destroy(thisGameObject);
        

    }
    public void initSnowBall(Vector3 forward, int damage)
    {
        this.forward = forward;

        //bulletForward = Quaternion.Euler(theBody.transform.right * -bulletUpAngle) * bulletForward;
        //bulletForward = Quaternion.Euler(theBody.transform.right * -bulletUpAngle) * bulletForward;


        isHit = false;
        this.damage = damage;
    }


    void OnCollisionEnter(Collision collision)
    {
        print("Colliison!"+collision.gameObject.name + LayerMask.LayerToName(collision.gameObject.layer));
        if ( collision.gameObject.layer == LayerMask.NameToLayer("enemy") ){
            CharacterManager otherCtManager = collision.gameObject.GetComponent<CharacterManager>();
            otherCtManager.beShot(damage);
        }
        hitAudioSource.Play();
        Destroy(GetComponent<SphereCollider>());
        Destroy(GetComponent<MeshRenderer>());
        isHit = true;
        

    }
}
