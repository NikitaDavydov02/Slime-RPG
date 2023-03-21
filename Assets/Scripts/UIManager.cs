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
    private Slider playerHPSlider;
    // Start is called before the first frame update
    void Start()
    {
        MainManager.EnemyIsKilled += EnemyIsKilled;
        playerHPSlider = Instantiate(PlayerHPSliderPrefab) as Slider;
        playerHPSlider.GetComponent<RectTransform>().SetParent(canvas.transform);
        playerHPSlider.transform.position = Camera.main.WorldToScreenPoint(MainManager.EnemyAndPlayerManager.Player.gameObject.transform.position);

        playerHPSlider.maxValue = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().MaxHP;
        playerHPSlider.value = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().HP;
        
        //MainManager.EnemyIsSpawned += EnemyIsSpawned;
    }

    // Update is called once per frame
    void Update()
    {
        CoinsText.text = MainManager.GameProgressManager.CurrentCoints.ToString();
        foreach(Slider slider in enemySliders.Keys)
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(enemySliders[slider].gameObject.transform.position);
            slider.value = enemySliders[slider].HP;
            playerHPSlider.value = MainManager.EnemyAndPlayerManager.Player.gameObject.GetComponent<PlayerMovment>().HP;
        }
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
        Slider slider = Instantiate(HPSliderPrefab) as Slider;
        slider.GetComponent<RectTransform>().SetParent(canvas.transform);
        slider.transform.position = Camera.main.WorldToScreenPoint(enemy.gameObject.transform.position);
        enemySliders.Add(slider,enemy);
        slider.maxValue = enemy.MaxHP;
        slider.value = enemy.HP;
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
    }
    public void PlayerIsHited(int value)
    {
        Text text = Instantiate(TextPrefab) as Text;
        text.gameObject.GetComponent<RectTransform>().SetParent(canvas.transform);
        text.gameObject.transform.position = Camera.main.WorldToScreenPoint(MainManager.EnemyAndPlayerManager.Player.gameObject.transform.position);
        text.text = "-" + value.ToString();
    }
}
