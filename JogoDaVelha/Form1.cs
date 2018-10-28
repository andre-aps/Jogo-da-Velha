using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class frmVelha : Form
    {
        bool vez = true; //true = X; false = O
        int contador = 0; //Variável para contar o número de jogadas

        public frmVelha()
        {
            InitializeComponent();            
        }

        private void jogar_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "") {
                if (vez) {
                    b.Text = "X";
                    b.ForeColor = Color.Blue;
                    lblJogador.Text = "O";
                    lblJogador.ForeColor = Color.Red;
                    vez = !vez;
                } else {
                    b.Text = "O";
                    b.ForeColor = Color.Red;
                    lblJogador.Text = "X";
                    lblJogador.ForeColor = Color.Blue;
                    vez = !vez;
                }
            }
            contador++;
            checar_vencedor(); // Chama a função para checar se algum jogador venceu a partida            
        }        

        //Função que verificar se o jogador X ou o jogador O venceu a partida
        private void checar_vencedor()
        {           
            bool vencedor = false;            
            
            //Checar vencedor na horizontal
            if ((btn7.Text == btn8.Text) && (btn8.Text == btn9.Text) && (btn7.Text != "")) {
                vencedor = true;
            } else if ((btn4.Text == btn5.Text) && (btn5.Text == btn6.Text) && (btn4.Text != "")) {
                vencedor = true;
            } else if ((btn1.Text == btn2.Text) && (btn2.Text == btn3.Text) && (btn1.Text != "")) {
                vencedor = true;
            }

            //Checar vencedor na vertical
            if ((btn7.Text == btn4.Text) && (btn4.Text == btn1.Text) && (btn7.Text != "")) {
                vencedor = true;
            }
            else if ((btn8.Text == btn5.Text) && (btn5.Text == btn2.Text) && (btn8.Text != "")) {
                vencedor = true;
            }
            else if ((btn9.Text == btn6.Text) && (btn6.Text == btn3.Text) && (btn9.Text != "")) {
                vencedor = true;
            }

            //Checar vencedor na diagonal
            if ((btn7.Text == btn5.Text) && (btn5.Text == btn3.Text) && (btn7.Text != "")) {
                vencedor = true;
            }
            else if ((btn9.Text == btn5.Text) && (btn5.Text == btn1.Text) && (btn9.Text != "")) {
                vencedor = true;
            }            

            //Caso o jogador X ou o jogador O vencer a partida, será acrescentado um ponto ao placar do respectivo jogador
            if (vencedor) {
                string jogador = "";
                if(vez) {
                    jogador = "O";                    
                    lblO.Text = (Convert.ToInt32(lblO.Text) + 1).ToString();
                } else {
                    jogador = "X";
                    lblX.Text = (Convert.ToInt32(lblX.Text) + 1).ToString();
                }
                MessageBox.Show("O jogador " + jogador + " Venceu!", "Parabéns",MessageBoxButtons.OK);                
                limpar();
            } else {
                if(contador == 9) {
                    lblEmpate.Text = (Convert.ToInt32(lblEmpate.Text) + 1).ToString();
                    MessageBox.Show("Empate!", "Ops",MessageBoxButtons.OK);                    
                    limpar();
                }
            }            
        }
        
        private void limpar()
        {
            //Para cada iteração do laço, o texto de cada controle do tipo Button é apagado 
            foreach (Control c in this.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    c.Text = "";
                }
            }
            contador = 0;

            //Necessário para que o texto do botão resetar não fique em branco devido ao laço de repetição acima
            btnResetar.Text = "Resetar";
        }          

        private void frmVelha_Load(object sender, EventArgs e)
        {
            lblJogador.ForeColor = Color.Blue;
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            //Retorna para o valor 0 a label do jogador X, do jogador O e de empate
            lblO.Text = "0";
            lblX.Text = "0";
            lblEmpate.Text = "0";
        }
    }
}
