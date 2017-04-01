using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerBase = GameObject.FindWithTag("PlayerBase");

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
        {
            GameObject getBoom = Instantiate(boom, transform.position, transform.rotation);

            Destroy(getBoom, 0.6f);
            Destroy(collision.gameObject);
            Destroy(playerBase);
            AudioController.PlaySound();
            GlobalData.isDie = true;
            GlobalFunction.LoadScene("win");
        }
    }
}