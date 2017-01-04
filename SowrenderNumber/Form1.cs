using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SowrenderNumber
{
    /*
     * 0~999까지의 숫자를 입력했을 때, 입력받은 수를 한글로 출력해주는 프로그램.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int inputNumFromUser;
            if (!String.IsNullOrWhiteSpace(inputNum.Text) && int.TryParse(inputNum.Text, out inputNumFromUser))
            {
                inputNumFromUser = int.Parse(inputNum.Text);
                if (inputNumFromUser > 999)
                {
                    MessageBox.Show("0~999 사이의 숫자를 입력해주세요.");
                }
                else
                {
                    int[] numberArray = new int[3];
                    numberArray = returnArray(inputNumFromUser, returnNumSize(inputNumFromUser));

                    printNum.Text = inputNumFromUser + " : " + returnString(numberArray);
                }
            }
            else {
                MessageBox.Show("숫자를 입력해주세요.");
                printNum.Text = "";
            }
        }

        private int[] returnArray(int number, int size)
        {
            int[] numberArray = new int[3];
            if (size == 1) {
                numberArray[0] = number; // 일의자리
                numberArray[1] = 0;
                numberArray[2] = 0;
            }
            else if (size == 2)
            {
                numberArray[0] = number % 10; // 일의자리
                numberArray[1] = number / 10; // 십의자리
                numberArray[2] = 0;
            }
            else
            {
                numberArray[0] = number % 10; // 일의자리
                number -= number % 10;
                numberArray[1] = (number % 100) / 10; // 십의자리
                numberArray[2] = number / 100; // 백의자리
            }
            return numberArray;
        }

        private int returnNumSize(int num) // 입력받은 숫자의 크기 계산
        {
            int numSize = 0;

            if (num > 99)
                numSize = 3;

            else if (num > 9)
                numSize = 2;

            else
                numSize = 1;

            return numSize;
        }

        private string returnString(int[] numArray) {
            string result = null;

            for (int index = 2; index >= 0; index--) {
                if (numArray[index] != 0) {
                    switch (numArray[index])
                    {
                        case 1:
                            if (index == 0)
                                result += "일"; break;
                        case 2:
                            result += "이"; break;
                        case 3:
                            result += "삼"; break;
                        case 4:
                            result += "사"; break;
                        case 5:
                            result += "오"; break;
                        case 6:
                            result += "육"; break;
                        case 7:
                            result += "칠"; break;
                        case 8:
                            result += "팔"; break;
                        case 9:
                            result += "구"; break;
                    }
                    switch(index){
                        case 2:
                            result += "백"; break;
                        case 1:
                            result += "십"; break;
                    }
                }
            }
            if (String.IsNullOrWhiteSpace(result)) {
                result = "영";
            }
       
            return result;
        } 
    }
}
