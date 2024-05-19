using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(Animator))]
public class PlayerController3 : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 150f;
    private Rigidbody playerRb;
    private bool _isOnGround;
    private bool _isGameOver;
    private Animator _playerAnim;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _dirtParticle;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    public AudioSource f1234;
    private AudioSource _playerAudio;
    public bool GameOver
    {
        get => _isGameOver;
        set => _isGameOver = value;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        print(_isGameOver);
        
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && !_isOnGround && !_isGameOver)
        {
            playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = true;
            _playerAnim.SetTrigger("Jump_trig");
            _playerAudio.PlayOneShot(_jumpSound, 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        _isOnGround = false;
        _dirtParticle.Play();

        if (other.gameObject.GetComponent<MoveLeft>())
        {
            GameOver = true;
            print($"{nameof(GameOver)}, is {GameOver}");
            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);
            _explosionParticle.Play();
            _dirtParticle.Stop();
            _playerAudio.PlayOneShot(_crashSound, 1);
        }
    }
    
}
