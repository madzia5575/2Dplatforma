using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter teleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        teleport.gameObject.SetActive(false);
        collision.transform.position = teleport.transform.position;
        StartCoroutine(TeleportPlayer(1.0f));
    }

    // Update is called once per frame
    IEnumerator TeleportPlayer(float time)
    {
        yield return new WaitForSeconds(time);
        teleport.gameObject.SetActive(true);
    }
}
