using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _coinsCount;
    [SerializeField] List<TextMeshProUGUI> _priceText = new List<TextMeshProUGUI>();
    [SerializeField] private GameObject _thatBodyColor;
    public BodyColor[] _bodyColor;
    [SerializeField] int _coins;
    [SerializeField] GameObject _emptyWall;
    [SerializeField] GameObject _wall;
    private void Start()
    {
        int count = 0;
        int color0 = PlayerPrefs.GetInt("color0");
        int color1 = PlayerPrefs.GetInt("color1");
        int color2 = PlayerPrefs.GetInt("color2");
        int color3 = PlayerPrefs.GetInt("color3");
        if (color0 == 0)
        {
            count = 0;
        }
        if (color1 == 1)
        {
            count = 1;
        }
        if (color2 == 2)
        {
            count = 2;
        }
        if (color3 == 3)
        {
            count = 3;
        }
        GetColor(count);
        //PlayerPrefs.SetInt("coins", 100);
        _coins = PlayerPrefs.GetInt("coins");
        _coinsCount.text = PlayerPrefs.GetInt("coins").ToString();
        for (var i = 0; i < _bodyColor.Length; i++)
        {
            _priceText[i].text = _bodyColor[i]._colorPrice.ToString();
        }
    }


    public void BuyColor(int count)
    {
        if (count > _bodyColor.Length)
        {
            return;
        }
        if (_bodyColor[count]._colorPrice <= _coins && _bodyColor[count].isBuy == false)
        {
            _priceText[count].text = "Owned";
            _bodyColor[count].isBuy = true;
            GetCoins(-_bodyColor[count]._colorPrice);
        }
        if (_bodyColor[count].isBuy == true)
        {

            //_thatBodyColor.SetActive(false);
            //_thatBodyColor = _bodyColor[count]._bodyColorToBuy;
            //_thatBodyColor.SetActive(true);
            
            switch (count)
            {
                case 0:
                    PlayerPrefs.SetInt("color0", 1);
                    PlayerPrefs.SetInt("color1", 0);
                    PlayerPrefs.SetInt("color2", 0);
                    PlayerPrefs.SetInt("color3", 0);
                    break;
                case 1:
                    PlayerPrefs.SetInt("color0", 0);
                    PlayerPrefs.SetInt("color1", 1);
                    PlayerPrefs.SetInt("color2", 0);
                    PlayerPrefs.SetInt("color3", 0);
                    break;
                case 2:
                    PlayerPrefs.SetInt("color0", 0);
                    PlayerPrefs.SetInt("color1", 0);
                    PlayerPrefs.SetInt("color2", 1);
                    PlayerPrefs.SetInt("color3", 0);
                    break;
                case 3:
                    PlayerPrefs.SetInt("color0", 0);
                    PlayerPrefs.SetInt("color1", 0);
                    PlayerPrefs.SetInt("color2", 0);
                    PlayerPrefs.SetInt("color3", 1);
                    break;
                default:
                    print("none");
                    break;
            }
            GetColor(count);

        }
        _coinsCount.text = PlayerPrefs.GetInt("coins").ToString();
        GetColor(count);
    }
    public void GetColor(int count)
    {
        _priceText[count].text = "Owned";
        _bodyColor[count].isBuy = true;
        _thatBodyColor.SetActive(false);
            _thatBodyColor = _bodyColor[count]._bodyColorToBuy;
            _thatBodyColor.SetActive(true);
        _coinsCount.text = PlayerPrefs.GetInt("coins").ToString();

    }
    //public void GetMoney(int count)
    //{
    //    PlayerPrefs.SetInt("coins", _coins + count);
    //    _coins = PlayerPrefs.GetInt("coins");
    //    _coinsCount.text = PlayerPrefs.GetInt("coins").ToString();
    //}
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("EmptyWall"))
    //    {
    //        _coins = PlayerPrefs.GetInt("coins");
    //        PlayerPrefs.SetInt("coins", _coins + 1);
    //        _coinsCount.text = (_coins + 1).ToString();
    //        Destroy(other.gameObject);
    //    }
    //    if (other.CompareTag("Wall"))
    //        {
    //            _coins = PlayerPrefs.GetInt("coins");
    //            PlayerPrefs.SetInt("coins", _coins - 5);
    //            _coinsCount.text = (_coins + 1).ToString();
    //            Destroy(other.gameObject);
    //        }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EmptyWall"))
        {
            Destroy(other.gameObject);
            _emptyWall.GetComponent<Bonus>().SetCoins();
        }
        if (other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
            _wall.GetComponent<Bonus>().SetCoins();
        }
    }
    public void GetCoins(int count)
    {
        _coins = PlayerPrefs.GetInt("coins");
        //_coins = _coins + count;
        PlayerPrefs.SetInt("coins", _coins + count);
        _coinsCount.text = PlayerPrefs.GetInt("coins").ToString();

        //_coins = PlayerPrefs.GetInt("coins");
        print(PlayerPrefs.GetInt("coins"));
        print(_coins);
    }

    [System.Serializable]
    public class BodyColor
    {
        public GameObject _bodyColorToBuy;
        public int _colorPrice;
        public bool isBuy;
    }
    
}
