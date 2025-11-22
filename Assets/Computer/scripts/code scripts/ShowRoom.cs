using UnityEngine;
using Photon.Pun;
using TMPro;

public class ShowRoom : MonoBehaviour
{
    public TextMeshPro Text;

    private void FixedUpdate()
    {
        if (PhotonNetwork.InRoom)
        {
            Text.text = "In Room: " + PhotonNetwork.CurrentRoom.Name;
        }
        else
        {
            Text.text = "Not Connected";
        }
    }
}
