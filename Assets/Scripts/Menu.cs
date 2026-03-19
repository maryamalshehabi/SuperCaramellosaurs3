using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Vector3 _playerStartPosition = Vector3.zero;
    [SerializeField]
    private GameObject _menuUI;
    [SerializeField]
    private TextMeshProUGUI _scoreText, _bestScoreText;

    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _gameOverImage;
    private PlayerController _playerController;
    private int _bestScore = 0;

    private void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        _gameOverImage.SetActive(false);
        _playButton.SetActive(true);
    }

    private void Update() 
    {
        _scoreText.text = _playerController.Score.ToString();

        if (_playerController.Score > _bestScore)
        {
            _bestScore = _playerController.Score;
            _bestScoreText.text = _bestScore.ToString();
        }
    }

    public void OnStartPressed() 
    {
        _player.SetActive(false);
        _player.transform.position = _playerStartPosition;

        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        _player.SetActive(true);
        _menuUI.SetActive(false);
        _gameOverImage.SetActive(false);
        _playButton.SetActive(true);
    }

    public void OnGameOverClicked()
    {
        _gameOverImage.SetActive(false);
        _playButton.SetActive(true);
    }

    public void OnRestartPressed()
    {
        _playerController.gameObject.SetActive(false);
        _playerController.gameObject.transform.position = _playerStartPosition;
        
        _playerController.gameObject.SetActive(true);
    }

}
