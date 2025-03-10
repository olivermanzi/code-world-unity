﻿using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// Handles behavior of the main menu, fetching of the repository and switching to the main scene.
/// </summary>

namespace Project
{
    public class MiddlewareInterface : MonoBehaviour {

        // The global variables are here as unity doesnt allow functions called in 
        // the UnityEngine to have more than one parameter
        Text project;
        Boolean GitLab = true;
        Boolean GitHub = false;
        public GameObject error;

        // Use this for initialization
        void Start () {
    
        }

        // A workaround function so I can have the text objects of both inputfields
        // since unity doesnt allow functions that are called from the engine to have 
        // more than one simple parameter (by unity standard)
        public void SetProj(Text name)
        {
            project = name;
            UnityEngine.Debug.Log("Middleware: SetProj run!");
        }

        //These are setter for the GitLab and GitHub variables
        public void SetGitLab(Toggle repo)
        {
            GitLab = repo.isOn;
        }

        public void SetGitHub(Toggle repo)
        {
            GitHub = repo.isOn;
        }
        
        // This functions checks and returns which of the Repo pages should be passed as a argument
        // Standard it will select GitLab
        public String checkRepo()
        {
            
            if(GitHub && !GitLab)
            {
                return "f";
            }else if(!GitHub && GitLab)
            {
                return "t";
            }
            else
            {
                return "t";
            }

       }




        // This function is the first chain in the process to get the neccesarry JSON to the computer
        public void GetJson (Text name) {
            UnityEngine.Debug.Log("Middleware: GetJson run!");
            // Defining some variables
            string NodePath = UnityEngine.Application.dataPath + "/Resources/Middleware/ConsoleApplication.exe";
            var User = name.text.ToString();
            var Repository = project.text.ToString();
            var Page = checkRepo();
            
            // Making a Proccess that will call on a file and also pass along arguments to that file.
            Process FirstNode = new Process();
            try
            {
                UnityEngine.Debug.Log("Middleware: Try Block entered!");
                // Declares where to find the .exe file
                FirstNode.StartInfo.FileName = NodePath;
                UnityEngine.Debug.Log(NodePath);
                // Declares the argument the .exe file will take 
                FirstNode.StartInfo.Arguments = User +" "+ Repository+" "+Page;
                FirstNode.Start();
                FirstNode.WaitForExit();
                if(File.Exists("Assets/Resources/Project.json"))
                {
                    SceneManager.LoadScene("Main", LoadSceneMode.Single);
                }
                else
                {
                    error.SetActive(true);
                    error.transform.Find("ErrorText").GetComponent<Text>().text = "Failed to fetch repository!";
                }
            }
            catch (Exception e)
            {
                //UnityEngine.Debug.Log(e.Message);
                error.SetActive(true);
                error.transform.Find("ErrorText").GetComponent<Text>().text = e.Message;
            }

        }

        // Update is called once per frame
        void Update () {
            
        }
    }
}