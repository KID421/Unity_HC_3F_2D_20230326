using UnityEngine;                  // �ޥ� Unity �����禡�w
using UnityEngine.SceneManagement;

// �}���W�١G�����򥪤W�����ɮצW�٤@�ˡA�]�t�j�p�g�A���঳�Ů�
public class MenuManager : MonoBehaviour
{
    // �}���{�����e
    public void StartGame()
    {
        SceneManager.LoadScene("�C������");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
