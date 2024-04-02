using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGrid : MonoBehaviour
{
    public GameObject grid;
    GameObject Null;
    MainVariables mainVariables;
    GridComponents gridComponents;
    Color translucentRed = new Color(1, 0, 0, 0.5f);
    Color blue = new Color(0, 131 / 255f, 1);
    Color translucentBlue = new Color(0, 131 / 255f, 1, 0.5f);
    /**
     * �� �׸����� �̴Ϻ��� ��ġ
     */
    int MiniBoardPosition;
    private void Start()
    {
        GameObject script = GameObject.Find("Scripts");
        mainVariables = script.GetComponent<MainVariables>();
        gridComponents = grid.GetComponent<GridComponents>();
        Null = GameObject.Find("Null");
        MiniBoardPosition = gridComponents.miniboard.GetComponent<MiniboardScript>().MBPosition;
    }
    public void Select()
    {
        //�� �׸������� üũ
        if (!gridComponents.state.Equals("")) { return; }

        //���� ���� �ȵ� �̴Ϻ������� üũ
        if (!mainVariables.miniBoardStates[MiniBoardPosition].Equals("") && mainVariables.restrictGridInput) { return; }

        //���� ������ �׸������� üũ
        if (!mainVariables.isMBTarget[MiniBoardPosition] && mainVariables.restrictGridInput) { return; } 

        if (mainVariables.isOTurn)
        {
            if (gridComponents.isSelected)
            {
                gridComponents.O.GetComponent<SpriteRenderer>().color = Color.red;
                mainVariables.isOTurn = false;
                mainVariables.textObj.GetComponent<Text>().text = "X �����Դϴ�.";
                gridComponents.state = "o";
                gridComponents.isSelected = false;
                mainVariables.selectedGrid = Null;
                if(checkWin(true, gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "o";
                    if (checkWin(true, mainVariables.miniBoardStates))
                    {
                        mainVariables.WinText.GetComponent<Text>().text = "O�� �¸��߽��ϴ�.";
                        mainVariables.WinPanel.SetActive(true);
                    }
                }
                else if (checkDraw(gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "n";
                }
                if (checkDraw(mainVariables.miniBoardStates))
                {
                    mainVariables.WinText.GetComponent<Text>().text = "���º��Դϴ�.";
                    mainVariables.WinPanel.SetActive(true);
                }

                //Ÿ�� �̴� ������ ����
                resetIsMiniBoardTarget();
                if (mainVariables.miniBoardStates[gridComponents.position].Equals("")) //�ش� �̴� �������� �º� ���� x
                {
                    mainVariables.isMBTarget[gridComponents.position] = true; //�� �̴� �����Ǹ� Ȱ��ȭ
                }
                else
                {
                    for(int i=0; i<9; i++)
                    {
                        if (mainVariables.miniBoardStates[i].Equals(""))
                        {
                            mainVariables.isMBTarget[i] = true; //��� �º� ���� �� �� ������ Ȱ��ȭ
                        }
                    }
                }
            } else
            {
                //�׸��� ����
                mainVariables.selectedGrid.GetComponent<GridComponents>().O.SetActive(false);
                mainVariables.selectedGrid.GetComponent<GridComponents>().isSelected = false;
                gridComponents.O.SetActive(true);
                gridComponents.isSelected = true;
                gridComponents.O.GetComponent<SpriteRenderer>().color = translucentRed;
                mainVariables.selectedGrid = grid;
            }
        }
        else //if(isXTurn)
        {
            if (gridComponents.isSelected)
            {
                gridComponents.X.GetComponent<SpriteRenderer>().color = blue;
                gridComponents.X2.GetComponent<SpriteRenderer>().color = blue;
                mainVariables.isOTurn = true;
                mainVariables.textObj.GetComponent<Text>().text = "O �����Դϴ�.";
                gridComponents.state = "x";
                gridComponents.isSelected = false;
                mainVariables.selectedGrid = Null;
                if (checkWin(false, gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "x";
                    if (checkWin(false, mainVariables.miniBoardStates))
                    {
                        mainVariables.WinText.GetComponent<Text>().text = "X�� �¸��߽��ϴ�.";
                        mainVariables.WinPanel.SetActive(true);
                    } 
                } else if (checkDraw(gridStates())){
                    mainVariables.miniBoardStates[MiniBoardPosition] = "n";
                }
                if (checkDraw(mainVariables.miniBoardStates))
                {
                    mainVariables.WinText.GetComponent<Text>().text = "���º��Դϴ�.";
                    mainVariables.WinPanel.SetActive(true);
                }
                //Ÿ�� �̴� ������ ����
                resetIsMiniBoardTarget();
                if (mainVariables.miniBoardStates[gridComponents.position].Equals("")) //�ش� �̴� �������� �º� ���� x
                {
                    mainVariables.isMBTarget[gridComponents.position] = true; //�� �̴� �����Ǹ� Ȱ��ȭ
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (mainVariables.miniBoardStates[i].Equals(""))
                        {
                            mainVariables.isMBTarget[i] = true; //��� �º� ���� �� �� ������ Ȱ��ȭ
                        }
                    }
                }
            }
            else
            {
                //�׸��� ����
                mainVariables.selectedGrid.GetComponent<GridComponents>().X.SetActive(false);
                mainVariables.selectedGrid.GetComponent<GridComponents>().isSelected = false;
                gridComponents.X.SetActive(true);
                gridComponents.isSelected = true;
                gridComponents.X.GetComponent<SpriteRenderer>().color = translucentBlue;
                gridComponents.X2.GetComponent<SpriteRenderer>().color = translucentBlue;
                mainVariables.selectedGrid = grid;
            }
        }
    }

    bool checkWin(bool isO, string[] board)
    {
        bool win = false;
        string c;
        if (isO) { c = "o"; } else { c = "x"; }

        if (board[0].Equals(c) && board[1].Equals(c) && board[2].Equals(c)) { win = true; }
        if (board[3].Equals(c) && board[4].Equals(c) && board[5].Equals(c)) { win = true; }
        if (board[6].Equals(c) && board[7].Equals(c) && board[8].Equals(c)) { win = true; }
        if (board[0].Equals(c) && board[3].Equals(c) && board[6].Equals(c)) { win = true; }
        if (board[1].Equals(c) && board[4].Equals(c) && board[7].Equals(c)) { win = true; }
        if (board[2].Equals(c) && board[5].Equals(c) && board[8].Equals(c)) { win = true; }
        if (board[0].Equals(c) && board[4].Equals(c) && board[8].Equals(c)) { win = true; }
        if (board[2].Equals(c) && board[4].Equals(c) && board[6].Equals(c)) { win = true; }

        return win;
    }

    bool checkDraw(string[] board)
    {   
        if(checkWin(true, board)) return false;
        if(checkWin(false, board)) return false;

        bool isDraw = true;
        foreach(string s in board)
        {
            if (s.Equals(""))
            {
                isDraw = false;
            }
        }
        return isDraw;
    }

    string[] gridStates()
    {
        string[] states = new string[9];
        for(int i=0; i<9; i++)
        {
            states[i] = gridComponents.miniboard.GetComponent<MiniboardScript>().grids[i].GetComponent<GridComponents>().state;
        }
        return states;
    }

    void resetIsMiniBoardTarget()
    {
        for(int i=0; i<9; i++)
        {
            mainVariables.isMBTarget[i] = false;
        }
    }
}
