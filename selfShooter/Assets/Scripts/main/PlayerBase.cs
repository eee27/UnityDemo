using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapRange
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private SpriteRenderer sprite;
    public GameObject lazer;
    private GameObject lazered;
    public static bool isLazered;

    private Rigidbody2D rb;

    public float playerSpeed;

    public MapRange mapRange;
    private float lazerTime;
    private float restTime;
    private bool isRest;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = player.GetComponent<SpriteRenderer>();
        isLazered = false;
        isRest = false;
        playerSpeed = GlobalData.playerSpeed;
        restTime = GlobalData.restTime;
        mapRange.xMin = -2.0f;
        mapRange.xMax = 2.0f;
        mapRange.yMin = -3f;
        mapRange.yMax = 3f;
    }

    private void FixedUpdate()
    {
        movePlayerBase();
    }

    private void Update()
    {
        checkButton();
        checkLazer();
    }

    /*-----------------------------------*/

    private void movePlayerBase()
    {
        float moveX = Input.GetAxis("X");
        float moveY = Input.GetAxis("Y");
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * playerSpeed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, mapRange.xMin, mapRange.xMax), Mathf.Clamp(rb.position.y, mapRange.yMin, mapRange.yMax));
    }

    private void checkButton()
    {
        if (Input.GetButtonDown("Fire") && !GlobalData.isUI)
        {
            if (!isLazered)
            {
                lazered = Instantiate(lazer, transform, false);
                isLazered = true;
                lazerTime = GlobalData.lazerTime;
            }
        }
        if (Input.GetButtonUp("Fire"))
        {
            if (isLazered && !isRest)
            {
                Destroy(lazered);
                isLazered = false;
            }
        }
    }

    private void checkLazer()
    {
        if (isLazered)
        {
            lazerTime -= Time.deltaTime;
            if (lazerTime <= 0)
            {
                Destroy(lazered);
                isRest = true;
                sprite.color = Color.red;
            }
        }
        if (isRest)
        {
            restTime -= Time.deltaTime;
            if (restTime <= 0)
            {
                isLazered = false;
                isRest = false;
                sprite.color = Color.white;
            }
        }
    }
}