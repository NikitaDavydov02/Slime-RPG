using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public Text CoinsText;
    [SerializeField]
    public Slider HPSliderPrefab;
    [SerializeField]
    public Slider PlayerHPSliderPrefab;
    [SerializeField]
    public Text TextPrefab;
    private Dictionary<Slider, Enemy> enemySliders = new Dictionary<Slider, Enemy>();
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    private RectTransform shop;
    [SerializeField]
    private Slider playerHPSlider;
    [SerializeField]
    private GameObject shopItemPanelPrefab;
    [SerializeField]
    private List<GameObject> shopItemPanelList;
    private Dictionary<GameObject, ShopItem> shopItemPanelDictionary;
    [SerializeField]
    private GameObject scrollContent;
    [SerializeField]
    public GameObject NewGameButton;
    // Start is called before the first frame update
    private void Awake()
    {
        //shopItemPanelList = new Dictionary<GameObject, ShopItem>();
    }
    void Start()
    {
        NewGameButton.SetActive(false);
        MainManager.EnemyIsKilled += EnemyIsKilled;
        //playerHPSlider = Instantiate(PlayerHPSliderPrefab) as Slider;
        playerHPSlider.GetComponent<RectTransform>().SetParent(canvas.transform);
        playerHPSlider.transform.position = Camera.main.WorldToScreenPoint(MainManager.EnemyAndPlayerManager.Player.gameObject.transform.position + new Vector3(0,1.5f,0));

        playerHPSlider.maxValue = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().MaxHP;
        playerHPSlider.value = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().HP;

        Debug.Log("ScreenHeight: " + Screen.height);
        float shopHeight = Screen.height / 3;
        float x = shop.rect.x;
        float y = shop.rect.y;
        float width = shop.rect.width;
        //shop.rect.Set(0, 0, Screen.width, shopHeight);
        //shop.rect.Set(x, y, width, shopHeight);
        //MainManager.EnemyIsSpawned += EnemyIsSpawned;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = MainManager.Shop.Balance.ToString();
        foreach(Slider slider in enemySliders.Keys)
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(enemySliders[slider].gameObject.transform.position+new Vector3(0,0.7f,0));
            
            slider.value = enemySliders[slider].HP;
            //playerHPSlider.value = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().HP;
        }
        playerHPSlider.value = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().HP;
    }
    public void EnemyIsKilled(object sender,EventArgs args)
    {
        //if (enemySliders.Count > 0)
        //    enemySliders.RemoveAt(enemySliders.Count - 1);
    }
    public void EnemyIsSpawned(object sender, EventArgs args, Vector3 pos)
    {
        //Slider slider = Instantiate(HPSliderPrefab) as Slider;
        //slider.GetComponent<RectTransform>().SetParent(canvas.transform);
        //slider.transform.position= Camera.main.WorldToScreenPoint(pos);
        //enemySliders.Add(slider);
    }
    public void EnemyIsSpawned(Enemy enemy)
    {
        Slider slider = Instantiate(CanvasScaler.Instantiate(playerHPSlider)) as Slider;
        slider.GetComponent<RectTransform>().SetParent(canvas.transform);
        slider.transform.position = Camera.main.WorldToScreenPoint(enemy.gameObject.transform.position);
        enemySliders.Add(slider,enemy);
        slider.maxValue = enemy.MaxHP;
        slider.value = enemy.HP;
        slider.GetComponent<RectTransform>().localScale = playerHPSlider.GetComponent<RectTransform>().localScale;
    }
    public void EnemyIsKilled(Enemy enemy)
    {
        Slider enemySlider = null;
       foreach(Slider slider in enemySliders.Keys)
            if (enemySliders[slider] == enemy)
            {
                enemySlider = slider;
                break;
            }
        if (enemySlider != null)
        {
            enemySliders.Remove(enemySlider);
            Destroy(enemySlider.gameObject);
        }
            
    }
    public void EnemyIsHited(Enemy enemy, int value)
    {
        Text text = Instantiate(TextPrefab) as Text;
        text.gameObject.GetComponent<RectTransform>().SetParent(canvas.transform);
        text.gameObject.transform.position = Camera.main.WorldToScreenPoint(enemy.gameObject.transform.position);
        text.text = "-" + value.ToString();
        text.GetComponent<RectTransform>().localScale = CoinsText.GetComponent<RectTransform>().localScale;

    }
    public void PlayerIsHited(int value)
    {
        Text text = Instantiate(TextPrefab) as Text;
        text.gameObject.GetComponent<RectTransform>().SetParent(canvas.transform);
        text.gameObject.transform.position = Camera.main.WorldToScreenPoint(MainManager.EnemyAndPlayerManager.Player.gameObject.transform.position);
        text.text = "-" + value.ToString();
        text.GetComponent<RectTransform>().localScale = CoinsText.GetComponent<RectTransform>().localScale;
    }
    public void GameOver()
    {
        NewGameButton.SetActive(true);
    }
    public void NewGame()
    {
        //NewGameButton.SetActive(false);
        //foreach (Slider slider in enemySliders.Keys)
        //{
        //    Destroy(slider.gameObject);
        //}
        //s
        Application.LoadLevel("SampleScene");
    }
}
