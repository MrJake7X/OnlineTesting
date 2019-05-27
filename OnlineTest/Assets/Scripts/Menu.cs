using System;
using UdpKit;
using UnityEngine;

public class Menu : Bolt.GlobalEventListener
{
    // Start server function to ve the host
    public void StartServer()
    {
        BoltLauncher.StartServer();
    }
    
    // Start as a client function
    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    // If the we are the server set the match name and load the first scene, THIS IS FOR THE SERVER PART
    public override void BoltStartDone()
    {
        if (BoltNetwork.isServer)
        {
            string matchName = "Test Match";

            BoltNetwork.SetServerInfo(matchName, null);
            BoltNetwork.LoadScene("SampleScene");
        }
    }
    // Loops for all the session on Phton web and connect for the first it match
    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if(photonSession.Source == UdpSessionSource.Photon)
            {
                BoltNetwork.Connect(photonSession);
            }
        }
    }
}