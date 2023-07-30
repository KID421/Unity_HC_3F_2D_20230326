using UnityEngine;                  // 引用 Unity 引擎函式庫
using UnityEngine.SceneManagement;

// 腳本名稱：必須跟左上角的檔案名稱一樣，包含大小寫，不能有空格
public class MenuManager : MonoBehaviour
{
    // 腳本程式內容
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("遊戲場景");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
