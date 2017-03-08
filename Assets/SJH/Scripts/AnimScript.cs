using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AnimScript : MonoBehaviour {

    private Animator anim;
    private float speed = 0f;
    private bool collecting = false;
    //private CharacterController m_CharacterController;
    RigidbodyFirstPersonController m_CharacterController;


    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        //m_CharacterController = GetComponent<CharacterController>();
        m_CharacterController = GetComponent<RigidbodyFirstPersonController>();

        ChangeChildLayer(transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 vel2 = new Vector2(m_CharacterController.Velocity.x, m_CharacterController.Velocity.z);

        if(vel2.sqrMagnitude > 0)
        {
            speed = 1f;
        }
        else
        {
            speed = 0f;
        }


        if (Input.GetMouseButton(1))
            collecting = true;
        else
            collecting = false;

        anim.SetFloat("Speed", speed);
        anim.SetBool("Collecting", collecting);
    }
    
    public void ChangeChildLayer(Transform trans)
    {
        if (trans.childCount > 0)
        {            
            for (int i = 0; i < trans.childCount; i++)
            {
                ChangeChildLayer(trans.GetChild(i));
            }
            trans.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else
        {
            trans.gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}
