using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelHandler : MonoBehaviour
{
    [Header("Buttons")]
    public int _id;
    [SerializeField] private Sprite[] _dataButtonsSprite;
    [SerializeField] private Image _currentButtonsSprite;

    [Header("Stars"), Space(10)]
    private bool _canDisplayStars = false;
    [SerializeField] private Sprite[] _dataStarsSprite;
    [SerializeField] private Image _currentStarsSprite;
    

    void Start()
    {
        if(_currentButtonsSprite == null) _currentButtonsSprite = GetComponent<Image>();
        if(_currentStarsSprite == null) _currentStarsSprite = transform.GetChild(0).GetComponent<Image>();
    }

    void OnEnable()
    {
        CheckButtonsSprite(_id);
        Checkstars(_id);
    }

    private void CheckButtonsSprite(int thisId)
    {
        if(_id > 2 ) _currentButtonsSprite.sprite = _dataButtonsSprite[3];
        if (DataBase.GetCurrentProgres("Level") < 1 || DataBase.GetCurrentProgres("Level") == 1)
        {
            _currentButtonsSprite.sprite = _dataButtonsSprite[0];
            _canDisplayStars = true;
            return;
        }
        _currentButtonsSprite.sprite = _dataButtonsSprite[thisId];
        _canDisplayStars = true;
    }

    private void Checkstars(int id)
    {
        if(!_canDisplayStars) 
        {
            _currentStarsSprite.gameObject.SetActive(false);
            return;
        }
        _currentStarsSprite.gameObject.SetActive(true);
        _currentStarsSprite.sprite = _dataStarsSprite[DataBase.GetStars(id)];
        print($"Check Stars {id}");
    }
}
