using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header ("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    [Header("Text Mesh")]
    public TextMeshPro uiTextPowerup;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "End Line";
    public bool invencible = false;

    [Header("Coin Setup")] 
    public GameObject coinCollector;

    public GameObject endScreen;

    //Privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.position; ResetSpeed(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        { 
            if(!invencible) EndGame(); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        { 
            if (!invencible) EndGame(); 
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void startToRun()
    {
        _canRun = true;
    }
    #region Power Ups


    public void SetPowerupText(string s) 
    {
        uiTextPowerup.text = s; 
    }

    public void PowerUpSpeedUp(float f) 
    {
        _currentSpeed = f; 
    }
    public void ResetSpeed() 
    {
        _currentSpeed = speed; 
    }

    public void SetInvencible(bool b = true)
    { 
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        //.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }
    public void ChangeCoinCollectorSize(float amount) 
    {
        coinCollector.transform.localScale = Vector3.one * amount; 
    }

    public void ResetHeight(float animationDuration) 
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }
    #endregion
}
