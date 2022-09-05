using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Leguar.TotalJSON;


public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _card;
   
    [SerializeField]
    private Fight fightSystem;

    public Button strength;
    public Button speed;
    public Button skill;
    public Button stamina;
    public Button stealth;
    public Button sexiness;
    int buttonsPressed = 0;
    private bool _onMove = false;


    public class Card {
        public string ID;
        public int Strength;
        public int Speed;
        public int Skills;
        public int Stamina;
        public int Stealth;
        public int Sexiness;
    }

    public static Card _playerCard;

    private int playerStrength;
    private int playerSpeed;
    private int playerSkills;
    private int playerStamina;
    private int playerStealth;
    private int playerSexiness;
    void Awake()
    {
        Debug.Log("Starting");
        fightSystem = GameObject.FindGameObjectWithTag("fight").GetComponent<Fight>();
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        UnityWebRequest cardDetails = UnityWebRequest.Get("http://localhost:9090/cards/"+1);
        yield return cardDetails.SendWebRequest();
        if (cardDetails.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(cardDetails.error);
        } else
        {
            Debug.Log(cardDetails.downloadHandler.text);
            JSON json = JSON.ParseString(cardDetails.downloadHandler.text);
            Card playerCard = json.Deserialize<Card>();
            _playerCard = playerCard;
        }
    }

    void Update()
    {
        if (_onMove == true)
        {
            StartCoroutine(StartMoving());
        }
    }

    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(2);
        _card.transform.Translate(0, 0.09f, 0);
    }
    
    public void DisableStrength()
    {
        strength.interactable = false;
        strength.gameObject.SetActive(false);
        playerStrength = _playerCard.Strength;
        fightSystem.startFightStrength(playerStrength);
    }

    public void DisableSpeed()
    {
        speed.interactable = false;
        speed.gameObject.SetActive(false);
        playerSpeed = _playerCard.Speed;
        fightSystem.startFightSpeed(playerSpeed);
    }

    public void DisableSkill()
    {
        skill.interactable = false;
        skill.gameObject.SetActive(false);
        playerSkills = _playerCard.Skills;
        fightSystem.startFightSkills(playerSkills);
    }

    public void DisableStamina()
    {
        stamina.interactable = false;
        stamina.gameObject.SetActive(false);
        playerStamina = _playerCard.Stamina;
        fightSystem.startFightStamina(playerStamina);
    }

    public void DisableStealth()
    {
        stealth.interactable = false;
        stealth.gameObject.SetActive(false);
        playerStealth = _playerCard.Stealth;
        fightSystem.startFightStealth(playerStealth);
    }

    public void DisableSexiness()
    {
        sexiness.interactable = false;
        sexiness.gameObject.SetActive(false);
        playerSexiness = _playerCard.Sexiness;
        fightSystem.startFightSexiness(playerSexiness);
    }

    public void AddCount()
    {
        buttonsPressed += 1;
        if (buttonsPressed >= 1)
        {
            strength.interactable = false;
            strength.gameObject.SetActive(false);
            speed.interactable = false;
            speed.gameObject.SetActive(false);
            skill.interactable = false;
            skill.gameObject.SetActive(false);
            stamina.interactable = false;
            stamina.gameObject.SetActive(false);
            stealth.interactable = false;
            stealth.gameObject.SetActive(false);
            sexiness.interactable = false;
            sexiness.gameObject.SetActive(false);
            _onMove = true;
        }
    }
}
