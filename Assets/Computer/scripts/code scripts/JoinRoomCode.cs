using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinRoomCode : MonoBehaviourPunCallbacks
{
    public string code = "";
    private bool joinRequested = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
                joinRequested = true;
            }
            else if (PhotonNetwork.IsConnectedAndReady)
            {
                JoinCodeRoom();
            }
            else
            {
                joinRequested = true;
            }
        }
    }

    public override void OnLeftRoom()
    {
        if (joinRequested)
        {
            JoinCodeRoom();
            joinRequested = false;
        }
    }

    public override void OnConnectedToMaster()
    {
        if (joinRequested)
        {
            JoinCodeRoom();
            joinRequested = false;
        }
    }

    private void JoinCodeRoom()
    {
        RoomOptions options = new RoomOptions { MaxPlayers = 10, IsVisible = false, IsOpen = true };
        PhotonNetwork.JoinOrCreateRoom(code, options, TypedLobby.Default);
    }
}
