using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerCodes : MonoBehaviour
{
    GameObject turningCircle;
    GameObject mainCircle;
    public Animator animator;
    public Text turningCircleLevel;
    public Text One;
    public Text Two;
    public Text Three;
    public int HowManySmallCircles;
    bool Control = true;

    void Start()
    {
        PlayerPrefs.SetInt("record", int.Parse(SceneManager.GetActiveScene().name));
        turningCircle = GameObject.FindGameObjectWithTag("turningCircleTag");
        mainCircle = GameObject.FindGameObjectWithTag("MainCircleTag");
        turningCircleLevel.text = SceneManager.GetActiveScene().name;
        if (HowManySmallCircles<2)
        {
            One.text = HowManySmallCircles + "";
        }
        else if (HowManySmallCircles<3)
        {
            One.text = HowManySmallCircles + "";
            Two.text = (HowManySmallCircles - 1) + "";
        }
        else
        {
            One.text = HowManySmallCircles + "";
            Two.text = (HowManySmallCircles - 1) + "";
            Three.text = (HowManySmallCircles - 2) + "";
        }
    }
    public void ShowTextInSmallCircle()
    {
        HowManySmallCircles--;
        if (HowManySmallCircles < 2)
        {
            One.text = HowManySmallCircles + "";
            Two.text = "";
            Three.text = "";
        }
        else if (HowManySmallCircles < 3)
        {
            One.text = HowManySmallCircles + "";
            Two.text = (HowManySmallCircles - 1) + "";
            Three.text = "";
        }
        else
        {
            One.text = HowManySmallCircles + "";
            Two.text = (HowManySmallCircles - 1) + "";
            Three.text = (HowManySmallCircles - 2) + "";
        }
        if (HowManySmallCircles==0)
        {
            StartCoroutine(NewLevel());
        }
    }
    IEnumerator NewLevel()
    {
        turningCircle.GetComponent<Turning>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        yield return new WaitForSeconds(1);
        if (Control)
        {
            animator.SetTrigger("NewLevel");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
        
    }

    public void GameOver()
    {
        StartCoroutine(SummonedGameOver());
    }

    IEnumerator SummonedGameOver()
    {
        turningCircle.GetComponent<Turning>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("gameOver");
        Control = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }


}

    