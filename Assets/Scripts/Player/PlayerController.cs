using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    [Header ("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "End Line";

    public GameObject endScreen;
    //Privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;

    private Vector3 _startPosition;

    private void Start() 
    { 
        _startPosition = transform.position; 
        ResetSpeed();
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
        if(collision.transform.tag == tagToCheckEnemy)
        {
            EndGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.transform.tag == tagToCheckEndLine)
        {
            EndGame();
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
    public void SetPowerUpText(string s) 
    {
        //uiTextPowerUp.text = s; 
    }
    public void PowerUpSpeedUp(float f) 
    {
        _currentSpeed = f; 
    }
    public void ResetSpeed() 
    {
        _currentSpeed = speed; 
    }
    #endregion
}
