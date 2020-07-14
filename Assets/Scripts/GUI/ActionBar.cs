using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    private GameObject barPanel;
    public GameObject actionPanel;
    public ArrayList actions;
    private Text NameText;
    void Start()
    {
        player = Camera.main.GetComponent<Player>();
        barPanel = this.gameObject;
        actions = new ArrayList();
        NameText = GetComponentInChildren<Text>();
    }

    public void onSelectionChanged()
    {
        if(player.selected != null)
        {
            gameObject.SetActive(true);
            clearActionBar();
            NameText.text = player.selected.objName;
            IAction[] objActions = player.selected.actions;

            int panelOffset = 0;
            foreach(IAction action in objActions)
            {
                GameObject panel = GameObject.Instantiate(actionPanel);
                panel.GetComponentInChildren<UnityEngine.UI.Text>().text = action.getName();
                panel.transform.SetParent(transform, false);
                panel.GetComponent<Button>().onClick.AddListener(action.runAction);
                panel.transform.Translate(new Vector3(panelOffset, 0, 0), Space.Self);
                panelOffset += 100;
                actions.Add(panel);
            }
        } else
        {
            clearActionBar();
            NameText.text = "BuildMenu";
            IAction[] objActions = getBuildMenu();

            int panelOffset = 0;
            foreach (IAction action in objActions)
            {
                GameObject panel = GameObject.Instantiate(actionPanel);
                panel.GetComponentInChildren<UnityEngine.UI.Text>().text = action.getName();
                panel.transform.SetParent(transform, false);
                panel.GetComponent<Button>().onClick.AddListener(action.runAction);
                panel.transform.Translate(new Vector3(panelOffset, 0, 0), Space.Self);
                panelOffset += 100;
                actions.Add(panel);
            }
            
        }
    }

    private IAction[] getBuildMenu()
    {
        return new IAction[] { new ConstructAction(player)};
    }

    private void clearActionBar()
    {
        if(actions != null)
        {
            foreach (GameObject action in actions)
            {
                GameObject.Destroy(action);
            }
            actions.Clear();
        }
    }
}
