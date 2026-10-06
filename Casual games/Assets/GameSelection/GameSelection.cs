using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour
{
    public void Button_CarrotCollector() => LoadSceneMode(1);
    public void Button_ThreeDDodger()    => LoadSceneMode(2);
    public void Button_BalloonPopper()   => LoadSceneMode(3);
    public void Button_BlockDodger() => LoadSceneMode(4);
    public void Button_MazeBall() => LoadSceneMode(5);

    private void LoadSceneMode(int SceneBuildIndex) => SceneManager.LoadScene(SceneBuildIndex);

}
