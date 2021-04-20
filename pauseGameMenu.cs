using UnityEngine.Audio; 
using UnityEngine;

namespace BNG
{ 
    public class pauseGameMenu : MonoBehaviour
    {

        public bool gamePaused;
        public GameObject CANVAS_pause; 
        public GameObject pauseMenuUI;
        public GameObject controllersUI;
        public GameObject gameOptionsUI;
        //public TextMeshPro SHOWIT;
        public AudioSource click;

       
       

        // Start is called before the first frame update
        void Start()
        {   
            //inputB = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<InputBridge>(); 
            gamePaused = false;
            CANVAS_pause.SetActive(false);
            pauseMenuUI.SetActive(true);
            controllersUI.SetActive(false);
            gameOptionsUI.SetActive(false);
            //pauseGame();
        }

        // Update is called once per frame
        void Update()
        {
            
            var sup = InputBridge.Instance.StartButtonDown;
            var dis = InputBridge.Instance.LeftTriggerDown;
            var sud = InputBridge.Instance.BackButtonDown; 

             if(sup.ToString() == "True" && gamePaused == false)
             {
                 pauseGame(); 
             }

            if (sud.ToString() == "True" && gamePaused == false)
            {
                pauseGame();
            }

            //SHOWIT.SetText(sup.ToString()+dis.ToString()+sud.ToString()); 
            
        }

        public void pauseGame()
        {
            //showme.SetText("Paused"); 
            Time.timeScale = 0.25f;
            CANVAS_pause.SetActive(true); 
            pauseMenuUI.SetActive(true);
            gamePaused = true;
            //CANVAS_pause.transform.position = appearHere.transform.position;
            ///resumeGame(); 
            
        }

        public void resumeGame()
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            gamePaused = false;
            Debug.Log("RESUMED");
        }

        public void QuitGame()
        {
            PlayerPrefs.Save();
            Application.Quit();
        }

        public void openOptions()
        {
            pauseMenuUI.SetActive(false);
            controllersUI.SetActive(false);
            gameOptionsUI.SetActive(true);
        }

        public void openControlls()
        {
            pauseMenuUI.SetActive(false);
            controllersUI.SetActive(true);
            gameOptionsUI.SetActive(false);
        }

        public void openPauseMenuMain()
        {
            pauseMenuUI.SetActive(true);
            controllersUI.SetActive(false);
            gameOptionsUI.SetActive(false);
        }

        public void clickSound()
        {
            click.Play(); 
        }

    }
}