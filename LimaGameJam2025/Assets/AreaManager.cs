using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] private GameObject areaAWarn;
    [SerializeField] private GameObject areaAWarnText;
    [SerializeField] private GameObject areaBWarn;
    [SerializeField] private GameObject areaBWarnText;
    [SerializeField] private GameObject areaCWarn;
    [SerializeField] private GameObject areaCWarnText;
    [SerializeField] private float areaTimeA = 0f;
    [SerializeField] private float areaTimeB = 0f;
    [SerializeField] private float areaTimeC = 0f;

    private string activeWarning = ""; // Tracks which area's warning is active

    void Start()
    {
        ResetAll();
    }

    void Update()
    {
        // Check which area the player is currently in
        if (GameManager.instance.insideA)
        {
            ResetAreaTimers(exclude: "A");
        }
        else if (GameManager.instance.insideB)
        {
            ResetAreaTimers(exclude: "B");
        }
        else if (GameManager.instance.insideC)
        {
            ResetAreaTimers(exclude: "C");
        }

        // Only allow one warning to be active at a time
        if (activeWarning == "")
        {
            HandleArea("A", !GameManager.instance.insideA, ref areaTimeA, areaAWarn, areaAWarnText);
            HandleArea("B", !GameManager.instance.insideB, ref areaTimeB, areaBWarn, areaBWarnText);
            HandleArea("C", !GameManager.instance.insideC, ref areaTimeC, areaCWarn, areaCWarnText);
        }
        else
        {
            // Handle the currently active warning
            if (activeWarning == "A") HandleActiveArea(ref areaTimeA, areaAWarn, areaAWarnText);
            if (activeWarning == "B") HandleActiveArea(ref areaTimeB, areaBWarn, areaBWarnText);
            if (activeWarning == "C") HandleActiveArea(ref areaTimeC, areaCWarn, areaCWarnText);
        }
    }

    private void HandleArea(string areaName, bool isOutside, ref float areaTime, GameObject warnObject, GameObject warnText)
    {
        if (isOutside)
        {
            areaTime += Time.deltaTime;

            if (areaTime >= 20f && areaTime < 30f)
            {
                activeWarning = areaName;
                warnObject.SetActive(true);
                warnText.SetActive(true);
            }
            else if (areaTime >= 30f)
            {
                PlayFunction(areaName); // Trigger the function
                ResetAll();
            }
        }
    }

    private void HandleActiveArea(ref float areaTime, GameObject warnObject, GameObject warnText)
    {
        areaTime += Time.deltaTime;

        if (areaTime >= 30f)
        {
            PlayFunction(activeWarning); // Trigger the function
            ResetAll();
        }
    }

    private void ResetAreaTimers(string exclude = "")
    {
        if (exclude != "A") ResetA();
        if (exclude != "B") ResetB();
        if (exclude != "C") ResetC();
    }

    private void ResetAll()
    {
        activeWarning = "";

        ResetA();
        ResetB();
        ResetC();
    }

    private void ResetA()
    {
        areaTimeA = 0f;
        areaAWarn.SetActive(false);
        areaAWarnText.SetActive(false);
    }

    private void ResetB()
    {
        areaTimeB = 0f;
        areaBWarn.SetActive(false);
        areaBWarnText.SetActive(false);
    }

    private void ResetC()
    {
        areaTimeC = 0f;
        areaCWarn.SetActive(false);
        areaCWarnText.SetActive(false);
    }

    private void PlayFunction(string areaName)
    {
        Debug.Log($"Function triggered for Area {areaName}");
        // Add your function logic here
    }
}

