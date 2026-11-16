using UnityEngine;

namespace MazeBall
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject winText, loseText;
        [SerializeField] private GameManager gameManager;
        

        void OnEnable()
        {
            gameManager.OnWinGame  += ActiveWinPanel;
            gameManager.OnLoseGame += ActiveLosePanel;
        }
        void OnDisable()
        {
            gameManager.OnWinGame  -= ActiveWinPanel;
            gameManager.OnLoseGame -= ActiveLosePanel;
        }

        private void ActiveWinPanel() => winText.SetActive(true);
        private void ActiveLosePanel() => loseText.SetActive(true);
        
    }
}