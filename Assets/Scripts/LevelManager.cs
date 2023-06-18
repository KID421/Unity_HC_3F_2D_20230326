using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("升級面板")]
    public GameObject goLevelUp;
    [Header("技能選取區塊 1 ~ 3")]
    public GameObject[] goChooseSkills;

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
            LevelUp();
        }

        textExp.text = $"{exp} / {expNeeds[lv - 1]}";
        imgExp.fillAmount = exp / expNeeds[lv - 1];
    }

    private void LevelUp()
    {
        goLevelUp.SetActive(true);
    }
}
