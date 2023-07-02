using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    #region 資料
    [Header("等級與經驗值介面")]
    public TextMeshProUGUI textLv;
    public TextMeshProUGUI textExp;
    public Image imgExp;
    [Header("等級上限"), Range(0, 500)]
    public int lvMax = 100;

    private int lv = 1;
    private float exp;

    public float[] expNeeds = { 100, 200, 300 };

    [Header("升級面板")]
    public GameObject goLevelUp;
    [Header("技能選取區塊 1 ~ 3")]
    public GameObject[] goChooseSkills;
    [Header("全部技能")]
    public DataSkill[] dataSkills;

    public List<DataSkill> randomSkill = new List<DataSkill>();
    #endregion

    #region 經驗值系統
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
        // print($"<color=yellow>當前經驗值：{ exp }</color>");

        // 如果 經驗值 >= 當前等級需求 並且 等級 < 等級上限 就 升級
        if (exp >= expNeeds[lv - 1] && lv < lvMax)
        {
            exp -= expNeeds[lv - 1];        // 計算多出來的經驗
            lv++;                           // 等級提升 (+1)
            textLv.text = $"Lv {lv}";       // 更新等級介面
            LevelUp();
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }

    private void LevelUp()
    {
        // 時間暫停
        Time.timeScale = 0;
        // 顯示升級面板
        goLevelUp.SetActive(true);

        // 技能必須小於 5
        randomSkill = dataSkills.Where(x => x.lv < 5).ToList();
        // 5 個技能隨機排序
        randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++)
        {
            goChooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
            goChooseSkills[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
            goChooseSkills[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "等級 Lv " + randomSkill[i].lv;

            goChooseSkills[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
        }
    }

    public void ClickSkillButton(int number)
    {
        print("玩家按下的技能是：" + randomSkill[number].nameSkill);

        // 該技能等級 +1
        randomSkill[number].lv++;
        // 按下的技能升級
        if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
        if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack(number);
        if (randomSkill[number].nameSkill == "武器間隔") UpdateWeaponInterval(number);
        if (randomSkill[number].nameSkill == "玩家血量") UpdatePlayerHealth(number);
        if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange(number);

        Time.timeScale = 1;
        goLevelUp.SetActive(false);
    } 
    #endregion

    #region 升級系統
    [Header("控制系統：犀牛")]
    public ControlSystem controlSystem;
    [Header("武器系統：犀牛")]
    public WeaponSystem weaponSystem;
    [Header("玩家血量：玩家犀牛")]
    public DataHealth dataHealth;
    [Header("經驗物件：香蕉經驗值")]
    public CircleCollider2D expBanana;
    [Header("武器：蜜蜂")]
    public Weapon weaponBee;

    private void Awake()
    {
        controlSystem.moveSpeed = dataSkills[3].skillValues[0];     // 移動速度在 DataSkills 的編號
        weaponBee.attack = dataSkills[0].skillValues[0];
        weaponSystem.interval = dataSkills[1].skillValues[0];
        dataHealth.hp = dataSkills[2].skillValues[0];
        expBanana.radius = dataSkills[4].skillValues[0];
    }

    public void UpdateMoveSpeed(int number)
    {
        int lv = randomSkill[number].lv;
        controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
    }

    public void UpdateWeaponAttack(int number)
    {
        int lv = randomSkill[number].lv;
        weaponBee.attack = randomSkill[number].skillValues[lv - 1];
    }

    public void UpdateWeaponInterval(int number)
    {
        int lv = randomSkill[number].lv;
        weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
    }

    public void UpdatePlayerHealth(int number)
    {
        int lv = randomSkill[number].lv;
        dataHealth.hp = randomSkill[number].skillValues[lv - 1];
    }

    public void UpdateExpRange(int number)
    {
        int lv = randomSkill[number].lv;
        expBanana.radius = randomSkill[number].skillValues[lv - 1];
    } 
    #endregion
}
