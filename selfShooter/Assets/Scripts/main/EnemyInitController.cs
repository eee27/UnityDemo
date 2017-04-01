using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitController : MonoBehaviour
{
    [SerializeField]
    private GameObject bossPrefab1;

    [SerializeField]
    private GameObject enemyBase;

    [SerializeField]
    private GameObject[] enemyKind;

    public int hardlevel = 0;

    public float enemyInitTime = 0;
    public float enemyWaveInitTime = 0;
    private float levelTime = 0;
    private Vector3 enemyRandomPos;
    private int randomEnemyKind;
    public int enemyWaveNum;
    private float thisLevelTime;
    private bool isBossInit;

    // Use this for initialization
    private void Start()
    {
        hardlevel = GlobalData.hardLevel;
        isBossInit = false;
        thisLevelTime = GlobalData.timePerLevel[hardlevel];
        GlobalFunction.OnHardLevelChange();
        LevelChange();
        StartCoroutine(EnemyInit());
    }

    private void Update()
    {
        thisLevelTime -= Time.deltaTime;
        if (thisLevelTime <= 0 && !isBossInit)
        {
            GameObject getBoss = Instantiate(bossPrefab1, new Vector3(0, 8f, -1), transform.rotation);
            getBoss.transform.parent = enemyBase.transform;
            isBossInit = true;
        }
    }

    /*---------------------------------------*/

    private IEnumerator EnemyInit()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            for (int i = 0; i < enemyWaveNum; ++i)
            {
                enemyRandomPos.x = Random.Range(-2, 2);
                enemyRandomPos.y = Random.Range(3.5f, 4.5f);
                enemyRandomPos.z = -1;
                randomEnemyKind = Random.Range(0, 3);
                Instantiate(enemyKind[randomEnemyKind], enemyRandomPos, transform.rotation, enemyBase.transform);
                yield return new WaitForSeconds(enemyInitTime);
            }
            yield return new WaitForSeconds(enemyWaveInitTime);
        }
    }

    public void LevelChange()
    {
        enemyInitTime = GlobalData._enemyInitTime;
        enemyWaveInitTime = Random.Range(GlobalData.enemyWaveInitTime[GlobalData.hardLevel], GlobalData.enemyWaveInitTime[GlobalData.hardLevel + 1]);
        enemyWaveNum = GlobalData._enemyWaveNum;
    }
}