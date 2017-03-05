using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public GameObject thisGameObject;
    public GameObject bullet;
    public GameObject beam;
    const float ACCELATIONCONST= 0.1f;
    const float ROTATIONCONST = 5.0f;
    const float BULLETCOOLDOWN = 0.1f;
    const float BULLETPOSITION = 0.7f;
    const float BULLETPUPPOSITION = 0.0f;
    float bulletInterval = 0f;
    float beamInterval = 0f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float hInput=Input.GetAxis("Horizontal");
        float vInput=Input.GetAxis("Vertical");
        float shotInput = Input.GetAxis("Fire1");
        float beamInput = Input.GetAxis("Fire3");

        thisGameObject.transform.Rotate(Vector3.up * hInput * ROTATIONCONST);
        thisGameObject.transform.Translate(Vector3.forward * vInput * ACCELATIONCONST);
        if (shotInput != 0 && bulletInterval ==0)
        {
            bulletInterval = BULLETCOOLDOWN;
            shot();
        }
        if (bulletInterval > 0)
        {
            bulletInterval -= Time.deltaTime;
        }
        if (bulletInterval < 0)
            bulletInterval = 0;

        if (beamInput != 0 && beamInterval == 0)
        {
            beamInterval = BULLETCOOLDOWN;
            beamShot();
        }
        if (beamInterval > 0)
        {
            beamInterval -= Time.deltaTime;
        }
        if (beamInterval < 0)
            beamInterval = 0;

    }
    void shot()
    {
        GameObject newBullet = (GameObject)Instantiate(bullet,thisGameObject.transform.position+ thisGameObject.transform.forward* BULLETPOSITION+ thisGameObject.transform.up * BULLETPUPPOSITION, thisGameObject.transform.rotation);
        newBullet.SetActive(true);
    }
    void beamShot()
    {
        GameObject newBullet = (GameObject)Instantiate(beam, thisGameObject.transform.position + thisGameObject.transform.forward * BULLETPOSITION + thisGameObject.transform.up * BULLETPUPPOSITION, thisGameObject.transform.rotation);
        newBullet.GetComponent<beamAutoStart>().speed = 10000f;
        //newBullet.GetComponent<bulletAutoStart>().bulletUpAngle = 0f;
        newBullet.SetActive(true);
    }
}
