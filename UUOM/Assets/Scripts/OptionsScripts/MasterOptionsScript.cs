using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class MasterOptionsScript : MonoBehaviour
{
    private string cantFindElementAttributes = "Cannot find element Attributes, make sure everything is spelt correctly, or the name, type and tab int connect!";

    //public GameObject screenContent;

    //[HideInInspector]
    public List<GameObject> contentParents = new List<GameObject>();
    public List<GameObject> tabButtons = new List<GameObject>();

    public GameObject boolTemplate;
    public GameObject dropdownTemplate;
    public GameObject sliderTemplate;

    [Space]
    [Header("Loose Values")]
    public GameObject greyScaleColorCurves;

    [Header("Element Lists:")]
    [Space]
    //[("Remember that elementName #0 goes with elementType #0 and elementTab #0, don't mess it up!")]
    [Space]
    public List<string> elementNames = new List<string>();
    public List<string> elementTypes = new List<string>();
    public List<int> elementTabs = new List<int>();
    [Space]
    [Header("Simple Create Element:")]
    [Space]
    [HideInInspector]
    public string elementName;
    [HideInInspector]
    public string elementType;
    [HideInInspector]
    public int elementTab;
    [Space]
    [Header("Simple Remove Element:")]
    [Space]
    [HideInInspector]
    public string elementNameToRemove;
    [HideInInspector]
    public string elementTypeToRemove;
    [HideInInspector]
    public int elementTabToRemove;

    public void createElement()
    {
        elementNames.Add(elementName);
        elementTypes.Add(elementType);
        elementTabs.Add(elementTab);
    }

    public void removeElement()
    {
        bool found = false;

        for (int i = 0; i < elementNames.Count; i++)
        {
            if (elementNames[i] == elementNameToRemove && elementTypes[i] == elementTypeToRemove && elementTabs[i] == elementTabToRemove)
            {
                /*for (int j = 0; j < elementTypes.Count; j++)
                {
                    if (elementTypes[j] == elementTypeToRemove)
                    {
                        for (int l = 0; l < elementTabs.Count; l++)
                        {
                            if (elementTabs[l] == elementTabToRemove)
                            {
                                elementNames.RemoveAt(i);
                                elementTypes.RemoveAt(j);
                                elementTabs.RemoveAt(l);
                            }
                        }
                    }
                }*/

                elementNames.RemoveAt(i);
                elementTypes.RemoveAt(i);
                elementTabs.RemoveAt(i);
                found = true;
                break;
            }
        }
        if (!found)
        {
            Debug.LogError(cantFindElementAttributes);
        }
        
    }

    public void updateOptions()
    {


        /*for (int i = 0; i <= screenContent.transform.childCount; i++)
        {
            DestroyImmediate(screenContent.GetComponent<RectTransform>().GetChild(i).gameObject);
        }*/

        for (int i = 0; i < contentParents.Count; i++)
        {
            foreach (Transform child in contentParents[i].transform)
            {
                DestroyImmediate(child.gameObject);
            }
        }

        for (int i = 0; i < elementNames.Count; i++)
        {
            //if (elementTabs[i] == 0)
            //{
                if (!contentParents[elementTabs[i]].transform.Find(elementNames[i]))
                {
                    if (elementTypes[i] == "Bool")
                    {
                        GameObject newOptionOBJ = Instantiate(boolTemplate, contentParents[elementTabs[i]].gameObject.transform);
                        newOptionOBJ.name = elementNames[i];
                        newOptionOBJ.transform.Find("Name").GetComponent<TMP_Text>().text = elementNames[i];
                    }

                    if(elementTypes[i] == "Dropdown")
                    {
                        GameObject newOptionOBJ = Instantiate(dropdownTemplate, contentParents[elementTabs[i]].gameObject.transform);
                        newOptionOBJ.name = elementNames[i];
                        newOptionOBJ.transform.Find("Name").GetComponent<TMP_Text>().text = elementNames[i];
                    }

                if (elementTypes[i] == "Slider")
                {
                    GameObject newOptionOBJ = Instantiate(sliderTemplate, contentParents[elementTabs[i]].gameObject.transform);
                    newOptionOBJ.name = elementNames[i];
                    newOptionOBJ.transform.Find("Name").GetComponent<TMP_Text>().text = elementNames[i];
                }
            }
           // }
        }
    }

    //Buttons\\
    public void screenButton()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            tabButtons[i].SetActive(false);
        }
        tabButtons[0].SetActive(true);
    }

    public void audioButton()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            tabButtons[i].SetActive(false);
        }
        tabButtons[1].SetActive(true);
    }

    //Option Functions\\

    public void greyScale(bool uiValue)
    {
        greyScaleColorCurves.SetActive(uiValue);
    }
}
