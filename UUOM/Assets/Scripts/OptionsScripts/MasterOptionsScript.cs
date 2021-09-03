using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterOptionsScript : MonoBehaviour
{
    [Header("Element Lists:")]
    [Space]
    //[("Remember that elementName #0 goes with elementType #0 and elementTab #0, don't mess it up!")]
    [Space]
    public List<string> elementNames = new List<string>();
    public List<string> elementTypes = new List<string>();
    public List<int> elementTabs = new List<int>();
    [Space]
    [Header("Create element:")]
    [Space]
    public string elementName;
    public string elementType;
    public int elementTab;

    public void createElement()
    {
        elementNames.Add(elementName);
        elementTypes.Add(elementType);
        elementTabs.Add(elementTab);
    }
}
