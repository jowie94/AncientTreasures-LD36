using UnityEngine;
using System.Collections;
using MandarineStudio.AncientTreasures;

public class Spawn : MonoBehaviour
{
    public bool IsCheckpoint = false;

    void OnTrigerEnter2D(Collider2D other)
    {
        if (IsCheckpoint)
            GameManager.Instance.Checkpoint(this);
    }

    public void SpawnPlayer()
    {
        GameObject player = (GameObject) Instantiate(Resources.Load("Prefabs/Player"));
        player.name = "Player";
        player.transform.position = transform.position;
        player.GetComponent<PlatformerCharacterController>().Life = GameManager.Instance.Life;
        CameraMovement camera = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        camera.Target = player.transform;
    }
}
