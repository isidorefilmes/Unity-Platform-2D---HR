using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour {

    Animator anim;
    public float jumpForce;
    public int diamantes;
    public GameObject diamantePrefab;

    public AudioClip[] audios;
    AudioSource audioS;

	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
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
            audioS.clip = audios[0];
            audioS.Play();
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Colidindo");
            if (diamantes > 0)
            {
                GameObject tempDiamante = Instantiate(diamantePrefab, transform.position, transform.rotation) as GameObject;
                tempDiamante.GetComponent<Animator>().SetTrigger("Coletando");
                tempDiamante.GetComponent<AudioSource>().Play();
                diamantes -= 1;
                GameManager.gm.SetDiamantes(1);
                Destroy(tempDiamante, 0.840f);
            }
            else
            {
                audioS.clip = audios[1];
                audioS.Play();
                Destroy(gameObject);
            }
        }
    }
}
