using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MaterialGenerator : MonoBehaviour
{
    public int colorSelect, countMaterials;
    public int colorSaturation;

    private string pathMaterialFolder = "";
    public string actualLevel = "";

    private List<GameObject> gameObjects = new List<GameObject>();

    Material material;

    public TMP_Text textLevel;

    public static MaterialGenerator Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pathMaterialFolder = Application.dataPath + "/Resources/Generates";

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Terrain"))
        {
            gameObjects.Add(go);
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Wall"))
        {
            gameObjects.Add(go);
        }

        if (SceneManager.GetActiveScene().name.Contains("Puzzle0") || ((GameManager.Instance.isPuzzleCompleted || GameManager.Instance.noMorePuzzles) && SceneManager.GetActiveScene().name.Contains("Active")))
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathMaterialFolder);
            countMaterials = dir.GetFiles().Length;

            material = Resources.Load<Material>("Generates/Entorno");
        }
        else
        {
            GenerateNewColor();
        }

        ApplyMaterialToTheScenery();
    }

    // Update is called once per frame
    void Update()
    {
        if(actualLevel != "")
        {
            GameManager.Instance.levelName = actualLevel;
        }

        if(textLevel != null)
        {
            textLevel.text = GameManager.Instance.levelName;
        }
    }

    public void GenerateNewMaterial()
    {
        material = Resources.Load<Material>("Generates/Entorno");

        colorSelect = UnityEngine.Random.Range(0, 10);
        colorSaturation = UnityEngine.Random.Range(1, 10);

        actualLevel += colorSaturation;

        switch (colorSelect)
        {
            case 0:
                material.color = new Color(255f / (25.5f * colorSaturation), 0, 0, 1);
                actualLevel += "R";
                break;
            case 1:
                material.color = new Color(255f / (25.5f * colorSaturation), 165f / (25.5f * colorSaturation), 0, 1);
                actualLevel += "YR";
                break;
            case 2:
                material.color = new Color(255f / (25.5f * colorSaturation), 234.6f / (25.5f * colorSaturation), 4.08f / (25.5f * colorSaturation), 1);
                actualLevel += "Y";
                break;
            case 3:
                material.color = new Color(173f / (25.5f * colorSaturation), 255f / (25.5f * colorSaturation), 47f / (25.5f * colorSaturation), 1);
                actualLevel += "GY";
                break;
            case 4:
                material.color = new Color(0, 255f / (25.5f * colorSaturation), 0, 1);
                actualLevel += "G";
                break;
            case 5:
                material.color = new Color(13f / (25.5f * colorSaturation), 152f / (25.5f * colorSaturation), 186f / (25.5f * colorSaturation), 1);
                actualLevel += "BG";
                break;
            case 6:
                material.color = new Color(0, 0, 255f / (25.5f * colorSaturation), 1);
                actualLevel += "B";
                break;
            case 7:
                material.color = new Color(138f / (25.5f * colorSaturation), 43f / (25.5f * colorSaturation), 226f / (25.5f * colorSaturation), 1);
                actualLevel += "PB";
                break;
            case 8:
                material.color = new Color(162f / (25.5f * colorSaturation), 32f / (25.5f * colorSaturation), 240f / (25.5f * colorSaturation), 1);
                actualLevel += "P";
                break;
            case 9:
                material.color = new Color(149f / (25.5f * colorSaturation), 53f / (25.5f * colorSaturation), 83f / (25.5f * colorSaturation), 1);
                actualLevel += "RP";
                break;

        }
    }

    public void GenerateNewColor()
    {
        GenerateNewMaterial();

        //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathMaterialFolder);
        //int countMaterials = dir.GetFiles().Length;
        //if (countMaterials != 0 ) { countMaterials /= 2; }

        //AssetDatabase.CreateAsset(material, "Assets/Resources/Generates/Material" + countMaterials +".mat");
    }

    public void ApplyMaterialToTheScenery()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.GetComponent<Renderer>().material = material;
        }
    }
}
