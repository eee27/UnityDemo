using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBase;

    [SerializeField]
    private GameObject lazer;

    [SerializeField]
    private GameObject player;

    private float moveSpeed;
    private GameObject lazered;
    private bool isLazered;
    private Vector3 vector3;

    private void Start()
    {
        moveSpeed = GlobalData.playerSpeed * 0.3f;
        isLazered = false;
    }

    private void Update()
    {
        GetTouch();
    }

    /*----------------------------------*/

    private void GetTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            playerBase.transform.Translate(touchDeltaPosition.x * moveSpeed * Time.deltaTime, touchDeltaPosition.y * moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetTouch(0).phase != TouchPhase.Moved && !isLazered)
        {
            vector3 = new Vector3(playerBase.transform.position.x, playerBase.transform.position.y + 0.3f, playerBase.transform.position.z);
            lazered = Instantiate(lazer, vector3, playerBase.transform.rotation, playerBase.transform);
            isLazered = true;
        }
        if (isLazered && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            isLazered = false;
            Destroy(lazered);
        }
    }
}