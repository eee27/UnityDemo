using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bossBullet;

    [SerializeField]
    private Sprite[] bossImages;

    [SerializeField]
    private GameObject bossBoom;

    public int bossBlood;
    private float bossSpeed;
    private float bossStopPos;
    private bool isCanShoot;
    private bool isBossDie;

    // Use this for initialization
    private void Start()
    {
        isBossDie = false;
        bossBlood = GlobalData.bossBlood;
        bossSet();
    }

    // Update is called once per frame
    private void Update()
    {
        bossMove(transform.position, bossStopPos);
        bossShoot();
        if (bossBlood <= 0 && !isBossDie)
        {
            GlobalData.playerScore += 50f * (GlobalData.hardLevel + 1);
            Instantiate(bossBoom, transform.position, transform.rotation);
            AudioController.PlaySound();
            isBossDie = true;
            Time.timeScale = 0.1f;
            Invoke("OnBossDie", 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lazer" && transform.position.y <= 3f)
        {
            bossBlood -= GlobalData.fireDamage;
        }
    }

    /*---------------------------------------------*/

    private void bossSet()
    {
        GetComponent<SpriteRenderer>().sprite = bossImages[0];

        bossStopPos = 1.5f;
        bossSpeed = 0.8f;
        isCanShoot = true;
    }

    private void bossMove(Vector3 pos, float stopPos)
    {
        if (pos.y > stopPos)
        {
            transform.Translate(0, -1 * Time.deltaTime * bossSpeed, 0);
        }
        else if (pos.y <= stopPos)
        {
            GetComponent<SpriteRenderer>().sprite = bossImages[1];
        }
    }

    private void bossShoot()
    {
        if (isCanShoot && transform.position.y <= bossStopPos)
        {
            Instantiate(bossBullet, transform.position + new Vector3(0, -0.3f, 0), transform.rotation, transform.parent);
            Instantiate(bossBullet, transform.position + new Vector3(0.3f, 0, 0), transform.rotation, transform.parent);
            Instantiate(bossBullet, transform.position + new Vector3(-0.3f, 0, 0), transform.rotation, transform.parent);
            isCanShoot = false;
        }
    }

    private void OnBossDie()
    {
        GlobalFunction.LoadScene("win");
    }
}