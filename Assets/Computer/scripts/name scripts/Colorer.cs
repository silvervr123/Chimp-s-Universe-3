using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.VR;
public class Colorer : MonoBehaviour
{
    public Color YourColor;
    public string Handtag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == Handtag)
        {
            Color myColour = YourColor;
            PhotonVRManager.SetColour(myColour);
        }

    }
}
