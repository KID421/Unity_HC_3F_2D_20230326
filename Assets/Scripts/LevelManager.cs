using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("等級上限"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    public GameObject goLevelUp;
    public DataSkill[] dataSkills;

    public List<DataSkill> skill = new List<DataSkill>();

    public TextMeshProUGUI[] textTitleSkills;
    public TextMeshProUGUI[] textDescriptionSkills;
    public TextMeshProUGUI[] textLvSkills;
    public Image[] imgSkills;
    public Button[] btnSkills;

    [ContextMenu("更新經驗值需求表")]
    private void UpdateExpNeeds()
    {
        expNeeds = new float[lvMax];

        for (int i = 0; i < lvMax; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    /// <summary>
    /// 獲得經驗值
    /// </summary>
    /// <param name="getExp">取得的經驗值浮點數</param>
    public void GetExp(float getExp)
    {
        exp += getExp;
        print($"<color=yellow>當前經驗值：{ exp }</color>");

        // 如果 經驗值 >= 當前等級需求 並且 等級 < 等級上限 就 升級
        if (exp >= expNeeds[lv - 1] && lv < lvMax)
        {
            exp -= expNeeds[lv - 1];        // 計算多出來的經驗
            lv++;                           // 等級提升 (+1)
            textLv.text = $"Lv {lv}";       // 更新等級介面

            RandomSkill();
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }

    private void RandomSkill()
    {
        goLevelUp.SetActive(true);
        Time.timeScale = 0;

        skill.Clear();
        skill = dataSkills.Where(x => x.lv < 5).ToList();
        skill = skill.OrderBy(x => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++)
        {
            if (i >= skill.Count)
            {
                btnSkills[i].gameObject.SetActive(false);
                return;
            }

            textTitleSkills[i].text = skill[i]._name;
            textDescriptionSkills[i].text = skill[i].description;
            textLvSkills[i].text = $"等級 Lv{ skill[i].lv }";
        }
    }

    public void ClickButton(int index)
    {
        skill[index].lv++;
        goLevelUp.SetActive(false);
        Time.timeScale = 1;

        switch (skill[index]._name)
        {
            case "吸取經驗值範圍":
                UpdateExpRange();
                break;
            case "提升玩家血量":
                UpdatePlayerHP();
                break;
            case "移動速度提升":
                UpdatePlayerMoveSpeed();
                break;
            case "提升蜜蜂攻擊力":
                UpdateBeeAttack();
                break;
            case "提升蜜蜂生成間隔":
                UpdateBeeInterval();
                break;
        }
    }

    public CircleCollider2D colExp;
    public DataHealth dataPlayer;
    public ControlSystem controlSystem;
    public Weapon weaponBee;
    public WeaponSystem weaponSystem;

    private void Awake()
    {
        colExp.radius = dataSkills[0].values[0];
        controlSystem.moveSpeed = dataSkills[1].values[0];
        weaponBee.attack = dataSkills[2].values[0];
        weaponSystem.interval = dataSkills[3].values[0];
        dataPlayer.hp = dataSkills[4].values[0];
    }

    private void UpdateExpRange()
    {
        colExp.radius = dataSkills[0].values[dataSkills[0].lv - 1];
    }

    private void UpdatePlayerMoveSpeed()
    {
        controlSystem.moveSpeed = dataSkills[1].values[dataSkills[1].lv - 1];
    }

    private void UpdateBeeAttack()
    {
        weaponBee.attack = dataSkills[2].values[dataSkills[2].lv - 1];
    }

    private void UpdateBeeInterval()
    {
        weaponSystem.interval = dataSkills[3].values[dataSkills[3].lv - 1];
        weaponSystem.RestarSpawn();
    }

    private void UpdatePlayerHP()
    {
        dataPlayer.hp = dataSkills[4].values[dataSkills[4].lv - 1];
    }
}
