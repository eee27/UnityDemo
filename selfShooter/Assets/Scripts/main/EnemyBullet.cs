using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Transform target;
    public bool isSetPos;
    public Vector3 setPos;
    public int bulletMoveKindNum;
    private GameObject player;

    private void Start()
    {
        LevelChange();
        GetPlayer();
        isSetPos = false;
        SetBulletMove();
    }

    private void Update()
    {
        SetBulletMove();
    }

    /*--------------------------------*/

    private void GetPlayer()
    {
        player = GameObject.FindWithTag("Player");
        if (player)
        {
            target = player.transform;
            setPos = target.position - transform.position;
        }
        else
        {
            bulletMoveKindNum = 2;
        }
    }

    private void SetBulletMove()
    {//1.向着玩家移动 2.向下移动
        switch (bulletMoveKindNum)
        {
            case 1:
                {
                    if (!isSetPos)
                    {
                        setPos = setPos.normalized;
                        isSetPos = true;
                        transform.position += (setPos * moveSpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.position += (setPos * moveSpeed * Time.deltaTime);
                    }
                    break;
                }
            case 2: { transform.position += new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime; break; }
            default: { break; }
        }
    }

    public void LevelChange()
    {
        moveSpeed = Random.Range(GlobalData.bulletSpeed[GlobalData.hardLevel], GlobalData.bulletSpeed[GlobalData.hardLevel + 1]);
    }
}