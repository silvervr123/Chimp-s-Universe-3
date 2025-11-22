using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Networking;

public class OnlinePlayerCounterwebhook : MonoBehaviourPunCallbacks
{

    public string discordWebhookURL;
    private float timer = 0f;
    private float interval = 60f;

    private void Update()
    {
        if (!PhotonNetwork.IsConnected || !PhotonNetwork.IsMasterClient) return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            int playerCount = PhotonNetwork.CountOfPlayers;
            string message = $"[Photon] Online Players: {playerCount}";

            StartCoroutine(SendToDiscord(message));
            timer = 0f;
        }
    }

    private IEnumerator SendToDiscord(string message)
    {
        if (string.IsNullOrEmpty(discordWebhookURL)) yield break;

        string jsonPayload = "{\"content\":\"" + message + "\"}";

        UnityWebRequest request = new UnityWebRequest(discordWebhookURL, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
    }
}
