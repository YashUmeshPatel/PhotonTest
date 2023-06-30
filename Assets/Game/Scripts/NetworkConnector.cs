using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnector : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    #region Pun Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to photon!");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning($"Failed to connect: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        PhotonNetwork.CreateRoom("My Room");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} Joined!");

        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.one, Quaternion.identity);
    }

    #endregion
}
