using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamanteScript : MonoBehaviour {

    Animator anim;
    BoxCollider2D col;

    AudioSource audioS;

	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<BoxCollider2D>();
        audioS = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            GameManager.gm.SetDiamantes(1);
            col.enabled = false;
            anim.SetTrigger("Coletando");
            Destroy(gameObject, 0.840f);
        }
    }
}
