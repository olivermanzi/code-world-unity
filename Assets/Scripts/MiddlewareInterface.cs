using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


namespace Project
{
    public class MiddlewareInterface : MonoBehaviour {

        // The global variables are here as unity doesnt allow functions called in 
        // the UnityEngine to have more than one parameter
        Text project;
        Boolean GitLab = true;
        Boolean GitHub = false;

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
        public void SetGitLab(Boolean repo)
        {
            GitLab = repo;
        }

        public void SetGitHub(Boolean repo)
        {
            GitHub = repo;
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
                if(File.Exists("/Resources/Project.json"))
                {
                    SceneManager.LoadScene("Main", LoadSceneMode.Single);
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", "Project not found", "OK");
                }
            }
            catch (Exception e)
            {
                //UnityEngine.Debug.Log(e.Message);
                EditorUtility.DisplayDialog("Error",
                e.Message, "OK");
            }

        }

        // Update is called once per frame
        void Update () {
            
        }
    }
}