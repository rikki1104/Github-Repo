using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maze_Game.UI;
using Maze_Game.Saving;
using UnityStandardAssets.CrossPlatformInput;

namespace Maze_Game.Core
{
        public class GreenLock : MonoBehaviour
    {
        [SerializeField] GameObject _showUI;
        [SerializeField] AudioSource _openAudio;
        [SerializeField] Animator _anim;
        
        public bool isOpen;

        void Start()
        {
            if(SaveManager.instance.hasLoaded)
            {
               isOpen = SaveManager.instance.activeSave.greenDoorOpen;
            }

            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            this.gameObject.SetActive(!isOpen);
        }

        void OnTriggerStay(Collider other)
        {
            if(other.tag == "Player")
            {
                if(CrossPlatformInputManager.GetButton("Fire1") || Input.GetKeyDown(KeyCode.E) && SaveManager.instance.activeSave._greenKeyData)
                {
                    Player player = other.GetComponent<Player>();
                        if(player !=null)
                        {
                            _openAudio.Play();
                            _anim.Play("LockAnim");
                            StartCoroutine(OpenGreenLockAnim());
                        } 
                }
                            
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && SaveManager.instance.activeSave._greenKeyData)
            {
                _showUI.SetActive(true);              
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                _showUI.SetActive(false);              
            }
        }              

        IEnumerator OpenGreenLockAnim()
        {
            yield return new WaitForSeconds(1.2f);
            isOpen = !isOpen;
                if(isOpen)
                {                       
                    UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();  
                    if(_uiManager != null)
                    {
                        
                        _showUI.SetActive(false);
                    }                                                                                                    
                    SaveManager.instance.Save();                                     
                    this.gameObject.SetActive(!isOpen);
                    SaveManager.instance.activeSave.greenDoorOpen = isOpen; 
                }                                                      
        }          
    }
}
