using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private ButtonModel m_PrefabButtonModel;
    [SerializeField] private List<InformationModel> m_Models3D;
    [SerializeField] private Transform m_ParentButtonModels;
    [SerializeField] private Transform m_ParentImageTarget;
    [SerializeField] private GameObject m_ButtonBackList;
    [SerializeField] private Text m_TextHeader;
    [SerializeField] private GameObject m_ScrollView;

    private void Start()
    {
        for (int i = 0; i < m_Models3D.Count; i++)
        {
            var button = Instantiate(m_PrefabButtonModel, m_ParentButtonModels);
            //button.name = m_Models3D[i].id + m_Models3D[i].nameModel;
            //button.textIdModel.text = m_Models3D[i].id;
            button.textNameModel.text = m_Models3D[i].nameModel;
            button.modelButton = m_Models3D[i].prefabModel;
            button.imageModel.sprite = m_Models3D[i].imageModel;
            button.GetComponent<Button>().onClick.AddListener(delegate
            {
                ActionButtonModel(button.modelButton);
            });
        }
    }

    private void ActionButtonModel(Transform prefabModel)
    {
        Instantiate(prefabModel, m_ParentImageTarget);
        m_ButtonBackList.SetActive(true);
        m_TextHeader.text = "DETALHE";
        m_ScrollView.SetActive(false);
    }

    public void OnButtonBackListClicked()
    {
        m_ButtonBackList.SetActive(false);
        m_TextHeader.text = "CARROS";
        m_ScrollView.SetActive(true);
        Destroy(m_ParentImageTarget.GetChild(0).gameObject);
    }
}