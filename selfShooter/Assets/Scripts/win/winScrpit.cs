using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winScrpit : MonoBehaviour
{
    [SerializeField]
    private GameObject hardestText;

    [SerializeField]
    private GameObject button2;

    [SerializeField]
    private Text winText;

    // Use this for initialization
    private void Start()
    {
        Text _winText = winText.GetComponent<Text>();
        Text _buttonText = button2.transform.GetChild(0).GetComponent<Text>();

        hardestText.SetActive(false);
        if (GlobalData.isDie)
        {
            _winText.text = "You Die!";
            _buttonText.text = "Retry";
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    /*-----------------------------------------*/

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadHarder()
    {
        if (!GlobalData.isDie)
        {
            if (GlobalData.hardLevel == 2)
            {
                hardestText.SetActive(true);
                button2.SetActive(false);
            }
            else
            {
                GlobalData.hardLevel += 1;
                GlobalFunction.LoadScene("main");
            }
        }
        else { GlobalFunction.LoadScene("main"); }
    }
}