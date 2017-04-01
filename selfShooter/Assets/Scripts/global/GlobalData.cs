using System.Collections;
using System.Collections.Generic;

public class GlobalData
{
    public static bool isUI = false;
    public static bool isDie = false;
    public static int hardLevel = 0;
    public static float playerBlood = 0.261f;
    public static float playerScore = 0;
    public static float voice = 1f;
    public static int fireDamage = 6 / (hardLevel + 1);
    public static float playerSpeed = 2.5f;
    public static float lazerTime = 0.6f;
    public static float restTime = 1.6f;
    public static float[] enemySpeed = new float[3] { 1.2f, 1.8f, 2.2f };
    public static int bossBlood = 50 * (hardLevel + 1) * (hardLevel + 1);

    public static float[] enemyInitTime = new float[3] { 2.0f, 1.0f, 0.8f };
    public static float[] enemyWaveInitTime = new float[4] { 10.0f, 6.0f, 8.0f, 4.0f };
    public static int[] enemyWaveNum = new int[3] { 3, 5, 7 };
    public static int[] enemyBlood = new int[3] { 15, 25, 50 };
    public static float[] bulletWait = new float[4] { 8f, 2f, 4f, 1f };
    public static float[] bulletSpeed = new float[4] { 0.5f, 2f, 1.2f, 2.5f };
    public static float[] timePerLevel = new float[3] { 15f, 25f, 45f };

    public static float _enemyInitTime = 0;
    public static float _enemyWaveInitTime = 0;
    public static int _enemyWaveNum = 0;
    public static int _enemyBlood = 0;
}