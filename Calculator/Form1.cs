using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class FormMain : Form
    {
        public struct ButtonStruct
        {
            public char Content;
            public bool IsBold;
            public ButtonStruct(char content, bool isBold)
            {
                this.Content = content;
                this.IsBold = isBold;
            }
            public override string ToString()
            {
                return Content.ToString();
            }
        }

        private ButtonStruct[,] buttons =
        {
            { new ButtonStruct('%', false), new ButtonStruct('Œ', false), new ButtonStruct('C', false), new ButtonStruct('⌫', false) },
            { new ButtonStruct('⅟', false), new ButtonStruct('²', false), new ButtonStruct('⎷', false), new ButtonStruct('÷', false) },
            { new ButtonStruct('7', true), new ButtonStruct('8', true), new ButtonStruct('9', true), new ButtonStruct('×', false) },
            { new ButtonStruct('4', true), new ButtonStruct('5', true), new ButtonStruct('6', true), new ButtonStruct('-', false) },
            { new ButtonStruct('1', true), new ButtonStruct('2', true), new ButtonStruct('3', true), new ButtonStruct('+', false) },
            { new ButtonStruct('±', false), new ButtonStruct('0', true), new ButtonStruct(',', false), new ButtonStruct('=', false) }
        };

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MakeResultBox();
            MakeButtons(buttons);
        }

        private void MakeResultBox()
        {
            RichTextBox resultBox = new RichTextBox();
            resultBox.ReadOnly = true;
            resultBox.SelectionAlignment = HorizontalAlignment.Right;
            resultBox.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            resultBox.Width = this.Width - 16;
            resultBox.Height = 120;
            resultBox.Text = "123456";
            this.Controls.Add(resultBox);
        }

        private void MakeButtons(ButtonStruct[,] buttons)
        {
            int buttonWidth = 80;
            int buttonHeight = 60;
            int posX = 0;
            int posY = 110;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    ButtonStruct myButtonStruct = buttons[i, j];
                    Button myButton = new Button();
                    FontStyle myButtonStyle = myButtonStruct.IsBold ? FontStyle.Bold : FontStyle.Regular;
                    myButton.Font = new Font("Segoe UI", 16, myButtonStyle);
                    myButton.Text = myButtonStruct.ToString();
                    myButton.Width = buttonWidth;
                    myButton.Height = buttonHeight;
                    myButton.Left = posX;
                    myButton.Top = posY;
                    this.Controls.Add(myButton);
                    posX += buttonWidth;
                }
                posX = 0;
                posY += buttonHeight;
            }
        }
    }
}
