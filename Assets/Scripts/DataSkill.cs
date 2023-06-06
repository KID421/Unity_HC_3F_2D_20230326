using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Skill")]
public class DataSkill : ScriptableObject
{
    public int lv = 1;
    public string _name;
    public string description;
    public Sprite picture;
    public float[] values;

    private void OnDisable()
    {
        lv = 1;
    }
}
