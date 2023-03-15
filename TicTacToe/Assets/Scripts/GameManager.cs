using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum TurnState
    {
        PlayerTurn, IaTurn, EndMatch
    }
    public TurnState turnState;

    public GameObject PlayerShape;
    public GameObject IaShape;

    public List<Case> Cases;
    public List<GameObject> EmptyCases;


    [SerializeField] private IaManager Ia;

    public GameObject WinGameObject;
    public TextMeshProUGUI winText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        CheckWin();
        
        if(turnState == TurnState.IaTurn)
        {
            Ia.IaPlay();
        }

    }

    public void CheckWin()
    {
        if(EmptyCases.Count == 0)
        {
            turnState = TurnState.EndMatch;
            winText.text = "Draw";
            WinGameObject.SetActive(true);
        }
        // Horizontal
        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 3*i].Type == Cases[1 + 3 * i].Type && Cases[0 + 3 * i].Type == Cases[2 + 3 * i].Type)
            {
                if (Cases[0 + 3 * i].Type == Case.CaseType.Player)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "Player Win";
                    WinGameObject.SetActive(true);
                    return;
                }
                   

                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "IA Win";
                    return;
                }
            }
        }

        // Vertical
       
        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 1*i].Type == Cases[3 + 1 * i].Type && Cases[0 + i * i].Type == Cases[6 + i * i].Type)
            {
                if (Cases[0 + 1 * i].Type == Case.CaseType.Player)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "Player Win";
                    WinGameObject.SetActive(true);
                    return;
                }


                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "IA Win";
                    WinGameObject.SetActive(true);
                    return;
                }
            }
        }

        // Diagonal
        if (Cases[0].Type == Cases[4].Type && Cases[0].Type == Cases[8].Type)
        {

            if (Cases[0].Type == Case.CaseType.Player)
            {
                turnState = TurnState.EndMatch;
                winText.text = "Player Win";
                WinGameObject.SetActive(true);
                return;
            }


            if (Cases[0].Type == Case.CaseType.IA)
            {
                turnState = TurnState.EndMatch;
                winText.text = "IA Win";
                WinGameObject.SetActive(true);
                return;
            }
        }
        if (Cases[2].Type == Cases[4].Type && Cases[0].Type == Cases[6].Type)
        {
            if (Cases[0].Type == Case.CaseType.Free)
                return;

            if (Cases[0].Type == Case.CaseType.Player)
            {
                turnState = TurnState.EndMatch;
                winText.text = "Player Win";
                WinGameObject.SetActive(true);
                return;
            }


            if (Cases[0].Type == Case.CaseType.IA)
            {
                turnState = TurnState.EndMatch;
                winText.text = "IA Win";
                WinGameObject.SetActive(true);
                return;
            }
        }

    }
    
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int CheckIAWin()
    {
        if (EmptyCases.Count == 0)
        {
            return EndGameResult(0);
        }
        // Horizontal
        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 3 * i].Type == Cases[1 + 3 * i].Type && Cases[0 + 3 * i].Type == Cases[2 + 3 * i].Type)
            {
                if (Cases[0 + 3 * i].Type == Case.CaseType.Player)
                {
                    return EndGameResult(2);
                }


                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    return EndGameResult(1);
                }
            }
        }

        // Vertical
        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 1 * i].Type == Cases[3 + 1 * i].Type && Cases[0 + i * i].Type == Cases[6 + i * i].Type)
            {
                if (Cases[0 + 1 * i].Type == Case.CaseType.Player)
                {
                    return EndGameResult(2);
                }


                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    return EndGameResult(1);
                }
            }
        }

        // Diagonal
        if (Cases[0].Type == Cases[4].Type && Cases[0].Type == Cases[8].Type)
        {

            if (Cases[0].Type == Case.CaseType.Player)
            {
                return EndGameResult(2);
            }


            if (Cases[0].Type == Case.CaseType.IA)
            {
                return EndGameResult(1);
            }
        }
        if (Cases[2].Type == Cases[4].Type && Cases[0].Type == Cases[6].Type)
        {
            if (Cases[0].Type == Case.CaseType.Player)
            {
                return EndGameResult(2);
            }


            if (Cases[0].Type == Case.CaseType.IA)
            {
                return EndGameResult(1);
            }
        }

        return EndGameResult(0);
    }

    public int EndGameResult(int i)
    {
        return i;
    }

}
