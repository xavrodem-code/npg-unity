
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Leguar.TotalJSON;

public class Fight : MonoBehaviour
{
    private Card _opponent;

    [SerializeField]
    private GameObject _win;

    [SerializeField]
    private GameObject _lose;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadOpp());
    }

    public void startFightStrength(int points)
    {
        if (_opponent.Strength >= points)
        {
            StartCoroutine(LoseBattle());
        } else
        {
            StartCoroutine(WinBattle());
        }
    }

    public void startFightSkills(int points)
    {
        if (_opponent.Skills >= points)
        {
            StartCoroutine(LoseBattle());
        }
        else
        {
            StartCoroutine(WinBattle());
        }
    }

    public void startFightSpeed(int points)
    {
        if (_opponent.Speed >= points)
        {
            StartCoroutine(LoseBattle());
        }
        else
        {
            StartCoroutine(WinBattle());
        }
    }

    public void startFightStamina(int points)
    {
        if (_opponent.Stamina >= points)
        {
            StartCoroutine(LoseBattle());
        }
        else
        {
            StartCoroutine(WinBattle());
        }
    }

    public void startFightSexiness(int points)
    {
        if (_opponent.Sexiness >= points)
        {
            StartCoroutine(LoseBattle());
        }
        else
        {
            StartCoroutine(WinBattle());
        }
    }

    public void startFightStealth(int points)
    {
        if (_opponent.Stealth >= points)
        {
            StartCoroutine(LoseBattle());
        }
        else
        {
            StartCoroutine(WinBattle());
        }
    }
    private IEnumerator loadOpp()
    {
        UnityWebRequest cardDetails = UnityWebRequest.Get("http://localhost:9090/cards/"+2);
        yield return cardDetails.SendWebRequest();
        if (cardDetails.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(cardDetails.error);
        }
        else
        {
            JSON json = JSON.ParseString(cardDetails.downloadHandler.text);
            Card oppCard = json.Deserialize<Card>();
            _opponent = oppCard;
        }
    }

    private IEnumerator WinBattle()
    {
        yield return new WaitForSeconds(3);
        _win.SetActive(true);
    }

    private IEnumerator LoseBattle()
    {
        yield return new WaitForSeconds(3);
        _lose.SetActive(true);
    }

    public class Card
    {
        public string ID;
        public int Strength;
        public int Speed;
        public int Skills;
        public int Stamina;
        public int Stealth;
        public int Sexiness;
    }
}
