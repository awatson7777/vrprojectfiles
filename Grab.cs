using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public LookInteract Look;
    public GameObject ball;
    public GameObject goldkey;
    public GameObject silverkey;
    public GameObject playerHand;
    public GameObject leafletPos;
    public GameObject goldkeyPos;
    public GameObject silverkeyPos;
    public AudioSource Sound;
    public AudioClip pickup;
    public bool leafletInHand = false;
    public bool goldkeyInHand = false;
    public bool silverkeyInHand = false;
    Vector3 ballPosition;

    // Start is called before the first frame update
    void Start()
        //Sets values for the interactable objects to return to so their scale isn't bugged due to the scale conversions when grabbed
    {
        ball.transform.SetParent(leafletPos.transform);
        ball.transform.localPosition = new Vector3(0f, 0f, 0f);
        ball.transform.localScale = new Vector3(1f, 1f, 1f);
        ball.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        silverkey.transform.SetParent(silverkeyPos.transform);
        silverkey.transform.localPosition = new Vector3(0f, 0f, 0f);
        silverkey.transform.localScale = new Vector3(1f, 1f, 1f);
        silverkey.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        goldkey.transform.SetParent(goldkeyPos.transform);
        goldkey.transform.localPosition = new Vector3(0f, 0f, 0f);
        goldkey.transform.localScale = new Vector3(1f, 1f, 1f);
        goldkey.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }


    // Update is called once per frame
    void Update()
    {
      //  if (Input.GetButtonDown("Fire1"))
       // {
        //    PickupItem();
       // }
    }

    public void PickupLeaflet()
    { //check if "leaflet" is not in hand, which places the leaflet in new co-ordinates attached to the playerHand to be in the players view
        //Sets scaling to make the object look normal when in the different viewport
        if (!leafletInHand)
        {
            this.GetComponent<Grab>().enabled = true;
            Sound.PlayOneShot(pickup, 1.0f);
            ball.transform.SetParent(playerHand.transform);
            ball.transform.localPosition = new Vector3(0f, -0.187f, 2.8f);
            ball.transform.localScale = new Vector3(-0.25f, 0.1f, 0.9f);
            ball.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            leafletInHand = true;
        }
        else if (leafletInHand)
        {
            this.GetComponent<Grab>().enabled = false;
            leafletInHand = false;
            Look.GVROff();

        }
    }

    public void PickupGoldKey()
    {
        if (!goldkeyInHand && !leafletInHand)
            //doesn't allow the player to pickup the key if they have the leaflet component picked up at the same time
        {
            this.GetComponent<Grab>().enabled = true;
            Sound.PlayOneShot(pickup, 1.0f);
            goldkey.transform.SetParent(playerHand.transform);
            goldkey.transform.localPosition = new Vector3(0f, -0.187f, 2.8f);
            goldkey.transform.localScale = new Vector3(-0.25f, 0.1f, 0.9f);
            goldkey.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            goldkeyInHand = true;
        }
        else if (goldkeyInHand)
        {
            this.GetComponent<Grab>().enabled = false;
            goldkeyInHand = false;
            Look.GVROff();

        }
    }

    public void PickupSilverKey()
    {
        if (!silverkeyInHand && !leafletInHand)
        {
            this.GetComponent<Grab>().enabled = true;
            Sound.PlayOneShot(pickup, 1.0f);
            silverkey.transform.SetParent(playerHand.transform);
            silverkey.transform.localPosition = new Vector3(0f, -0.187f, 2.8f);
            silverkey.transform.localScale = new Vector3(-0.25f, 0.1f, 0.9f);
            silverkey.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            silverkeyInHand = true;
        }
        else if (silverkeyInHand)
        {
            this.GetComponent<Grab>().enabled = false;
            silverkeyInHand = false;
            Look.GVROff();

        }
    }

}
