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

    private PlayerController _playerController;
    private int _bestScore = 0;

    private void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
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
        _player.SetActive(true);
        _player.transform.position = _playerStartPosition;
        _menuUI.SetActive(false);
    }

}
