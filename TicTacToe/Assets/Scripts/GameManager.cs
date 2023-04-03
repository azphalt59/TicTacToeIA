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
        
        if(turnState == TurnState.IaTurn)
        {
            turnState = TurnState.PlayerTurn;
            //turnState = TurnState.PlayerTurn;
            Debug.Log("IA PLAY");
            Ia.IaPlay();
        }

    }
    public void SimulateTurn(int index, Case.CaseType type)
    {
        Cases[index].Type = type; 
    }
    public void CancelTurn(int index)
    {
        Cases[index].Type = Case.CaseType.Free;
    }
    public int CheckWin()
    {
       
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
                    return -1;
                }
                   

                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "IA Win";
                    return 1;
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
                    return -1;
                }


                if (Cases[0 + 3 * i].Type == Case.CaseType.IA)
                {
                    turnState = TurnState.EndMatch;
                    winText.text = "IA Win";
                    WinGameObject.SetActive(true);
                    return 1;
                }
            }
        }

        // Diagonals
        if (Cases[0].Type == Cases[4].Type && Cases[0].Type == Cases[8].Type)
        {

            if (Cases[0].Type == Case.CaseType.Player)
            {
                turnState = TurnState.EndMatch;
                winText.text = "Player Win";
                WinGameObject.SetActive(true);
                return -1;
            }


            if (Cases[0].Type == Case.CaseType.IA)
            {
                turnState = TurnState.EndMatch;
                winText.text = "IA Win";
                WinGameObject.SetActive(true);
                return 1;
            }
        }
        if (Cases[2].Type == Cases[4].Type && Cases[2].Type == Cases[6].Type)
        {
           
            if (Cases[2].Type == Case.CaseType.Player)
            {
                turnState = TurnState.EndMatch;
                winText.text = "Player Win";
                WinGameObject.SetActive(true);
                return -1;
            }


            if (Cases[2].Type == Case.CaseType.IA)
            {
                turnState = TurnState.EndMatch;
                winText.text = "IA Win";
                WinGameObject.SetActive(true);
                return 1;
            }
        }
        if (EmptyCases.Count == 0)
        {
            turnState = TurnState.EndMatch;
            winText.text = "Draw";
            WinGameObject.SetActive(true);
            return 0;
        }
        return 0;
    }
    public bool CheckWin(Case.CaseType type)
    {
        // Horizontal
        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 3 * i].Type == type &&  Cases[1 + 3 * i].Type == type && Cases[2 + 3 * i].Type == type)
            {
                return true;
            }
        }

        // Vertical

        for (int i = 0; i < 2; i++)
        {
            if (Cases[0 + 1 * i].Type == type && Cases[3 + 1 * i].Type == type && Cases[0 + i * i].Type == type)
            { 
                return true;
            }
        }

        // Diagonals
        if (Cases[0].Type == type && Cases[4].Type == type && Cases[8].Type == type)
        {
            return true;
        }
        if (Cases[2].Type == type && Cases[4].Type == type && Cases[6].Type == type)
        {
            return true;
        }

        return false;
    }
    public bool CheckDraw()
    {
        for (int i = 0; i < 9; i++)
        {
            if(Cases[i].Type == Case.CaseType.Free)
            {
                return false;
            }
        }
        return true;
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
