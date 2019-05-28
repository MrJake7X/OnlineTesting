using UnityEngine;


// IMPORTANT, THIS IS CALLED AUTOMATICATLLY IF THE NEXT LINE IT'S WRITED, AND EXECUTE THE DIFERENTS CALLBACKS DEPENDING FROM SERVER/CLIENT ACTION

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string scene)
    {
        var spawnPosition = new Vector3(Random.Range(-8, 8), 0, 0);

        if (BoltNetwork.IsServer)
        {
            BoltNetwork.Instantiate(BoltPrefabs.Killer, spawnPosition, Quaternion.identity);
        }
        else
        {
            BoltNetwork.Instantiate(BoltPrefabs.Survivor, spawnPosition, Quaternion.identity);
        }
    }
}