using UnityEngine;
using Photon.Pun;

public class Disconnect : MonoBehaviour
{
    public string HandTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HandTag))
        {
            if (PhotonNetwork.InRoom)
                PhotonNetwork.LeaveRoom();
        }
    }
}
