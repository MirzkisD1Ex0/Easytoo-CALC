using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CALC_Ctrl : MonoBehaviour {

    [SerializeField]
    public GameObject panel;
    public GameObject symbol;
    public GameObject logger;
    public string panelnum = "";
    public string storageA = "";
    public string storageB = "";
    public string symbolstorage = "";//用于寄存符号
    public bool firstCalc = true;
    public bool isCalc = false;
    public bool CalcEd = false;

    public GameObject debug;

    void Start()
    {
        Press_Clear();//清空所有信息
    }

    void Update () {
        debug.GetComponent<Text>().text = 
            "-Panelnum:" + panelnum + 
            "\n-StorageA:" + storageA + 
            "\n-StorageB:" + storageB + 
            "\n-symbolstorage:" + symbolstorage + 
            "\n-firstCalc:" + firstCalc +
            "\n-isCalc:" + isCalc +
            "\n-CalcEd:" + CalcEd;
    }

    public void NumkeyFunction()
    {
        panelnum = panel.GetComponent<Text>().text;
        isCalc = false;
    }

    //<FunctionPackage>------------------------------------------------------------
    //数据输入功能
    public void Press_Point()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        NumkeyFunction();
        logger.GetComponent<Text>().text += ".";
        panel.GetComponent<Text>().text += ".";
    }
    public void Press_0()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "0";
        panel.GetComponent<Text>().text += "0";
        NumkeyFunction();
    }
    public void Press_1()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "1";
        panel.GetComponent<Text>().text += "1";
        NumkeyFunction();
    }
    public void Press_2()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "2";
        panel.GetComponent<Text>().text += "2";
        NumkeyFunction();
    }
    public void Press_3()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "3";
        panel.GetComponent<Text>().text += "3";
        NumkeyFunction();
    }
    public void Press_4()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "4";
        panel.GetComponent<Text>().text += "4";
        NumkeyFunction();
    }
    public void Press_5()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "5";
        panel.GetComponent<Text>().text += "5";
        NumkeyFunction();
    }
    public void Press_6()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "6";
        panel.GetComponent<Text>().text += "6";
        NumkeyFunction();
    }
    public void Press_7()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "7";
        panel.GetComponent<Text>().text += "7";
        NumkeyFunction();
    }
    public void Press_8()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "8";
        panel.GetComponent<Text>().text += "8";
        NumkeyFunction();
    }
    public void Press_9()
    {
        if (CalcEd)
        {
            Press_Clear();
        }
        logger.GetComponent<Text>().text += "9";
        panel.GetComponent<Text>().text += "9";
        NumkeyFunction();
    }
    //</FunctionPackage>

    //备注01:加减乘除功能只有4处符号不一样
    //<FunctionPackage>------------------------------------------------------------
    //加法功能
    public void Press_Addition()
    {
        //<Function>
        //Logger_符号纠正
        if (logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "+" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "-" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "*" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "/")
        {
            logger.GetComponent<Text>().text = logger.GetComponent<Text>().text.Remove(logger.GetComponent<Text>().text.Length - 1, 1);
            logger.GetComponent<Text>().text += "+";
        }
        else
        {
            logger.GetComponent<Text>().text += "+";
        }
        //</Function>

        CalcEd = false;

        if (!isCalc)
        {
            if (firstCalc)
            {
                firstCalc = false;
                storageA = panelnum;
            }
            else
            {
                CalcCoreFunction();
            }
            
            isCalc = true;
        }
        symbolstorage = "+";
        panelnum = "0";
        symbol.GetComponent<Text>().text = "+";
        panel.GetComponent<Text>().text = "";
    }
    //</FunctionPackage>

    //<FunctionPackage>------------------------------------------------------------
    //减法功能
    public void Press_Subtraction()
    {
        if (logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "+" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "-" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "*" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "/")
        {
            logger.GetComponent<Text>().text = logger.GetComponent<Text>().text.Remove(logger.GetComponent<Text>().text.Length - 1, 1);
            logger.GetComponent<Text>().text += "-";
        }
        else
        {
            logger.GetComponent<Text>().text += "-";
        }

        CalcEd = false;
        if (!isCalc)
        {
            if (firstCalc)
            {
                firstCalc = false;
                storageA = panelnum;
            }
            else
            {
                CalcCoreFunction();
            }
            isCalc = true;
        }
        symbolstorage = "-";
        panelnum = "0";
        symbol.GetComponent<Text>().text = "-";
        panel.GetComponent<Text>().text = "";
    }
    //</FunctionPackage>

    //<FunctionPackage>------------------------------------------------------------
    //乘法功能
    public void Press_Multiplication()
    {
        if (logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "+" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "-" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "*" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "/")
        {
            logger.GetComponent<Text>().text = logger.GetComponent<Text>().text.Remove(logger.GetComponent<Text>().text.Length - 1, 1);
            logger.GetComponent<Text>().text += "*";
        }
        else
        {
            logger.GetComponent<Text>().text += "*";
        }

        CalcEd = false;
        if (!isCalc)
        {
            if (firstCalc)
            {
                firstCalc = false;
                storageA = panelnum;
            }
            else
            {
                CalcCoreFunction();
            }
            isCalc = true;
        }
        //<Function>
        //StorageA_乘法纠正
        //备注03:防止“*数字*=”的情况下报错
        if (storageA == "")
        {
            storageA = 0.ToString();
        }
        //</Function>
        symbolstorage = "*";
        panelnum = "0";
        symbol.GetComponent<Text>().text = "*";
        panel.GetComponent<Text>().text = "";
    }
    //</FunctionPackage>

    //<FunctionPackage>------------------------------------------------------------
    //除法功能
    public void Press_Division()
    {
        if (logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "+" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "-" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "*" || logger.GetComponent<Text>().text.Substring(logger.GetComponent<Text>().text.Length - 1, 1) == "/")
        {
            logger.GetComponent<Text>().text = logger.GetComponent<Text>().text.Remove(logger.GetComponent<Text>().text.Length - 1, 1);
            logger.GetComponent<Text>().text += "/";
        }
        else
        {
            logger.GetComponent<Text>().text += "/";
        }

        CalcEd = false;
        if (!isCalc)//此处可简化
        {
            if (firstCalc)
            {
                firstCalc = false;
                storageA = panelnum;
            }
            else
            {
                CalcCoreFunction();
            }
            isCalc = true;
        }
        //<Function>
        //StorageA_除法纠正
        //备注03:防止“/数字/=”的情况下报错
        if (storageA == "")
        {
            storageA = 0.ToString();
        }
        //</Function>
        symbolstorage = "/";
        panelnum = "0";
        symbol.GetComponent<Text>().text = "/";
        panel.GetComponent<Text>().text = "";
    }
    //</FunctionPackage>

    //<FunctionPackage>
    //核心运算功能
    public void CalcCoreFunction()
    {
        switch (symbolstorage)
        {
            case "+": storageA = (float.Parse(storageA) + float.Parse(panelnum)).ToString(); panelnum = 0.ToString(); break;
            case "-": storageA = (float.Parse(storageA) - float.Parse(panelnum)).ToString(); panelnum = 0.ToString(); break;
            case "*": storageA = (float.Parse(storageA) * float.Parse(panelnum)).ToString(); panelnum = 0.ToString(); break;
            case "/": storageA = (float.Parse(storageA) / float.Parse(panelnum)).ToString(); panelnum = 0.ToString(); break;
            default: break;
        }
    }
    //</FunctionPackage>

    public void Press_Equal() //按下
    {
        if (storageA == "" && (symbol.GetComponent<Text>().text == "*" || symbol.GetComponent<Text>().text == "/")) //如果寄存器A未存取数字（“/数字”或“数字*”）报错
        {
            panel.GetComponent<Text>().text = "ERROR";
            CalcEd = true;
        }
        else if (storageA == "" && symbol.GetComponent<Text>().text == "+") //如果寄存器A未存取数字（“+数字”或“数字+”）寄存器A设置为0
        {
            storageA = (0 + float.Parse(panelnum)).ToString(); panelnum = 0.ToString();
            panel.GetComponent<Text>().text = storageA;
            CalcEd = true;
        }
        else if (storageA == "" && symbol.GetComponent<Text>().text == "-") //如果寄存器A未存取数字（“-数字”或“数字-”）寄存器A设置为0
        {
            storageA = (0 - float.Parse(panelnum)).ToString(); panelnum = 0.ToString();
            panel.GetComponent<Text>().text = storageA;
            CalcEd = true;
        }
        else
        {
            //<Function>
            //Panelnum_乘除法纠正
            //备注02:防止计算完成后多次按下"="导致结果成为"Inf"
            if (panelnum == "0" && (symbolstorage == "*" || symbolstorage == "/"))
            {
                panelnum = 0.ToString();
            }
            //</Function>

            CalcCoreFunction();

            if (storageA != "") //寄存器A为空直接显示不予计算
            {
                panel.GetComponent<Text>().text = storageA;
            }
            else if (storageA == "" && panelnum == "") //什么都没输入就按“=”显示错误
            {
                panel.GetComponent<Text>().text = "0";
                //panel.GetComponent<Text>().text = "<color=#0000ff>Error</color>"; //报错
            }
            else //如果寄存器A为空但面板有数字(输入数字却未进行计算)则直接显示面板数字
            {
                panel.GetComponent<Text>().text = panelnum;
            }
            symbolstorage = "";
            CalcEd = true;
        }
    }

    //<FunctionPackage>
    //退格功能("B"ackspace)
    public void Press_Backspace()
    {
        if (panel.GetComponent<Text>().text != "" && !CalcEd)
        {
            panel.GetComponent<Text>().text = panel.GetComponent<Text>().text.Substring(0, panel.GetComponent<Text>().text.Length - 1);
            logger.GetComponent<Text>().text = logger.GetComponent<Text>().text.Substring(0, logger.GetComponent<Text>().text.Length - 1);
        }
    }
    //</FunctionPackage>

    //<FunctionPackage>
    //清零重置功能("C"lear)
    public void Press_Clear()
    {
        panel.GetComponent<Text>().text = "";
        symbol.GetComponent<Text>().text = "";
        logger.GetComponent<Text>().text = " ";
        panelnum = "";
        symbolstorage = "";
        storageA = "";
        storageB = "";
        firstCalc = true;
        isCalc = false;
        CalcEd = false;
    }
    //</FunctionPackage>
}