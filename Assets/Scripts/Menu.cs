using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _scoreBackground;
    [SerializeField] private GameObject _quitMenu;
    [SerializeField] private GameObject _winMessage;
    [SerializeField] private GameObject _difficultyMenu;
    [SerializeField] private AppDatas choice;
    [SerializeField] private GameObject _spawnWalls;
    [SerializeField] private GameObject _spawnTargets;
    [SerializeField] private GameObject _player;

    public void Play()
    {
        _difficultyMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SelectDifficulty(int choix)
    {
        choice.actualDifficulty = choice.difficultyList[choix];
        _menu.SetActive(false);
        _quitMenu.SetActive(true);
        _scoreBackground.SetActive(true);
        _player.SetActive(true);
        _spawnTargets.SetActive(true);
        _spawnWalls.SetActive(true);
    }
}