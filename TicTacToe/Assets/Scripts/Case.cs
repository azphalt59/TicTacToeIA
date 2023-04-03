using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public bool Used = false;
    public enum CaseType
    {
        Free, Player, IA
    }
    public CaseType Type;
    public int GridPos;
    private void Start()
    {
        GameManager.Instance.EmptyCases.Add(gameObject);
        
    }

    private void OnMouseDown()
    {
        
        if (GameManager.Instance.turnState == GameManager.TurnState.PlayerTurn && Used == false)
        {
            PlayerTake();
        }
    }
    public void PlayerTake()
    {
        GameManager.Instance.turnState = GameManager.TurnState.IaTurn;
        Used = true;
        GameManager.Instance.EmptyCases.Remove(gameObject);
        Type = CaseType.Player;
        Instantiate(GameManager.Instance.PlayerShape, transform.position, Quaternion.identity, transform);
        GameManager.Instance.CheckWin();
    }
    public void IaTake()
    {
        Used = true;
        GameManager.Instance.EmptyCases.Remove(gameObject);
        Type = CaseType.IA;
        Instantiate(GameManager.Instance.IaShape, transform.position, Quaternion.identity, transform);
        GameManager.Instance.CheckWin();
    }
}
