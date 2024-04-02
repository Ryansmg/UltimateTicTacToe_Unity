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
     * 이 그리드의 미니보드 위치
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
        //빈 그리드인지 체크
        if (!gridComponents.state.Equals("")) { return; }

        //승패 결정 안된 미니보드인지 체크
        if (!mainVariables.miniBoardStates[MiniBoardPosition].Equals("") && mainVariables.restrictGridInput) { return; }

        //선택 가능한 그리드인지 체크
        if (!mainVariables.isMBTarget[MiniBoardPosition] && mainVariables.restrictGridInput) { return; } 

        if (mainVariables.isOTurn)
        {
            if (gridComponents.isSelected)
            {
                gridComponents.O.GetComponent<SpriteRenderer>().color = Color.red;
                mainVariables.isOTurn = false;
                mainVariables.textObj.GetComponent<Text>().text = "X 차례입니다.";
                gridComponents.state = "o";
                gridComponents.isSelected = false;
                mainVariables.selectedGrid = Null;
                if(checkWin(true, gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "o";
                    if (checkWin(true, mainVariables.miniBoardStates))
                    {
                        mainVariables.WinText.GetComponent<Text>().text = "O가 승리했습니다.";
                        mainVariables.WinPanel.SetActive(true);
                    }
                }
                else if (checkDraw(gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "n";
                }
                if (checkDraw(mainVariables.miniBoardStates))
                {
                    mainVariables.WinText.GetComponent<Text>().text = "무승부입니다.";
                    mainVariables.WinPanel.SetActive(true);
                }

                //타겟 미니 게임판 설정
                resetIsMiniBoardTarget();
                if (mainVariables.miniBoardStates[gridComponents.position].Equals("")) //해당 미니 게임판이 승부 결정 x
                {
                    mainVariables.isMBTarget[gridComponents.position] = true; //그 미니 게임판만 활성화
                }
                else
                {
                    for(int i=0; i<9; i++)
                    {
                        if (mainVariables.miniBoardStates[i].Equals(""))
                        {
                            mainVariables.isMBTarget[i] = true; //모든 승부 결정 안 난 게임판 활성화
                        }
                    }
                }
            } else
            {
                //그리드 선택
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
                mainVariables.textObj.GetComponent<Text>().text = "O 차례입니다.";
                gridComponents.state = "x";
                gridComponents.isSelected = false;
                mainVariables.selectedGrid = Null;
                if (checkWin(false, gridStates()))
                {
                    mainVariables.miniBoardStates[MiniBoardPosition] = "x";
                    if (checkWin(false, mainVariables.miniBoardStates))
                    {
                        mainVariables.WinText.GetComponent<Text>().text = "X가 승리했습니다.";
                        mainVariables.WinPanel.SetActive(true);
                    } 
                } else if (checkDraw(gridStates())){
                    mainVariables.miniBoardStates[MiniBoardPosition] = "n";
                }
                if (checkDraw(mainVariables.miniBoardStates))
                {
                    mainVariables.WinText.GetComponent<Text>().text = "무승부입니다.";
                    mainVariables.WinPanel.SetActive(true);
                }
                //타겟 미니 게임판 설정
                resetIsMiniBoardTarget();
                if (mainVariables.miniBoardStates[gridComponents.position].Equals("")) //해당 미니 게임판이 승부 결정 x
                {
                    mainVariables.isMBTarget[gridComponents.position] = true; //그 미니 게임판만 활성화
                }
                else
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (mainVariables.miniBoardStates[i].Equals(""))
                        {
                            mainVariables.isMBTarget[i] = true; //모든 승부 결정 안 난 게임판 활성화
                        }
                    }
                }
            }
            else
            {
                //그리드 선택
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
