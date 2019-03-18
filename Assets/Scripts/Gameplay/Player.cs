using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private BooleanVariable _isPlayerDead;
    [SerializeField] private BooleanVariable _isPlayerActive;
    [SerializeField] private InGameEvent _enableCanvas;
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private AudioEvent _jumpAudioEvent;
    [SerializeField] private AudioEvent _deathAudioEvent;
    [SerializeField] private AudioSource _audioSource;

    private bool _hasJumped = false;

    private int _jumpHash = Animator.StringToHash("hasJumped");
    private int _deadHash = Animator.StringToHash("isDead");

    void Awake()
    {
        _rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isPlayerDead.value)
        {
            if(Input.GetMouseButtonDown(0))
            {
                _rb.simulated = true;
                _isPlayerActive.value = true;
                _anim.SetTrigger(_jumpHash);
                _hasJumped = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(_hasJumped)
        {
            _hasJumped = false;
            _jumpAudioEvent.Play(_audioSource);
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovingObject _movingObject = collision.gameObject.GetComponentInParent<MovingObject>();
        
        if(_movingObject)
        {
            _deathAudioEvent.Play(_audioSource);
            _anim.SetTrigger(_deadHash);
            _rb.simulated = false;
            _isPlayerDead.value = true;
        }
    }

    public void GameOver()
    {
        _enableCanvas.Raise();
    }

}