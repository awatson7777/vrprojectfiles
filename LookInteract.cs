using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LookInteract : MonoBehaviour
{

    public Image imgLook;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;
    public int RayDistance = 10;
    private RaycastHit _hit;
    public UnityEvent GVRClick;
    public Grab G;
    public AudioSource Sound;
    public AudioClip Clip;


    // Start is called before the first frame update
    void Start()
    {
        GVROff();
        imgLook.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
        ///Check the gvrStatus and initiate the functions if true
        //If the gvrTimer value is greater than the totalTime, perform function
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgLook.fillAmount = gvrTimer / totalTime;
        }

        if (gvrTimer > totalTime)
        {
            GVRClick.Invoke();
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, RayDistance))
        {
            if (imgLook.fillAmount == 1)
            {
                GVROff();
            }

        }

    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVRSilverLockOn()
        //Checks if silver key is in hand and allows the function to delete game objects to allow the player to progress
    {
        if (G.silverkeyInHand)
        {
            gvrStatus = true;
            G.silverkey.transform.SetParent(G.silverkeyPos.transform);
            G.silverkey.transform.localPosition = new Vector3(0f, 0f, 0f);
            G.silverkeyInHand = true;
            GameObject go = GameObject.Find("SilverGate");
            if (go)
            {
                Destroy(go.gameObject);
                Debug.Log(name + "been destroyed");
            }
            GameObject sk = GameObject.Find("SilverKey");
            if (sk)
            {
                Destroy(sk.gameObject);
                Debug.Log(name + "been destroyed");
            }
        }
    }

    public void GVRSilverLockOff()
    {
        if (!G.silverkeyInHand)
        {
            gvrStatus = false;
        }
    }

    public void DestroyQ1Gate()
        //Destroys specific game objects and returns a console log
    {
        Sound.PlayOneShot(Clip, 1.0f);
        GameObject gate1 = GameObject.Find("Q1Gate");
        if (gate1)
        {
            Destroy(gate1.gameObject);
            Debug.Log(name + "been destroyed");
        }
    }

    public void DestroyQ2Gate()
    {
        Sound.PlayOneShot(Clip, 1.0f);
        GameObject gate2 = GameObject.Find("Q2Gate");
        if (gate2)
        {
            Destroy(gate2.gameObject);
            Debug.Log(name + "been destroyed");
        }
    }

    public void WrongAnswer1()
        //Plays sound to indicate the users choice was incorrect
    {
        Sound.PlayOneShot(Clip, 1.0f);
    } 
    public void WrongAnswer2()
    {
        Sound.PlayOneShot(Clip, 1.0f);
    }

    public void GVRGoldLockOn()
    //Checks if gold key is in hand and allows the function to delete game objects to allow the player to progress
    {
        if (G.goldkeyInHand)
        {
            gvrStatus = true;
            G.goldkey.transform.SetParent(G.goldkeyPos.transform);
            G.goldkey.transform.localPosition = new Vector3(0f, 0f, 0f);
            G.goldkeyInHand = true;
            GameObject go = GameObject.Find("GoldGate");
            if (go)
            {
                Destroy(go.gameObject);
                Debug.Log(name + "been destroyed");
            }
            GameObject gk = GameObject.Find("GoldKey");
            if (gk)
            {
                Destroy(gk.gameObject);
                Debug.Log(name + "been destroyed");
            }
        }
    }

    public void GVRGoldLockOff()
    {
        if (!G.goldkeyInHand)
        {
            gvrStatus = false;
        }
    }

    public void GVRLeafletOn()
    //Checks if ball is in hand and allows the function to delete game objects to allow the player to progress
    {
        if (G.leafletInHand)
        {
            gvrStatus = false;
            G.ball.transform.SetParent(G.leafletPos.transform);
            G.ball.transform.localPosition = new Vector3(0f, 0f, 0f);
            G.leafletInHand = false;
        }
    }

    public void GVRLeafletOff()
    {
        if (!G.leafletInHand)
        {
            gvrStatus = false;
        }
    }

    public void ColourChange()
    {
        if (GetComponent<Renderer>().material.color != Color.black)
        {
            _hit.transform.gameObject.GetComponent<ChangeBoxColour>().Black();
            gvrStatus = false;
        }

       else if (GetComponent<Renderer>().material.color == Color.black)
        {
            _hit.transform.gameObject.GetComponent<ChangeBoxColour>().Blue();
            gvrStatus = false;
        }

    }

    /*public void PickItem()
    {
        if (imgLook.fillAmount == 1 && _hit.transform.CompareTag("Grab") && gvrStatus)
        {
            _hit.transform.gameObject.GetComponent<Grab>().PickupLeaflet();
            gvrStatus = false;
        }
    }*/

    public void FinishGame()
    {
        Application.Quit();
    }


    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgLook.fillAmount = 0;
    }

}
