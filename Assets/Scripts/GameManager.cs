using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;
        public static int deathCounter = 0; 
        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text deathText; 

        private static List<GameObject> deathSprites = new List<GameObject>();

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();

            foreach (var deathSprite in deathSprites)
            {
                if (deathSprite != null)
                {
                    deathSprite.SetActive(true);
                }
            }

            deathText.text = deathCounter.ToString();
        }

        void Update()
        {

            deathText.text = deathCounter.ToString();

            if (player.deathState == true)
            {
                deathCounter++;

                if (!IsDeathSpriteAtPosition(playerGameObject.transform.position))
                {
                    playerGameObject.SetActive(false);

                    GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                    deathPlayer.transform.localScale = playerGameObject.transform.localScale;

                    DontDestroyOnLoad(deathPlayer);
                    deathSprites.Add(deathPlayer);
                }

                player.deathState = false;
                Invoke("ReloadLevel", 3);
            }
        }

        private bool IsDeathSpriteAtPosition(Vector3 position)
        {
            foreach (var deathSprite in deathSprites)
            {
                if (deathSprite != null && deathSprite.transform.position == position)
                {
                    return true; 
                }
            }
            return false;
        }

        private void ReloadLevel()
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
