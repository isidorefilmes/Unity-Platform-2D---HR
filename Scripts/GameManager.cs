using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    private int vidas = 2;
    private int diamantes = 0;


	// Use this for initialization
	void Awake ()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
	}

    // Update is called once per frame
    void Start()
    {
        AtualizaHud();
    }
    void Update ()
    {
		
	}
    public void SetVidas(int vida)
    {
        vidas += vida;
        if(vidas >= 0)
        AtualizaHud();
    }
    public int GetVidas()
    {
        return vidas;
    }

    public void SetDiamantes (int diamante)
    {
        diamantes += diamante;
        if (diamantes >= 50)
        {
            diamantes = 0;
            vidas += 1;
        }
        AtualizaHud();
    }

    public void AtualizaHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("DiamText").GetComponent<Text>().text = diamantes.ToString();
    }

}
