using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinPublic : MonoBehaviourPunCallbacks
{
    public float roomLimit = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            if (PhotonNetwork.IsConnected)
            {
                if (!PhotonNetwork.InRoom)
                {
                    PhotonNetwork.LeaveRoom();
                    PhotonNetwork.JoinRandomRoom();
                }
                else if (PhotonNetwork.CurrentRoom.PlayerCount < roomLimit)
                {
                    PhotonNetwork.JoinRoom(PhotonNetwork.CurrentRoom.Name);
                }
            }
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string roomName = GenerateRandomRoomName();
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = (byte)roomLimit };
        PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    private string GenerateRandomRoomName()
    {
        const string characters = "0123456789";
        int roomNameLength = 5;
        string roomName = "";

        for (int i = 0; i < roomNameLength; i++)
        {
            roomName += characters[Random.Range(0, characters.Length)];
        }

        return roomName;
    }
}
