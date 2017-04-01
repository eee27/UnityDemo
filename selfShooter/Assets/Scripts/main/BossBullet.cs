using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private float bossBulletSpeed;

    // Use this for initialization
    private void Start()
    {
        bossBulletSpeed = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        BulletMove();
    }

    /*---------------------------------*/

    private void BulletMove()
    {
        transform.Translate(0, -1 * Time.deltaTime * bossBulletSpeed, 0);
    }
}