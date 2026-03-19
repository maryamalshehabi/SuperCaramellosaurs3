using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce = 10f;
    [SerializeField]
    private float _rotationMultiplier = 0.5f;
    [SerializeField]
    private GameObject _menu;

    [SerializeField] 
    private GameObject _gameOverImage;

    [SerializeField] private GameObject _playButton;

    private Rigidbody2D _rigidbody;
    private int _score = 0;

    public int Score 
    {
        get
        {
            return _score;
        }
    }

    public bool IsAlive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();  
        gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _rigidbody.linearVelocityY = _jumpForce;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, _rigidbody.linearVelocity.y * _rotationMultiplier);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);
        _gameOverImage.SetActive(true);
        _playButton.SetActive(false);
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score += 1;
    }
}
