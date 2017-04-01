using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Sprite[] BulletImages;

    [SerializeField]
    private GameObject enemyBoom;

    public GameObject bullet;

    private Vector3 randomPos;

    public int enemyBlood;

    private int bulletMax;
    public int enemyKindNum;
    public int enemyBulletKindNum;

    private float distance;
    private float randomRange;
    private float bulletSecondWait;
    private float waveWait;
    private int randomNum;
    private float enemySpeed;
    private bool isSetPos;
    private Vector3 endPos;
    private Vector3 endPos2;

    private void Start()
    {
        endPos = RandomEnemyEndPos();
        endPos2 = RandomEnemyEndPos2();
        LevelChange();
        isSetPos = false;
        enemySpeed = GlobalData.enemySpeed[GlobalData.hardLevel];
        bulletMax = Random.Range(2, 5);
        randomNum = Random.Range(0, 4);
        randomRange = 0.3f;
    }

    private void Update()
    {
        if (enemyBlood <= 0)
        {
            EnemyDying();
        }
        EnemyMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Outside")
        {
            StartCoroutine(BulletWaves(randomNum));
        }
        if (collision.gameObject.tag == "Lazer")
        {
            enemyBlood -= GlobalData.fireDamage;
        }
    }

    /*--------------------------------------*/

    private Vector3 RandomEnemyEndPos()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-6, -4), transform.position.z);
    }

    private Vector3 RandomEnemyEndPos2()
    {
        return new Vector3(Random.Range(-6, -3), Random.Range(-1, 1), transform.position.z);
    }

    private void EnemyMove()
    {
        switch (enemyKindNum)
        {
            /*1:斜线运动;2:向下;3:弧线;*/
            case 1:
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos, enemySpeed * Time.deltaTime);

                    break;
                }
            case 2:
                {
                    gameObject.transform.position -= new Vector3(0, enemySpeed * Time.deltaTime, 0);
                    break;
                }
            case 3:
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos2, enemySpeed * Time.deltaTime);
                    break;
                }
            default: { break; }
        }
    }

    private IEnumerator BulletWaves(int randonNum)
    {
        while (true)
        {
            for (int i = 0; i < bulletMax; ++i)
            {
                randomPos.x = Random.Range(transform.position.x - randomRange, transform.position.x + randomRange);
                randomPos.y = Random.Range(transform.position.y - randomRange, transform.position.y + randomRange);
                randomPos.z = transform.position.z;
                GameObject getBullet = Instantiate(bullet, randomPos, transform.rotation);
                getBullet.GetComponent<SpriteRenderer>().sprite = BulletImages[randonNum];
                yield return new WaitForSeconds(bulletSecondWait);
            }
        }
    }

    private void EnemyDying()
    {
        GlobalData.playerScore += 10f * (GlobalData.hardLevel + 1);
        GlobalData.playerBlood += 0.3f;
        GameObject getEnemyBoom = Instantiate(enemyBoom, transform.position, transform.rotation);
        Destroy(getEnemyBoom, 0.2f);
        Destroy(gameObject);
    }

    public void LevelChange()
    {
        enemyBlood = GlobalData._enemyBlood;
        bulletSecondWait = Random.Range(GlobalData.bulletWait[GlobalData.hardLevel], GlobalData.bulletWait[GlobalData.hardLevel + 1]);
    }
}