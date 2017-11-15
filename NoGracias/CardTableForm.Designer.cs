using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NoGracias
{
    partial class CardTableForm
    {
        #region Player
        public string PlayerName
        {
            get { return this.MainPlayerName.Text; }
            set
            {
                this.MainPlayerName.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.MainPlayerName.Text = value;
                });
            }
        }

        public int Chips
        {
            get { return Int32.Parse(this.MainPlayerChipCount.Text); }
            set
            {
                this.MainPlayerChipCount.Invoke((MethodInvoker)delegate
               {
                   this.MainPlayerChipCount.Text = value.ToString();
               });
            }
        }
        public bool Card1
        {
            get { return this.MainPlayerCard1.Visible; }
            set { this.MainPlayerCard1.Visible = value; }
        }
        public bool Card2
        {
            get { return this.MainPlayerCard2.Visible; }
            set { this.MainPlayerCard2.Visible = value; }
        }
        public bool Card3
        {
            get { return this.MainPlayerCard3.Visible; }
            set { this.MainPlayerCard3.Visible = value; }
        }
        public bool Card4
        {
            get { return this.MainPlayerCard4.Visible; }
            set { this.MainPlayerCard4.Visible = value; }
        }
        public bool Card5
        {
            get { return this.MainPlayerCard5.Visible; }
            set { this.MainPlayerCard5.Visible = value; }
        }
        public bool Card6
        {
            get { return this.MainPlayerCard6.Visible; }
            set { this.MainPlayerCard6.Visible = value; }
        }
        public bool Card7
        {
            get { return this.MainPlayerCard7.Visible; }
            set { this.MainPlayerCard7.Visible = value; }
        }
        public bool Card8
        {
            get { return this.MainPlayerCard8.Visible; }
            set { this.MainPlayerCard8.Visible = value; }
        }
        public bool Card9
        {
            get { return this.MainPlayerCard9.Visible; }
            set { this.MainPlayerCard9.Visible = value; }
        }
        public bool Card10
        {
            get { return this.MainPlayerCard10.Visible; }
            set { this.MainPlayerCard10.Visible = value; }
        }
        public bool Card11
        {
            get { return this.MainPlayerCard11.Visible; }
            set { this.MainPlayerCard11.Visible = value; }
        }
        public bool Card12
        {
            get { return this.MainPlayerCard12.Visible; }
            set { this.MainPlayerCard12.Visible = value; }
        }
        public bool Card13
        {
            get { return this.MainPlayerCard13.Visible; }
            set { this.MainPlayerCard13.Visible = value; }
        }
        public bool Card14
        {
            get { return this.MainPlayerCard14.Visible; }
            set { this.MainPlayerCard14.Visible = value; }
        }
        public bool Card15
        {
            get { return this.MainPlayerCard15.Visible; }
            set { this.MainPlayerCard15.Visible = value; }
        }
        public bool Card16
        {
            get { return this.MainPlayerCard16.Visible; }
            set { this.MainPlayerCard16.Visible = value; }
        }
        #endregion
        #region Opp1
        public string Opp1PlayerName
        {
            get { return this.Opp1Name.Text; }
            set
            {
                this.Opp1Name.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp1Name.Text = value;
                });
            }
        }
        #endregion
        #region Opp2
        public string Opp2PlayerName
        {
            get { return this.Opp2Name.Text; }
            set
            {
                this.Opp2Name.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp2Name.Text = value;
                });
            }
        }
        #endregion
        #region Opp3
        public string Opp3PlayerName
        {
            get { return this.Opp3Name.Text; }
            set
            {
                this.Opp3Name.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp3Name.Visible = true;
                    this.Opp3Name.Text = value;
                });
            }
        }
        public bool Opp3ChipGraphic
        {
            get { return opp3ChipGraphic.Visible; }
            set
            {
                opp3ChipGraphic.Visible = value;
            }
        }
        public bool Opp3ChipLabel
        {
            get { return Opp3ChipText.Visible; }
            set
            {
                Opp3ChipText.Visible = value;
            }
        }
        public bool Opp3ChipNumberVisible
        {
            get { return Opp3ChipText.Visible; }
            set
            {
                Opp3ChipText.Visible = value;
            }
        }
        public string Opp3ChipNumber
        {
            get { return Opp3ChipText.Text; }
            set
            {
                Opp3ChipText.Text = value;
            }
        }
        #endregion
        #region Opp4
        public string Opp4PlayerName
        {
            get { return this.Opp4Name.Text; }
            set
            {
                this.Opp4Name.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp4Name.Text = value;
                    this.Opp4Name.Visible = true;
                });
            }
        }
        public bool Opp4ChipGraphic
        {
            get { return opp4ChipGraphic.Visible; }
            set
            {
                opp4ChipGraphic.Visible = value;
            }
        }
        public bool Opp4ChipLabel
        {
            get { return Opp4ChipText.Visible; }
            set
            {
                Opp4ChipText.Visible = value;
            }
        }
        public bool Opp4ChipNumberVisible
        {
            get { return Opp4ChipText.Visible; }
            set
            {
                Opp4ChipText.Visible = value;
            }
        }
        public string Opp4ChipNumber
        {
            get { return Opp4ChipText.Text; }
            set
            {
                Opp4ChipText.Text = value;
            }
        }
        #endregion
        #region Generated Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardTableForm));
            this.MainPlayerName = new System.Windows.Forms.Label();
            this.Opp2Name = new System.Windows.Forms.Label();
            this.Opp1Name = new System.Windows.Forms.Label();
            this.Opp1Card3 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Opp1Card2 = new System.Windows.Forms.PictureBox();
            this.Opp1Card1 = new System.Windows.Forms.PictureBox();
            this.Opp4Name = new System.Windows.Forms.Label();
            this.Opp3Name = new System.Windows.Forms.Label();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.opp3ChipGraphic = new System.Windows.Forms.PictureBox();
            this.Opp1Card4 = new System.Windows.Forms.PictureBox();
            this.opp4ChipGraphic = new System.Windows.Forms.PictureBox();
            this.Opp4ChipText = new System.Windows.Forms.Label();
            this.Opp3ChipText = new System.Windows.Forms.Label();
            this.MainPlayerChipText = new System.Windows.Forms.Label();
            this.Opp2ChipText = new System.Windows.Forms.Label();
            this.Opp1ChipText = new System.Windows.Forms.Label();
            this.TopDeckCard = new System.Windows.Forms.PictureBox();
            this.GameDeckLabel = new System.Windows.Forms.Label();
            this.Opp1ChipCount = new System.Windows.Forms.Label();
            this.Opp2ChipCount = new System.Windows.Forms.Label();
            this.MainPlayerChipCount = new System.Windows.Forms.Label();
            this.Opp3ChipCount = new System.Windows.Forms.Label();
            this.Opp4ChipCount = new System.Windows.Forms.Label();
            this.Opp1Card8 = new System.Windows.Forms.PictureBox();
            this.Opp1Card7 = new System.Windows.Forms.PictureBox();
            this.Opp1Card6 = new System.Windows.Forms.PictureBox();
            this.Opp1Card5 = new System.Windows.Forms.PictureBox();
            this.Opp1Card12 = new System.Windows.Forms.PictureBox();
            this.Opp1Card11 = new System.Windows.Forms.PictureBox();
            this.Opp1Card10 = new System.Windows.Forms.PictureBox();
            this.Opp1Card9 = new System.Windows.Forms.PictureBox();
            this.Opp1Card16 = new System.Windows.Forms.PictureBox();
            this.Opp1Card15 = new System.Windows.Forms.PictureBox();
            this.Opp1Card14 = new System.Windows.Forms.PictureBox();
            this.Opp1Card13 = new System.Windows.Forms.PictureBox();
            this.DeckCard = new System.Windows.Forms.PictureBox();
            this.TopDeckCardNum = new System.Windows.Forms.Label();
            this.Opp1Num16 = new System.Windows.Forms.Label();
            this.Opp1Num15 = new System.Windows.Forms.Label();
            this.Opp1Num14 = new System.Windows.Forms.Label();
            this.Opp1Num13 = new System.Windows.Forms.Label();
            this.Opp1Num12 = new System.Windows.Forms.Label();
            this.Opp1Num11 = new System.Windows.Forms.Label();
            this.Opp1Num10 = new System.Windows.Forms.Label();
            this.Opp1Num9 = new System.Windows.Forms.Label();
            this.Opp1Num1 = new System.Windows.Forms.Label();
            this.Opp1Num2 = new System.Windows.Forms.Label();
            this.Opp1Num3 = new System.Windows.Forms.Label();
            this.Opp1Num4 = new System.Windows.Forms.Label();
            this.Opp1Num5 = new System.Windows.Forms.Label();
            this.Opp1Num6 = new System.Windows.Forms.Label();
            this.Opp1Num7 = new System.Windows.Forms.Label();
            this.Opp1Num8 = new System.Windows.Forms.Label();
            this.Opp2Num8 = new System.Windows.Forms.Label();
            this.Opp2Num7 = new System.Windows.Forms.Label();
            this.Opp2Num6 = new System.Windows.Forms.Label();
            this.Opp2Num5 = new System.Windows.Forms.Label();
            this.Opp2Num4 = new System.Windows.Forms.Label();
            this.Opp2Num3 = new System.Windows.Forms.Label();
            this.Opp2Num2 = new System.Windows.Forms.Label();
            this.Opp2Num1 = new System.Windows.Forms.Label();
            this.Opp2Num9 = new System.Windows.Forms.Label();
            this.Opp2Num10 = new System.Windows.Forms.Label();
            this.Opp2Num11 = new System.Windows.Forms.Label();
            this.Opp2Num12 = new System.Windows.Forms.Label();
            this.Opp2Num13 = new System.Windows.Forms.Label();
            this.Opp2Num14 = new System.Windows.Forms.Label();
            this.Opp2Num15 = new System.Windows.Forms.Label();
            this.Opp2Num16 = new System.Windows.Forms.Label();
            this.Opp2Card16 = new System.Windows.Forms.PictureBox();
            this.Opp2Card15 = new System.Windows.Forms.PictureBox();
            this.Opp2Card14 = new System.Windows.Forms.PictureBox();
            this.Opp2Card13 = new System.Windows.Forms.PictureBox();
            this.Opp2Card12 = new System.Windows.Forms.PictureBox();
            this.Opp2Card11 = new System.Windows.Forms.PictureBox();
            this.Opp2Card10 = new System.Windows.Forms.PictureBox();
            this.Opp2Card9 = new System.Windows.Forms.PictureBox();
            this.Opp2Card8 = new System.Windows.Forms.PictureBox();
            this.Opp2Card7 = new System.Windows.Forms.PictureBox();
            this.Opp2Card6 = new System.Windows.Forms.PictureBox();
            this.Opp2Card5 = new System.Windows.Forms.PictureBox();
            this.Opp2Card4 = new System.Windows.Forms.PictureBox();
            this.Opp2Card3 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Opp2Card2 = new System.Windows.Forms.PictureBox();
            this.Opp2Card1 = new System.Windows.Forms.PictureBox();
            this.Opp4Num8 = new System.Windows.Forms.Label();
            this.Opp4Num7 = new System.Windows.Forms.Label();
            this.Opp4Num6 = new System.Windows.Forms.Label();
            this.Opp4Num5 = new System.Windows.Forms.Label();
            this.Opp4Num4 = new System.Windows.Forms.Label();
            this.Opp4Num3 = new System.Windows.Forms.Label();
            this.Opp4Num2 = new System.Windows.Forms.Label();
            this.Opp4Num1 = new System.Windows.Forms.Label();
            this.Opp4Num9 = new System.Windows.Forms.Label();
            this.Opp4Num10 = new System.Windows.Forms.Label();
            this.Opp4Num11 = new System.Windows.Forms.Label();
            this.Opp4Num12 = new System.Windows.Forms.Label();
            this.Opp4Num13 = new System.Windows.Forms.Label();
            this.Opp4Num14 = new System.Windows.Forms.Label();
            this.Opp4Num15 = new System.Windows.Forms.Label();
            this.Opp4Num16 = new System.Windows.Forms.Label();
            this.Opp4Card16 = new System.Windows.Forms.PictureBox();
            this.Opp4Card15 = new System.Windows.Forms.PictureBox();
            this.Opp4Card14 = new System.Windows.Forms.PictureBox();
            this.Opp4Card13 = new System.Windows.Forms.PictureBox();
            this.Opp4Card12 = new System.Windows.Forms.PictureBox();
            this.Opp4Card11 = new System.Windows.Forms.PictureBox();
            this.Opp4Card10 = new System.Windows.Forms.PictureBox();
            this.Opp4Card9 = new System.Windows.Forms.PictureBox();
            this.Opp4Card8 = new System.Windows.Forms.PictureBox();
            this.Opp4Card7 = new System.Windows.Forms.PictureBox();
            this.Opp4Card6 = new System.Windows.Forms.PictureBox();
            this.Opp4Card5 = new System.Windows.Forms.PictureBox();
            this.Opp4Card4 = new System.Windows.Forms.PictureBox();
            this.Opp4Card3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Opp4Card2 = new System.Windows.Forms.PictureBox();
            this.Opp4Card1 = new System.Windows.Forms.PictureBox();
            this.Opp3Num8 = new System.Windows.Forms.Label();
            this.Opp3Num7 = new System.Windows.Forms.Label();
            this.Opp3Num6 = new System.Windows.Forms.Label();
            this.Opp3Num5 = new System.Windows.Forms.Label();
            this.Opp3Num4 = new System.Windows.Forms.Label();
            this.Opp3Num3 = new System.Windows.Forms.Label();
            this.Opp3Num2 = new System.Windows.Forms.Label();
            this.Opp3Num1 = new System.Windows.Forms.Label();
            this.Opp3Num9 = new System.Windows.Forms.Label();
            this.Opp3Num10 = new System.Windows.Forms.Label();
            this.Opp3Num11 = new System.Windows.Forms.Label();
            this.Opp3Num12 = new System.Windows.Forms.Label();
            this.Opp3Num13 = new System.Windows.Forms.Label();
            this.Opp3Num14 = new System.Windows.Forms.Label();
            this.Opp3Num15 = new System.Windows.Forms.Label();
            this.Opp3Num16 = new System.Windows.Forms.Label();
            this.Opp3Card16 = new System.Windows.Forms.PictureBox();
            this.Opp3Card15 = new System.Windows.Forms.PictureBox();
            this.Opp3Card14 = new System.Windows.Forms.PictureBox();
            this.Opp3Card13 = new System.Windows.Forms.PictureBox();
            this.Opp3Card12 = new System.Windows.Forms.PictureBox();
            this.Opp3Card11 = new System.Windows.Forms.PictureBox();
            this.Opp3Card10 = new System.Windows.Forms.PictureBox();
            this.Opp3Card9 = new System.Windows.Forms.PictureBox();
            this.Opp3Card8 = new System.Windows.Forms.PictureBox();
            this.Opp3Card7 = new System.Windows.Forms.PictureBox();
            this.Opp3Card6 = new System.Windows.Forms.PictureBox();
            this.Opp3Card5 = new System.Windows.Forms.PictureBox();
            this.Opp3Card4 = new System.Windows.Forms.PictureBox();
            this.Opp3Card3 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Opp3Card2 = new System.Windows.Forms.PictureBox();
            this.Opp3Card1 = new System.Windows.Forms.PictureBox();
            this.MainPlayerNum8 = new System.Windows.Forms.Label();
            this.MainPlayerNum7 = new System.Windows.Forms.Label();
            this.MainPlayerNum6 = new System.Windows.Forms.Label();
            this.MainPlayerNum5 = new System.Windows.Forms.Label();
            this.MainPlayerNum4 = new System.Windows.Forms.Label();
            this.MainPlayerNum3 = new System.Windows.Forms.Label();
            this.MainPlayerNum2 = new System.Windows.Forms.Label();
            this.MainPlayerNum1 = new System.Windows.Forms.Label();
            this.MainPlayerNum9 = new System.Windows.Forms.Label();
            this.MainPlayerNum10 = new System.Windows.Forms.Label();
            this.MainPlayerNum11 = new System.Windows.Forms.Label();
            this.MainPlayerNum12 = new System.Windows.Forms.Label();
            this.MainPlayerNum13 = new System.Windows.Forms.Label();
            this.MainPlayerNum14 = new System.Windows.Forms.Label();
            this.MainPlayerNum15 = new System.Windows.Forms.Label();
            this.MainPlayerNum16 = new System.Windows.Forms.Label();
            this.MainPlayerCard16 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard15 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard14 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard13 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard12 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard11 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard10 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard9 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard8 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard7 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard6 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard5 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard4 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard3 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.MainPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.MainPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.AcceptCardButton = new System.Windows.Forms.Button();
            this.NoGraciasButton = new System.Windows.Forms.Button();
            this.DeckChip = new System.Windows.Forms.PictureBox();
            this.TopDeckChipCounter = new System.Windows.Forms.Label();
            this.TopDeckChipText = new System.Windows.Forms.Label();
            this.TurnStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opp3ChipGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opp4ChipGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopDeckCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckChip)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPlayerName
            // 
            resources.ApplyResources(this.MainPlayerName, "MainPlayerName");
            this.MainPlayerName.BackColor = System.Drawing.Color.LemonChiffon;
            this.MainPlayerName.Name = "MainPlayerName";
            // 
            // Opp2Name
            // 
            resources.ApplyResources(this.Opp2Name, "Opp2Name");
            this.Opp2Name.BackColor = System.Drawing.Color.LemonChiffon;
            this.Opp2Name.Name = "Opp2Name";
            this.Opp2Name.Click += new System.EventHandler(this.label2_Click);
            // 
            // Opp1Name
            // 
            resources.ApplyResources(this.Opp1Name, "Opp1Name");
            this.Opp1Name.BackColor = System.Drawing.Color.LemonChiffon;
            this.Opp1Name.Name = "Opp1Name";
            this.Opp1Name.Click += new System.EventHandler(this.label3_Click);
            // 
            // Opp1Card3
            // 
            this.Opp1Card3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card3, "Opp1Card3");
            this.Opp1Card3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card3.Name = "Opp1Card3";
            this.Opp1Card3.TabStop = false;
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // Opp1Card2
            // 
            this.Opp1Card2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card2, "Opp1Card2");
            this.Opp1Card2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card2.Name = "Opp1Card2";
            this.Opp1Card2.TabStop = false;
            // 
            // Opp1Card1
            // 
            this.Opp1Card1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card1, "Opp1Card1");
            this.Opp1Card1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card1.Name = "Opp1Card1";
            this.Opp1Card1.TabStop = false;
            // 
            // Opp4Name
            // 
            resources.ApplyResources(this.Opp4Name, "Opp4Name");
            this.Opp4Name.BackColor = System.Drawing.Color.LemonChiffon;
            this.Opp4Name.Name = "Opp4Name";
            // 
            // Opp3Name
            // 
            resources.ApplyResources(this.Opp3Name, "Opp3Name");
            this.Opp3Name.BackColor = System.Drawing.Color.LemonChiffon;
            this.Opp3Name.Name = "Opp3Name";
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox16, "pictureBox16");
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox17, "pictureBox17");
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.TabStop = false;
            this.pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox18, "pictureBox18");
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.TabStop = false;
            // 
            // opp3ChipGraphic
            // 
            this.opp3ChipGraphic.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.opp3ChipGraphic, "opp3ChipGraphic");
            this.opp3ChipGraphic.Name = "opp3ChipGraphic";
            this.opp3ChipGraphic.TabStop = false;
            // 
            // Opp1Card4
            // 
            this.Opp1Card4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card4, "Opp1Card4");
            this.Opp1Card4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card4.Name = "Opp1Card4";
            this.Opp1Card4.TabStop = false;
            // 
            // opp4ChipGraphic
            // 
            this.opp4ChipGraphic.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.opp4ChipGraphic, "opp4ChipGraphic");
            this.opp4ChipGraphic.Name = "opp4ChipGraphic";
            this.opp4ChipGraphic.TabStop = false;
            // 
            // Opp4ChipText
            // 
            resources.ApplyResources(this.Opp4ChipText, "Opp4ChipText");
            this.Opp4ChipText.Name = "Opp4ChipText";
            this.Opp4ChipText.Click += new System.EventHandler(this.label6_Click);
            // 
            // Opp3ChipText
            // 
            resources.ApplyResources(this.Opp3ChipText, "Opp3ChipText");
            this.Opp3ChipText.Name = "Opp3ChipText";
            // 
            // MainPlayerChipText
            // 
            resources.ApplyResources(this.MainPlayerChipText, "MainPlayerChipText");
            this.MainPlayerChipText.Name = "MainPlayerChipText";
            // 
            // Opp2ChipText
            // 
            resources.ApplyResources(this.Opp2ChipText, "Opp2ChipText");
            this.Opp2ChipText.Name = "Opp2ChipText";
            this.Opp2ChipText.Click += new System.EventHandler(this.Opp2ChipText_Click);
            // 
            // Opp1ChipText
            // 
            resources.ApplyResources(this.Opp1ChipText, "Opp1ChipText");
            this.Opp1ChipText.Name = "Opp1ChipText";
            // 
            // TopDeckCard
            // 
            this.TopDeckCard.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TopDeckCard, "TopDeckCard");
            this.TopDeckCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TopDeckCard.Name = "TopDeckCard";
            this.TopDeckCard.TabStop = false;
            // 
            // GameDeckLabel
            // 
            resources.ApplyResources(this.GameDeckLabel, "GameDeckLabel");
            this.GameDeckLabel.BackColor = System.Drawing.Color.LemonChiffon;
            this.GameDeckLabel.Name = "GameDeckLabel";
            // 
            // Opp1ChipCount
            // 
            resources.ApplyResources(this.Opp1ChipCount, "Opp1ChipCount");
            this.Opp1ChipCount.Name = "Opp1ChipCount";
            this.Opp1ChipCount.Click += new System.EventHandler(this.label12_Click);
            // 
            // Opp2ChipCount
            // 
            resources.ApplyResources(this.Opp2ChipCount, "Opp2ChipCount");
            this.Opp2ChipCount.Name = "Opp2ChipCount";
            this.Opp2ChipCount.Click += new System.EventHandler(this.Opp2ChipCount_Click);
            // 
            // MainPlayerChipCount
            // 
            resources.ApplyResources(this.MainPlayerChipCount, "MainPlayerChipCount");
            this.MainPlayerChipCount.Name = "MainPlayerChipCount";
            // 
            // Opp3ChipCount
            // 
            resources.ApplyResources(this.Opp3ChipCount, "Opp3ChipCount");
            this.Opp3ChipCount.Name = "Opp3ChipCount";
            // 
            // Opp4ChipCount
            // 
            resources.ApplyResources(this.Opp4ChipCount, "Opp4ChipCount");
            this.Opp4ChipCount.Name = "Opp4ChipCount";
            // 
            // Opp1Card8
            // 
            this.Opp1Card8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card8, "Opp1Card8");
            this.Opp1Card8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card8.Name = "Opp1Card8";
            this.Opp1Card8.TabStop = false;
            // 
            // Opp1Card7
            // 
            this.Opp1Card7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card7, "Opp1Card7");
            this.Opp1Card7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card7.Name = "Opp1Card7";
            this.Opp1Card7.TabStop = false;
            // 
            // Opp1Card6
            // 
            this.Opp1Card6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card6, "Opp1Card6");
            this.Opp1Card6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card6.Name = "Opp1Card6";
            this.Opp1Card6.TabStop = false;
            // 
            // Opp1Card5
            // 
            this.Opp1Card5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card5, "Opp1Card5");
            this.Opp1Card5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card5.Name = "Opp1Card5";
            this.Opp1Card5.TabStop = false;
            // 
            // Opp1Card12
            // 
            this.Opp1Card12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card12, "Opp1Card12");
            this.Opp1Card12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card12.Name = "Opp1Card12";
            this.Opp1Card12.TabStop = false;
            // 
            // Opp1Card11
            // 
            this.Opp1Card11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card11, "Opp1Card11");
            this.Opp1Card11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card11.Name = "Opp1Card11";
            this.Opp1Card11.TabStop = false;
            // 
            // Opp1Card10
            // 
            this.Opp1Card10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card10, "Opp1Card10");
            this.Opp1Card10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card10.Name = "Opp1Card10";
            this.Opp1Card10.TabStop = false;
            // 
            // Opp1Card9
            // 
            this.Opp1Card9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card9, "Opp1Card9");
            this.Opp1Card9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card9.Name = "Opp1Card9";
            this.Opp1Card9.TabStop = false;
            // 
            // Opp1Card16
            // 
            this.Opp1Card16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card16, "Opp1Card16");
            this.Opp1Card16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card16.Name = "Opp1Card16";
            this.Opp1Card16.TabStop = false;
            // 
            // Opp1Card15
            // 
            this.Opp1Card15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card15, "Opp1Card15");
            this.Opp1Card15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card15.Name = "Opp1Card15";
            this.Opp1Card15.TabStop = false;
            // 
            // Opp1Card14
            // 
            this.Opp1Card14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card14, "Opp1Card14");
            this.Opp1Card14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card14.Name = "Opp1Card14";
            this.Opp1Card14.TabStop = false;
            // 
            // Opp1Card13
            // 
            this.Opp1Card13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Card13, "Opp1Card13");
            this.Opp1Card13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp1Card13.Name = "Opp1Card13";
            this.Opp1Card13.TabStop = false;
            // 
            // DeckCard
            // 
            resources.ApplyResources(this.DeckCard, "DeckCard");
            this.DeckCard.Name = "DeckCard";
            this.DeckCard.TabStop = false;
            // 
            // TopDeckCardNum
            // 
            this.TopDeckCardNum.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TopDeckCardNum, "TopDeckCardNum");
            this.TopDeckCardNum.Name = "TopDeckCardNum";
            // 
            // Opp1Num16
            // 
            this.Opp1Num16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num16, "Opp1Num16");
            this.Opp1Num16.Name = "Opp1Num16";
            // 
            // Opp1Num15
            // 
            this.Opp1Num15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num15, "Opp1Num15");
            this.Opp1Num15.Name = "Opp1Num15";
            // 
            // Opp1Num14
            // 
            this.Opp1Num14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num14, "Opp1Num14");
            this.Opp1Num14.Name = "Opp1Num14";
            // 
            // Opp1Num13
            // 
            this.Opp1Num13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num13, "Opp1Num13");
            this.Opp1Num13.Name = "Opp1Num13";
            // 
            // Opp1Num12
            // 
            this.Opp1Num12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num12, "Opp1Num12");
            this.Opp1Num12.Name = "Opp1Num12";
            // 
            // Opp1Num11
            // 
            this.Opp1Num11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num11, "Opp1Num11");
            this.Opp1Num11.Name = "Opp1Num11";
            // 
            // Opp1Num10
            // 
            this.Opp1Num10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num10, "Opp1Num10");
            this.Opp1Num10.Name = "Opp1Num10";
            // 
            // Opp1Num9
            // 
            this.Opp1Num9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num9, "Opp1Num9");
            this.Opp1Num9.Name = "Opp1Num9";
            // 
            // Opp1Num1
            // 
            this.Opp1Num1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num1, "Opp1Num1");
            this.Opp1Num1.Name = "Opp1Num1";
            // 
            // Opp1Num2
            // 
            this.Opp1Num2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num2, "Opp1Num2");
            this.Opp1Num2.Name = "Opp1Num2";
            // 
            // Opp1Num3
            // 
            this.Opp1Num3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num3, "Opp1Num3");
            this.Opp1Num3.Name = "Opp1Num3";
            // 
            // Opp1Num4
            // 
            this.Opp1Num4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num4, "Opp1Num4");
            this.Opp1Num4.Name = "Opp1Num4";
            // 
            // Opp1Num5
            // 
            this.Opp1Num5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num5, "Opp1Num5");
            this.Opp1Num5.Name = "Opp1Num5";
            // 
            // Opp1Num6
            // 
            this.Opp1Num6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num6, "Opp1Num6");
            this.Opp1Num6.Name = "Opp1Num6";
            // 
            // Opp1Num7
            // 
            this.Opp1Num7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num7, "Opp1Num7");
            this.Opp1Num7.Name = "Opp1Num7";
            // 
            // Opp1Num8
            // 
            this.Opp1Num8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp1Num8, "Opp1Num8");
            this.Opp1Num8.Name = "Opp1Num8";
            // 
            // Opp2Num8
            // 
            this.Opp2Num8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num8, "Opp2Num8");
            this.Opp2Num8.Name = "Opp2Num8";
            this.Opp2Num8.Click += new System.EventHandler(this.Opp2Num8_Click);
            // 
            // Opp2Num7
            // 
            this.Opp2Num7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num7, "Opp2Num7");
            this.Opp2Num7.Name = "Opp2Num7";
            this.Opp2Num7.Click += new System.EventHandler(this.Opp2Num7_Click);
            // 
            // Opp2Num6
            // 
            this.Opp2Num6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num6, "Opp2Num6");
            this.Opp2Num6.Name = "Opp2Num6";
            this.Opp2Num6.Click += new System.EventHandler(this.Opp2Num6_Click);
            // 
            // Opp2Num5
            // 
            this.Opp2Num5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num5, "Opp2Num5");
            this.Opp2Num5.Name = "Opp2Num5";
            this.Opp2Num5.Click += new System.EventHandler(this.Opp2Num5_Click);
            // 
            // Opp2Num4
            // 
            this.Opp2Num4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num4, "Opp2Num4");
            this.Opp2Num4.Name = "Opp2Num4";
            this.Opp2Num4.Click += new System.EventHandler(this.Opp2Num4_Click);
            // 
            // Opp2Num3
            // 
            this.Opp2Num3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num3, "Opp2Num3");
            this.Opp2Num3.Name = "Opp2Num3";
            this.Opp2Num3.Click += new System.EventHandler(this.Opp2Num3_Click);
            // 
            // Opp2Num2
            // 
            this.Opp2Num2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num2, "Opp2Num2");
            this.Opp2Num2.Name = "Opp2Num2";
            this.Opp2Num2.Click += new System.EventHandler(this.Opp2Num2_Click);
            // 
            // Opp2Num1
            // 
            this.Opp2Num1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num1, "Opp2Num1");
            this.Opp2Num1.Name = "Opp2Num1";
            this.Opp2Num1.Click += new System.EventHandler(this.Opp2Num1_Click);
            // 
            // Opp2Num9
            // 
            this.Opp2Num9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num9, "Opp2Num9");
            this.Opp2Num9.Name = "Opp2Num9";
            this.Opp2Num9.Click += new System.EventHandler(this.Opp2Num9_Click);
            // 
            // Opp2Num10
            // 
            this.Opp2Num10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num10, "Opp2Num10");
            this.Opp2Num10.Name = "Opp2Num10";
            this.Opp2Num10.Click += new System.EventHandler(this.Opp2Num10_Click);
            // 
            // Opp2Num11
            // 
            this.Opp2Num11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num11, "Opp2Num11");
            this.Opp2Num11.Name = "Opp2Num11";
            this.Opp2Num11.Click += new System.EventHandler(this.Opp2Num11_Click);
            // 
            // Opp2Num12
            // 
            this.Opp2Num12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num12, "Opp2Num12");
            this.Opp2Num12.Name = "Opp2Num12";
            this.Opp2Num12.Click += new System.EventHandler(this.Opp2Num12_Click);
            // 
            // Opp2Num13
            // 
            this.Opp2Num13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num13, "Opp2Num13");
            this.Opp2Num13.Name = "Opp2Num13";
            this.Opp2Num13.Click += new System.EventHandler(this.Opp2Num13_Click);
            // 
            // Opp2Num14
            // 
            this.Opp2Num14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num14, "Opp2Num14");
            this.Opp2Num14.Name = "Opp2Num14";
            this.Opp2Num14.Click += new System.EventHandler(this.Opp2Num14_Click);
            // 
            // Opp2Num15
            // 
            this.Opp2Num15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num15, "Opp2Num15");
            this.Opp2Num15.Name = "Opp2Num15";
            this.Opp2Num15.Click += new System.EventHandler(this.Opp2Num15_Click);
            // 
            // Opp2Num16
            // 
            this.Opp2Num16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Num16, "Opp2Num16");
            this.Opp2Num16.Name = "Opp2Num16";
            this.Opp2Num16.Click += new System.EventHandler(this.Opp2Num16_Click);
            // 
            // Opp2Card16
            // 
            this.Opp2Card16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card16, "Opp2Card16");
            this.Opp2Card16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card16.Name = "Opp2Card16";
            this.Opp2Card16.TabStop = false;
            this.Opp2Card16.Click += new System.EventHandler(this.Opp2Card16_Click);
            // 
            // Opp2Card15
            // 
            this.Opp2Card15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card15, "Opp2Card15");
            this.Opp2Card15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card15.Name = "Opp2Card15";
            this.Opp2Card15.TabStop = false;
            this.Opp2Card15.Click += new System.EventHandler(this.Opp2Card15_Click);
            // 
            // Opp2Card14
            // 
            this.Opp2Card14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card14, "Opp2Card14");
            this.Opp2Card14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card14.Name = "Opp2Card14";
            this.Opp2Card14.TabStop = false;
            this.Opp2Card14.Click += new System.EventHandler(this.Opp2Card14_Click);
            // 
            // Opp2Card13
            // 
            this.Opp2Card13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card13, "Opp2Card13");
            this.Opp2Card13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card13.Name = "Opp2Card13";
            this.Opp2Card13.TabStop = false;
            this.Opp2Card13.Click += new System.EventHandler(this.Opp2Card13_Click);
            // 
            // Opp2Card12
            // 
            this.Opp2Card12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card12, "Opp2Card12");
            this.Opp2Card12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card12.Name = "Opp2Card12";
            this.Opp2Card12.TabStop = false;
            this.Opp2Card12.Click += new System.EventHandler(this.Opp2Card12_Click);
            // 
            // Opp2Card11
            // 
            this.Opp2Card11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card11, "Opp2Card11");
            this.Opp2Card11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card11.Name = "Opp2Card11";
            this.Opp2Card11.TabStop = false;
            this.Opp2Card11.Click += new System.EventHandler(this.Opp2Card11_Click);
            // 
            // Opp2Card10
            // 
            this.Opp2Card10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card10, "Opp2Card10");
            this.Opp2Card10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card10.Name = "Opp2Card10";
            this.Opp2Card10.TabStop = false;
            this.Opp2Card10.Click += new System.EventHandler(this.Opp2Card10_Click);
            // 
            // Opp2Card9
            // 
            this.Opp2Card9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card9, "Opp2Card9");
            this.Opp2Card9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card9.Name = "Opp2Card9";
            this.Opp2Card9.TabStop = false;
            this.Opp2Card9.Click += new System.EventHandler(this.Opp2Card9_Click);
            // 
            // Opp2Card8
            // 
            this.Opp2Card8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card8, "Opp2Card8");
            this.Opp2Card8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card8.Name = "Opp2Card8";
            this.Opp2Card8.TabStop = false;
            this.Opp2Card8.Click += new System.EventHandler(this.Opp2Card8_Click);
            // 
            // Opp2Card7
            // 
            this.Opp2Card7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card7, "Opp2Card7");
            this.Opp2Card7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card7.Name = "Opp2Card7";
            this.Opp2Card7.TabStop = false;
            this.Opp2Card7.Click += new System.EventHandler(this.Opp2Card7_Click);
            // 
            // Opp2Card6
            // 
            this.Opp2Card6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card6, "Opp2Card6");
            this.Opp2Card6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card6.Name = "Opp2Card6";
            this.Opp2Card6.TabStop = false;
            this.Opp2Card6.Click += new System.EventHandler(this.Opp2Card6_Click);
            // 
            // Opp2Card5
            // 
            this.Opp2Card5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card5, "Opp2Card5");
            this.Opp2Card5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card5.Name = "Opp2Card5";
            this.Opp2Card5.TabStop = false;
            this.Opp2Card5.Click += new System.EventHandler(this.Opp2Card5_Click);
            // 
            // Opp2Card4
            // 
            this.Opp2Card4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card4, "Opp2Card4");
            this.Opp2Card4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card4.Name = "Opp2Card4";
            this.Opp2Card4.TabStop = false;
            this.Opp2Card4.Click += new System.EventHandler(this.Opp2Card4_Click);
            // 
            // Opp2Card3
            // 
            this.Opp2Card3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card3, "Opp2Card3");
            this.Opp2Card3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card3.Name = "Opp2Card3";
            this.Opp2Card3.TabStop = false;
            this.Opp2Card3.Click += new System.EventHandler(this.Opp2Card3_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_2);
            // 
            // Opp2Card2
            // 
            this.Opp2Card2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card2, "Opp2Card2");
            this.Opp2Card2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card2.Name = "Opp2Card2";
            this.Opp2Card2.TabStop = false;
            this.Opp2Card2.Click += new System.EventHandler(this.Opp2Card2_Click);
            // 
            // Opp2Card1
            // 
            this.Opp2Card1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp2Card1, "Opp2Card1");
            this.Opp2Card1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp2Card1.Name = "Opp2Card1";
            this.Opp2Card1.TabStop = false;
            this.Opp2Card1.Click += new System.EventHandler(this.Opp2Card1_Click);
            // 
            // Opp4Num8
            // 
            this.Opp4Num8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num8, "Opp4Num8");
            this.Opp4Num8.Name = "Opp4Num8";
            this.Opp4Num8.Click += new System.EventHandler(this.label33_Click);
            // 
            // Opp4Num7
            // 
            this.Opp4Num7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num7, "Opp4Num7");
            this.Opp4Num7.Name = "Opp4Num7";
            // 
            // Opp4Num6
            // 
            this.Opp4Num6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num6, "Opp4Num6");
            this.Opp4Num6.Name = "Opp4Num6";
            // 
            // Opp4Num5
            // 
            this.Opp4Num5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num5, "Opp4Num5");
            this.Opp4Num5.Name = "Opp4Num5";
            // 
            // Opp4Num4
            // 
            this.Opp4Num4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num4, "Opp4Num4");
            this.Opp4Num4.Name = "Opp4Num4";
            // 
            // Opp4Num3
            // 
            this.Opp4Num3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num3, "Opp4Num3");
            this.Opp4Num3.Name = "Opp4Num3";
            // 
            // Opp4Num2
            // 
            this.Opp4Num2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num2, "Opp4Num2");
            this.Opp4Num2.Name = "Opp4Num2";
            // 
            // Opp4Num1
            // 
            this.Opp4Num1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num1, "Opp4Num1");
            this.Opp4Num1.Name = "Opp4Num1";
            // 
            // Opp4Num9
            // 
            this.Opp4Num9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num9, "Opp4Num9");
            this.Opp4Num9.Name = "Opp4Num9";
            // 
            // Opp4Num10
            // 
            this.Opp4Num10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num10, "Opp4Num10");
            this.Opp4Num10.Name = "Opp4Num10";
            // 
            // Opp4Num11
            // 
            this.Opp4Num11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num11, "Opp4Num11");
            this.Opp4Num11.Name = "Opp4Num11";
            // 
            // Opp4Num12
            // 
            this.Opp4Num12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num12, "Opp4Num12");
            this.Opp4Num12.Name = "Opp4Num12";
            // 
            // Opp4Num13
            // 
            this.Opp4Num13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num13, "Opp4Num13");
            this.Opp4Num13.Name = "Opp4Num13";
            // 
            // Opp4Num14
            // 
            this.Opp4Num14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num14, "Opp4Num14");
            this.Opp4Num14.Name = "Opp4Num14";
            // 
            // Opp4Num15
            // 
            this.Opp4Num15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num15, "Opp4Num15");
            this.Opp4Num15.Name = "Opp4Num15";
            // 
            // Opp4Num16
            // 
            this.Opp4Num16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Num16, "Opp4Num16");
            this.Opp4Num16.Name = "Opp4Num16";
            // 
            // Opp4Card16
            // 
            this.Opp4Card16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card16, "Opp4Card16");
            this.Opp4Card16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card16.Name = "Opp4Card16";
            this.Opp4Card16.TabStop = false;
            // 
            // Opp4Card15
            // 
            this.Opp4Card15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card15, "Opp4Card15");
            this.Opp4Card15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card15.Name = "Opp4Card15";
            this.Opp4Card15.TabStop = false;
            // 
            // Opp4Card14
            // 
            this.Opp4Card14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card14, "Opp4Card14");
            this.Opp4Card14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card14.Name = "Opp4Card14";
            this.Opp4Card14.TabStop = false;
            // 
            // Opp4Card13
            // 
            this.Opp4Card13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card13, "Opp4Card13");
            this.Opp4Card13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card13.Name = "Opp4Card13";
            this.Opp4Card13.TabStop = false;
            // 
            // Opp4Card12
            // 
            this.Opp4Card12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card12, "Opp4Card12");
            this.Opp4Card12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card12.Name = "Opp4Card12";
            this.Opp4Card12.TabStop = false;
            // 
            // Opp4Card11
            // 
            this.Opp4Card11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card11, "Opp4Card11");
            this.Opp4Card11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card11.Name = "Opp4Card11";
            this.Opp4Card11.TabStop = false;
            // 
            // Opp4Card10
            // 
            this.Opp4Card10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card10, "Opp4Card10");
            this.Opp4Card10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card10.Name = "Opp4Card10";
            this.Opp4Card10.TabStop = false;
            // 
            // Opp4Card9
            // 
            this.Opp4Card9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card9, "Opp4Card9");
            this.Opp4Card9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card9.Name = "Opp4Card9";
            this.Opp4Card9.TabStop = false;
            // 
            // Opp4Card8
            // 
            this.Opp4Card8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card8, "Opp4Card8");
            this.Opp4Card8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card8.Name = "Opp4Card8";
            this.Opp4Card8.TabStop = false;
            // 
            // Opp4Card7
            // 
            this.Opp4Card7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card7, "Opp4Card7");
            this.Opp4Card7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card7.Name = "Opp4Card7";
            this.Opp4Card7.TabStop = false;
            // 
            // Opp4Card6
            // 
            this.Opp4Card6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card6, "Opp4Card6");
            this.Opp4Card6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card6.Name = "Opp4Card6";
            this.Opp4Card6.TabStop = false;
            // 
            // Opp4Card5
            // 
            this.Opp4Card5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card5, "Opp4Card5");
            this.Opp4Card5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card5.Name = "Opp4Card5";
            this.Opp4Card5.TabStop = false;
            // 
            // Opp4Card4
            // 
            this.Opp4Card4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card4, "Opp4Card4");
            this.Opp4Card4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card4.Name = "Opp4Card4";
            this.Opp4Card4.TabStop = false;
            // 
            // Opp4Card3
            // 
            this.Opp4Card3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card3, "Opp4Card3");
            this.Opp4Card3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card3.Name = "Opp4Card3";
            this.Opp4Card3.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // Opp4Card2
            // 
            this.Opp4Card2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card2, "Opp4Card2");
            this.Opp4Card2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card2.Name = "Opp4Card2";
            this.Opp4Card2.TabStop = false;
            // 
            // Opp4Card1
            // 
            this.Opp4Card1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp4Card1, "Opp4Card1");
            this.Opp4Card1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp4Card1.Name = "Opp4Card1";
            this.Opp4Card1.TabStop = false;
            // 
            // Opp3Num8
            // 
            this.Opp3Num8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num8, "Opp3Num8");
            this.Opp3Num8.Name = "Opp3Num8";
            // 
            // Opp3Num7
            // 
            this.Opp3Num7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num7, "Opp3Num7");
            this.Opp3Num7.Name = "Opp3Num7";
            // 
            // Opp3Num6
            // 
            this.Opp3Num6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num6, "Opp3Num6");
            this.Opp3Num6.Name = "Opp3Num6";
            // 
            // Opp3Num5
            // 
            this.Opp3Num5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num5, "Opp3Num5");
            this.Opp3Num5.Name = "Opp3Num5";
            // 
            // Opp3Num4
            // 
            this.Opp3Num4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num4, "Opp3Num4");
            this.Opp3Num4.Name = "Opp3Num4";
            // 
            // Opp3Num3
            // 
            this.Opp3Num3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num3, "Opp3Num3");
            this.Opp3Num3.Name = "Opp3Num3";
            // 
            // Opp3Num2
            // 
            this.Opp3Num2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num2, "Opp3Num2");
            this.Opp3Num2.Name = "Opp3Num2";
            // 
            // Opp3Num1
            // 
            this.Opp3Num1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num1, "Opp3Num1");
            this.Opp3Num1.Name = "Opp3Num1";
            // 
            // Opp3Num9
            // 
            this.Opp3Num9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num9, "Opp3Num9");
            this.Opp3Num9.Name = "Opp3Num9";
            // 
            // Opp3Num10
            // 
            this.Opp3Num10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num10, "Opp3Num10");
            this.Opp3Num10.Name = "Opp3Num10";
            // 
            // Opp3Num11
            // 
            this.Opp3Num11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num11, "Opp3Num11");
            this.Opp3Num11.Name = "Opp3Num11";
            // 
            // Opp3Num12
            // 
            this.Opp3Num12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num12, "Opp3Num12");
            this.Opp3Num12.Name = "Opp3Num12";
            // 
            // Opp3Num13
            // 
            this.Opp3Num13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num13, "Opp3Num13");
            this.Opp3Num13.Name = "Opp3Num13";
            // 
            // Opp3Num14
            // 
            this.Opp3Num14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num14, "Opp3Num14");
            this.Opp3Num14.Name = "Opp3Num14";
            // 
            // Opp3Num15
            // 
            this.Opp3Num15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num15, "Opp3Num15");
            this.Opp3Num15.Name = "Opp3Num15";
            // 
            // Opp3Num16
            // 
            this.Opp3Num16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Num16, "Opp3Num16");
            this.Opp3Num16.Name = "Opp3Num16";
            // 
            // Opp3Card16
            // 
            this.Opp3Card16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card16, "Opp3Card16");
            this.Opp3Card16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card16.Name = "Opp3Card16";
            this.Opp3Card16.TabStop = false;
            // 
            // Opp3Card15
            // 
            this.Opp3Card15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card15, "Opp3Card15");
            this.Opp3Card15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card15.Name = "Opp3Card15";
            this.Opp3Card15.TabStop = false;
            // 
            // Opp3Card14
            // 
            this.Opp3Card14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card14, "Opp3Card14");
            this.Opp3Card14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card14.Name = "Opp3Card14";
            this.Opp3Card14.TabStop = false;
            // 
            // Opp3Card13
            // 
            this.Opp3Card13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card13, "Opp3Card13");
            this.Opp3Card13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card13.Name = "Opp3Card13";
            this.Opp3Card13.TabStop = false;
            // 
            // Opp3Card12
            // 
            this.Opp3Card12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card12, "Opp3Card12");
            this.Opp3Card12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card12.Name = "Opp3Card12";
            this.Opp3Card12.TabStop = false;
            // 
            // Opp3Card11
            // 
            this.Opp3Card11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card11, "Opp3Card11");
            this.Opp3Card11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card11.Name = "Opp3Card11";
            this.Opp3Card11.TabStop = false;
            // 
            // Opp3Card10
            // 
            this.Opp3Card10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card10, "Opp3Card10");
            this.Opp3Card10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card10.Name = "Opp3Card10";
            this.Opp3Card10.TabStop = false;
            // 
            // Opp3Card9
            // 
            this.Opp3Card9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card9, "Opp3Card9");
            this.Opp3Card9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card9.Name = "Opp3Card9";
            this.Opp3Card9.TabStop = false;
            // 
            // Opp3Card8
            // 
            this.Opp3Card8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card8, "Opp3Card8");
            this.Opp3Card8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card8.Name = "Opp3Card8";
            this.Opp3Card8.TabStop = false;
            // 
            // Opp3Card7
            // 
            this.Opp3Card7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card7, "Opp3Card7");
            this.Opp3Card7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card7.Name = "Opp3Card7";
            this.Opp3Card7.TabStop = false;
            // 
            // Opp3Card6
            // 
            this.Opp3Card6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card6, "Opp3Card6");
            this.Opp3Card6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card6.Name = "Opp3Card6";
            this.Opp3Card6.TabStop = false;
            // 
            // Opp3Card5
            // 
            this.Opp3Card5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card5, "Opp3Card5");
            this.Opp3Card5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card5.Name = "Opp3Card5";
            this.Opp3Card5.TabStop = false;
            // 
            // Opp3Card4
            // 
            this.Opp3Card4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card4, "Opp3Card4");
            this.Opp3Card4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card4.Name = "Opp3Card4";
            this.Opp3Card4.TabStop = false;
            // 
            // Opp3Card3
            // 
            this.Opp3Card3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card3, "Opp3Card3");
            this.Opp3Card3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card3.Name = "Opp3Card3";
            this.Opp3Card3.TabStop = false;
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // Opp3Card2
            // 
            this.Opp3Card2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card2, "Opp3Card2");
            this.Opp3Card2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card2.Name = "Opp3Card2";
            this.Opp3Card2.TabStop = false;
            // 
            // Opp3Card1
            // 
            this.Opp3Card1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Opp3Card1, "Opp3Card1");
            this.Opp3Card1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Opp3Card1.Name = "Opp3Card1";
            this.Opp3Card1.TabStop = false;
            // 
            // MainPlayerNum8
            // 
            this.MainPlayerNum8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum8, "MainPlayerNum8");
            this.MainPlayerNum8.Name = "MainPlayerNum8";
            // 
            // MainPlayerNum7
            // 
            this.MainPlayerNum7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum7, "MainPlayerNum7");
            this.MainPlayerNum7.Name = "MainPlayerNum7";
            // 
            // MainPlayerNum6
            // 
            this.MainPlayerNum6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum6, "MainPlayerNum6");
            this.MainPlayerNum6.Name = "MainPlayerNum6";
            // 
            // MainPlayerNum5
            // 
            this.MainPlayerNum5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum5, "MainPlayerNum5");
            this.MainPlayerNum5.Name = "MainPlayerNum5";
            // 
            // MainPlayerNum4
            // 
            this.MainPlayerNum4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum4, "MainPlayerNum4");
            this.MainPlayerNum4.Name = "MainPlayerNum4";
            // 
            // MainPlayerNum3
            // 
            this.MainPlayerNum3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum3, "MainPlayerNum3");
            this.MainPlayerNum3.Name = "MainPlayerNum3";
            // 
            // MainPlayerNum2
            // 
            this.MainPlayerNum2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum2, "MainPlayerNum2");
            this.MainPlayerNum2.Name = "MainPlayerNum2";
            // 
            // MainPlayerNum1
            // 
            this.MainPlayerNum1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum1, "MainPlayerNum1");
            this.MainPlayerNum1.Name = "MainPlayerNum1";
            // 
            // MainPlayerNum9
            // 
            this.MainPlayerNum9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum9, "MainPlayerNum9");
            this.MainPlayerNum9.Name = "MainPlayerNum9";
            // 
            // MainPlayerNum10
            // 
            this.MainPlayerNum10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum10, "MainPlayerNum10");
            this.MainPlayerNum10.Name = "MainPlayerNum10";
            // 
            // MainPlayerNum11
            // 
            this.MainPlayerNum11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum11, "MainPlayerNum11");
            this.MainPlayerNum11.Name = "MainPlayerNum11";
            // 
            // MainPlayerNum12
            // 
            this.MainPlayerNum12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum12, "MainPlayerNum12");
            this.MainPlayerNum12.Name = "MainPlayerNum12";
            // 
            // MainPlayerNum13
            // 
            this.MainPlayerNum13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum13, "MainPlayerNum13");
            this.MainPlayerNum13.Name = "MainPlayerNum13";
            // 
            // MainPlayerNum14
            // 
            this.MainPlayerNum14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum14, "MainPlayerNum14");
            this.MainPlayerNum14.Name = "MainPlayerNum14";
            // 
            // MainPlayerNum15
            // 
            this.MainPlayerNum15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum15, "MainPlayerNum15");
            this.MainPlayerNum15.Name = "MainPlayerNum15";
            // 
            // MainPlayerNum16
            // 
            this.MainPlayerNum16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerNum16, "MainPlayerNum16");
            this.MainPlayerNum16.Name = "MainPlayerNum16";
            // 
            // MainPlayerCard16
            // 
            this.MainPlayerCard16.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard16, "MainPlayerCard16");
            this.MainPlayerCard16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard16.Name = "MainPlayerCard16";
            this.MainPlayerCard16.TabStop = false;
            // 
            // MainPlayerCard15
            // 
            this.MainPlayerCard15.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard15, "MainPlayerCard15");
            this.MainPlayerCard15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard15.Name = "MainPlayerCard15";
            this.MainPlayerCard15.TabStop = false;
            // 
            // MainPlayerCard14
            // 
            this.MainPlayerCard14.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard14, "MainPlayerCard14");
            this.MainPlayerCard14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard14.Name = "MainPlayerCard14";
            this.MainPlayerCard14.TabStop = false;
            // 
            // MainPlayerCard13
            // 
            this.MainPlayerCard13.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard13, "MainPlayerCard13");
            this.MainPlayerCard13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard13.Name = "MainPlayerCard13";
            this.MainPlayerCard13.TabStop = false;
            // 
            // MainPlayerCard12
            // 
            this.MainPlayerCard12.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard12, "MainPlayerCard12");
            this.MainPlayerCard12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard12.Name = "MainPlayerCard12";
            this.MainPlayerCard12.TabStop = false;
            // 
            // MainPlayerCard11
            // 
            this.MainPlayerCard11.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard11, "MainPlayerCard11");
            this.MainPlayerCard11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard11.Name = "MainPlayerCard11";
            this.MainPlayerCard11.TabStop = false;
            // 
            // MainPlayerCard10
            // 
            this.MainPlayerCard10.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard10, "MainPlayerCard10");
            this.MainPlayerCard10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard10.Name = "MainPlayerCard10";
            this.MainPlayerCard10.TabStop = false;
            // 
            // MainPlayerCard9
            // 
            this.MainPlayerCard9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard9, "MainPlayerCard9");
            this.MainPlayerCard9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard9.Name = "MainPlayerCard9";
            this.MainPlayerCard9.TabStop = false;
            // 
            // MainPlayerCard8
            // 
            this.MainPlayerCard8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard8, "MainPlayerCard8");
            this.MainPlayerCard8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard8.Name = "MainPlayerCard8";
            this.MainPlayerCard8.TabStop = false;
            // 
            // MainPlayerCard7
            // 
            this.MainPlayerCard7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard7, "MainPlayerCard7");
            this.MainPlayerCard7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard7.Name = "MainPlayerCard7";
            this.MainPlayerCard7.TabStop = false;
            // 
            // MainPlayerCard6
            // 
            this.MainPlayerCard6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard6, "MainPlayerCard6");
            this.MainPlayerCard6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard6.Name = "MainPlayerCard6";
            this.MainPlayerCard6.TabStop = false;
            // 
            // MainPlayerCard5
            // 
            this.MainPlayerCard5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard5, "MainPlayerCard5");
            this.MainPlayerCard5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard5.Name = "MainPlayerCard5";
            this.MainPlayerCard5.TabStop = false;
            // 
            // MainPlayerCard4
            // 
            this.MainPlayerCard4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard4, "MainPlayerCard4");
            this.MainPlayerCard4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard4.Name = "MainPlayerCard4";
            this.MainPlayerCard4.TabStop = false;
            // 
            // MainPlayerCard3
            // 
            this.MainPlayerCard3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard3, "MainPlayerCard3");
            this.MainPlayerCard3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard3.Name = "MainPlayerCard3";
            this.MainPlayerCard3.TabStop = false;
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // MainPlayerCard2
            // 
            this.MainPlayerCard2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard2, "MainPlayerCard2");
            this.MainPlayerCard2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard2.Name = "MainPlayerCard2";
            this.MainPlayerCard2.TabStop = false;
            // 
            // MainPlayerCard1
            // 
            this.MainPlayerCard1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.MainPlayerCard1, "MainPlayerCard1");
            this.MainPlayerCard1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPlayerCard1.Name = "MainPlayerCard1";
            this.MainPlayerCard1.TabStop = false;
            // 
            // AcceptCardButton
            // 
            this.AcceptCardButton.BackColor = System.Drawing.Color.LemonChiffon;
            resources.ApplyResources(this.AcceptCardButton, "AcceptCardButton");
            this.AcceptCardButton.Name = "AcceptCardButton";
            this.AcceptCardButton.UseVisualStyleBackColor = false;
            // 
            // NoGraciasButton
            // 
            this.NoGraciasButton.BackColor = System.Drawing.Color.LemonChiffon;
            resources.ApplyResources(this.NoGraciasButton, "NoGraciasButton");
            this.NoGraciasButton.Name = "NoGraciasButton";
            this.NoGraciasButton.UseVisualStyleBackColor = false;
            // 
            // DeckChip
            // 
            this.DeckChip.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.DeckChip, "DeckChip");
            this.DeckChip.Name = "DeckChip";
            this.DeckChip.TabStop = false;
            // 
            // TopDeckChipCounter
            // 
            resources.ApplyResources(this.TopDeckChipCounter, "TopDeckChipCounter");
            this.TopDeckChipCounter.Name = "TopDeckChipCounter";
            // 
            // TopDeckChipText
            // 
            resources.ApplyResources(this.TopDeckChipText, "TopDeckChipText");
            this.TopDeckChipText.Name = "TopDeckChipText";
            // 
            // TurnStatus
            // 
            resources.ApplyResources(this.TurnStatus, "TurnStatus");
            this.TurnStatus.Name = "TurnStatus";
            // 
            // CardTableForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.Controls.Add(this.TurnStatus);
            this.Controls.Add(this.TopDeckChipCounter);
            this.Controls.Add(this.TopDeckChipText);
            this.Controls.Add(this.DeckChip);
            this.Controls.Add(this.NoGraciasButton);
            this.Controls.Add(this.AcceptCardButton);
            this.Controls.Add(this.MainPlayerNum8);
            this.Controls.Add(this.MainPlayerNum7);
            this.Controls.Add(this.MainPlayerNum6);
            this.Controls.Add(this.MainPlayerNum5);
            this.Controls.Add(this.MainPlayerNum4);
            this.Controls.Add(this.MainPlayerNum3);
            this.Controls.Add(this.MainPlayerNum2);
            this.Controls.Add(this.MainPlayerNum1);
            this.Controls.Add(this.MainPlayerNum9);
            this.Controls.Add(this.MainPlayerNum10);
            this.Controls.Add(this.MainPlayerNum11);
            this.Controls.Add(this.MainPlayerNum12);
            this.Controls.Add(this.MainPlayerNum13);
            this.Controls.Add(this.MainPlayerNum14);
            this.Controls.Add(this.MainPlayerNum15);
            this.Controls.Add(this.MainPlayerNum16);
            this.Controls.Add(this.MainPlayerCard16);
            this.Controls.Add(this.MainPlayerCard15);
            this.Controls.Add(this.MainPlayerCard14);
            this.Controls.Add(this.MainPlayerCard13);
            this.Controls.Add(this.MainPlayerCard12);
            this.Controls.Add(this.MainPlayerCard11);
            this.Controls.Add(this.MainPlayerCard10);
            this.Controls.Add(this.MainPlayerCard9);
            this.Controls.Add(this.MainPlayerCard8);
            this.Controls.Add(this.MainPlayerCard7);
            this.Controls.Add(this.MainPlayerCard6);
            this.Controls.Add(this.MainPlayerCard5);
            this.Controls.Add(this.MainPlayerCard4);
            this.Controls.Add(this.MainPlayerCard3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.MainPlayerCard2);
            this.Controls.Add(this.MainPlayerCard1);
            this.Controls.Add(this.Opp3Num8);
            this.Controls.Add(this.Opp3Num7);
            this.Controls.Add(this.Opp3Num6);
            this.Controls.Add(this.Opp3Num5);
            this.Controls.Add(this.Opp3Num4);
            this.Controls.Add(this.Opp3Num3);
            this.Controls.Add(this.Opp3Num2);
            this.Controls.Add(this.Opp3Num1);
            this.Controls.Add(this.Opp3Num9);
            this.Controls.Add(this.Opp3Num10);
            this.Controls.Add(this.Opp3Num11);
            this.Controls.Add(this.Opp3Num12);
            this.Controls.Add(this.Opp3Num13);
            this.Controls.Add(this.Opp3Num14);
            this.Controls.Add(this.Opp3Num15);
            this.Controls.Add(this.Opp3Num16);
            this.Controls.Add(this.Opp3Card16);
            this.Controls.Add(this.Opp3Card15);
            this.Controls.Add(this.Opp3Card14);
            this.Controls.Add(this.Opp3Card13);
            this.Controls.Add(this.Opp3Card12);
            this.Controls.Add(this.Opp3Card11);
            this.Controls.Add(this.Opp3Card10);
            this.Controls.Add(this.Opp3Card9);
            this.Controls.Add(this.Opp3Card8);
            this.Controls.Add(this.Opp3Card7);
            this.Controls.Add(this.Opp3Card6);
            this.Controls.Add(this.Opp3Card5);
            this.Controls.Add(this.Opp3Card4);
            this.Controls.Add(this.Opp3Card3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Opp3Card2);
            this.Controls.Add(this.Opp3Card1);
            this.Controls.Add(this.Opp4Num8);
            this.Controls.Add(this.Opp4Num7);
            this.Controls.Add(this.Opp4Num6);
            this.Controls.Add(this.Opp4Num5);
            this.Controls.Add(this.Opp4Num4);
            this.Controls.Add(this.Opp4Num3);
            this.Controls.Add(this.Opp4Num2);
            this.Controls.Add(this.Opp4Num1);
            this.Controls.Add(this.Opp4Num9);
            this.Controls.Add(this.Opp4Num10);
            this.Controls.Add(this.Opp4Num11);
            this.Controls.Add(this.Opp4Num12);
            this.Controls.Add(this.Opp4Num13);
            this.Controls.Add(this.Opp4Num14);
            this.Controls.Add(this.Opp4Num15);
            this.Controls.Add(this.Opp4Num16);
            this.Controls.Add(this.Opp4Card16);
            this.Controls.Add(this.Opp4Card15);
            this.Controls.Add(this.Opp4Card14);
            this.Controls.Add(this.Opp4Card13);
            this.Controls.Add(this.Opp4Card12);
            this.Controls.Add(this.Opp4Card11);
            this.Controls.Add(this.Opp4Card10);
            this.Controls.Add(this.Opp4Card9);
            this.Controls.Add(this.Opp4Card8);
            this.Controls.Add(this.Opp4Card7);
            this.Controls.Add(this.Opp4Card6);
            this.Controls.Add(this.Opp4Card5);
            this.Controls.Add(this.Opp4Card4);
            this.Controls.Add(this.Opp4Card3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Opp4Card2);
            this.Controls.Add(this.Opp4Card1);
            this.Controls.Add(this.Opp2Num8);
            this.Controls.Add(this.Opp2Num7);
            this.Controls.Add(this.Opp2Num6);
            this.Controls.Add(this.Opp2Num5);
            this.Controls.Add(this.Opp2Num4);
            this.Controls.Add(this.Opp2Num3);
            this.Controls.Add(this.Opp2Num2);
            this.Controls.Add(this.Opp2Num1);
            this.Controls.Add(this.Opp2Num9);
            this.Controls.Add(this.Opp2Num10);
            this.Controls.Add(this.Opp2Num11);
            this.Controls.Add(this.Opp2Num12);
            this.Controls.Add(this.Opp2Num13);
            this.Controls.Add(this.Opp2Num14);
            this.Controls.Add(this.Opp2Num15);
            this.Controls.Add(this.Opp2Num16);
            this.Controls.Add(this.Opp2Card16);
            this.Controls.Add(this.Opp2Card15);
            this.Controls.Add(this.Opp2Card14);
            this.Controls.Add(this.Opp2Card13);
            this.Controls.Add(this.Opp2Card12);
            this.Controls.Add(this.Opp2Card11);
            this.Controls.Add(this.Opp2Card10);
            this.Controls.Add(this.Opp2Card9);
            this.Controls.Add(this.Opp2Card8);
            this.Controls.Add(this.Opp2Card7);
            this.Controls.Add(this.Opp2Card6);
            this.Controls.Add(this.Opp2Card5);
            this.Controls.Add(this.Opp2Card4);
            this.Controls.Add(this.Opp2Card3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Opp2Card2);
            this.Controls.Add(this.Opp2Card1);
            this.Controls.Add(this.Opp1Num8);
            this.Controls.Add(this.Opp1Num7);
            this.Controls.Add(this.Opp1Num6);
            this.Controls.Add(this.Opp1Num5);
            this.Controls.Add(this.Opp1Num4);
            this.Controls.Add(this.Opp1Num3);
            this.Controls.Add(this.Opp1Num2);
            this.Controls.Add(this.Opp1Num1);
            this.Controls.Add(this.Opp1Num9);
            this.Controls.Add(this.Opp1Num10);
            this.Controls.Add(this.Opp1Num11);
            this.Controls.Add(this.Opp1Num12);
            this.Controls.Add(this.Opp1Num13);
            this.Controls.Add(this.Opp1Num14);
            this.Controls.Add(this.Opp1Num15);
            this.Controls.Add(this.Opp1Num16);
            this.Controls.Add(this.TopDeckCardNum);
            this.Controls.Add(this.DeckCard);
            this.Controls.Add(this.Opp1Card16);
            this.Controls.Add(this.Opp1Card15);
            this.Controls.Add(this.Opp1Card14);
            this.Controls.Add(this.Opp1Card13);
            this.Controls.Add(this.Opp1Card12);
            this.Controls.Add(this.Opp1Card11);
            this.Controls.Add(this.Opp1Card10);
            this.Controls.Add(this.Opp1Card9);
            this.Controls.Add(this.Opp1Card8);
            this.Controls.Add(this.Opp1Card7);
            this.Controls.Add(this.Opp1Card6);
            this.Controls.Add(this.Opp1Card5);
            this.Controls.Add(this.Opp4ChipCount);
            this.Controls.Add(this.Opp3ChipCount);
            this.Controls.Add(this.MainPlayerChipCount);
            this.Controls.Add(this.Opp2ChipCount);
            this.Controls.Add(this.Opp1ChipCount);
            this.Controls.Add(this.GameDeckLabel);
            this.Controls.Add(this.TopDeckCard);
            this.Controls.Add(this.Opp1ChipText);
            this.Controls.Add(this.Opp2ChipText);
            this.Controls.Add(this.MainPlayerChipText);
            this.Controls.Add(this.Opp3ChipText);
            this.Controls.Add(this.Opp4ChipText);
            this.Controls.Add(this.opp4ChipGraphic);
            this.Controls.Add(this.Opp1Card4);
            this.Controls.Add(this.opp3ChipGraphic);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.Opp3Name);
            this.Controls.Add(this.Opp4Name);
            this.Controls.Add(this.Opp1Name);
            this.Controls.Add(this.Opp1Card3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Opp1Card2);
            this.Controls.Add(this.Opp1Card1);
            this.Controls.Add(this.Opp2Name);
            this.Controls.Add(this.MainPlayerName);
            this.Name = "CardTableForm";
            this.Load += new System.EventHandler(this.CardTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opp3ChipGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opp4ChipGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopDeckCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp2Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp4Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp3Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckChip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label MainPlayerName;
        private System.Windows.Forms.Label Opp2Name;
        private System.Windows.Forms.Label Opp1Name;
        private System.Windows.Forms.PictureBox Opp1Card3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox Opp1Card2;
        private System.Windows.Forms.PictureBox Opp1Card1;
        private System.Windows.Forms.Label Opp4Name;
        private System.Windows.Forms.Label Opp3Name;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox opp3ChipGraphic;
        private System.Windows.Forms.PictureBox Opp1Card4;
        private System.Windows.Forms.PictureBox opp4ChipGraphic;
        private System.Windows.Forms.Label Opp4ChipText;
        private System.Windows.Forms.Label Opp3ChipText;
        private System.Windows.Forms.Label MainPlayerChipText;
        private System.Windows.Forms.Label Opp2ChipText;
        private System.Windows.Forms.Label Opp1ChipText;
        private System.Windows.Forms.PictureBox TopDeckCard;
        private System.Windows.Forms.Label GameDeckLabel;
        private System.Windows.Forms.Label Opp1ChipCount;
        private System.Windows.Forms.Label Opp2ChipCount;
        private System.Windows.Forms.Label MainPlayerChipCount;
        private System.Windows.Forms.Label Opp3ChipCount;
        private System.Windows.Forms.Label Opp4ChipCount;
        private System.Windows.Forms.PictureBox Opp1Card8;
        private System.Windows.Forms.PictureBox Opp1Card7;
        private System.Windows.Forms.PictureBox Opp1Card6;
        private System.Windows.Forms.PictureBox Opp1Card5;
        private System.Windows.Forms.PictureBox Opp1Card12;
        private System.Windows.Forms.PictureBox Opp1Card11;
        private System.Windows.Forms.PictureBox Opp1Card10;
        private System.Windows.Forms.PictureBox Opp1Card9;
        private System.Windows.Forms.PictureBox Opp1Card16;
        private System.Windows.Forms.PictureBox Opp1Card15;
        private System.Windows.Forms.PictureBox Opp1Card14;
        private System.Windows.Forms.PictureBox Opp1Card13;
        private System.Windows.Forms.PictureBox DeckCard;
        private System.Windows.Forms.Label TopDeckCardNum;
        private System.Windows.Forms.Label Opp1Num16;
        private System.Windows.Forms.Label Opp1Num15;
        private System.Windows.Forms.Label Opp1Num14;
        private System.Windows.Forms.Label Opp1Num13;
        private System.Windows.Forms.Label Opp1Num12;
        private System.Windows.Forms.Label Opp1Num11;
        private System.Windows.Forms.Label Opp1Num10;
        private System.Windows.Forms.Label Opp1Num9;
        private System.Windows.Forms.Label Opp1Num1;
        private System.Windows.Forms.Label Opp1Num2;
        private System.Windows.Forms.Label Opp1Num3;
        private System.Windows.Forms.Label Opp1Num4;
        private System.Windows.Forms.Label Opp1Num5;
        private System.Windows.Forms.Label Opp1Num6;
        private System.Windows.Forms.Label Opp1Num7;
        private System.Windows.Forms.Label Opp1Num8;
        private System.Windows.Forms.Label Opp2Num8;
        private System.Windows.Forms.Label Opp2Num7;
        private System.Windows.Forms.Label Opp2Num6;
        private System.Windows.Forms.Label Opp2Num5;
        private System.Windows.Forms.Label Opp2Num4;
        private System.Windows.Forms.Label Opp2Num3;
        private System.Windows.Forms.Label Opp2Num2;
        private System.Windows.Forms.Label Opp2Num1;
        private System.Windows.Forms.Label Opp2Num9;
        private System.Windows.Forms.Label Opp2Num11;
        private System.Windows.Forms.Label Opp2Num12;
        private System.Windows.Forms.Label Opp2Num13;
        private System.Windows.Forms.Label Opp2Num14;
        private System.Windows.Forms.Label Opp2Num15;
        private System.Windows.Forms.Label Opp2Num16;
        private System.Windows.Forms.PictureBox Opp2Card16;
        private System.Windows.Forms.PictureBox Opp2Card15;
        private System.Windows.Forms.PictureBox Opp2Card14;
        private System.Windows.Forms.PictureBox Opp2Card13;
        private System.Windows.Forms.PictureBox Opp2Card12;
        private System.Windows.Forms.PictureBox Opp2Card11;
        private System.Windows.Forms.PictureBox Opp2Card10;
        private System.Windows.Forms.PictureBox Opp2Card9;
        private System.Windows.Forms.PictureBox Opp2Card8;
        private System.Windows.Forms.PictureBox Opp2Card7;
        private System.Windows.Forms.PictureBox Opp2Card6;
        private System.Windows.Forms.PictureBox Opp2Card5;
        private System.Windows.Forms.PictureBox Opp2Card4;
        private System.Windows.Forms.PictureBox Opp2Card3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox Opp2Card2;
        private System.Windows.Forms.PictureBox Opp2Card1;
        private System.Windows.Forms.Label Opp4Num8;
        private System.Windows.Forms.Label Opp4Num7;
        private System.Windows.Forms.Label Opp4Num6;
        private System.Windows.Forms.Label Opp4Num5;
        private System.Windows.Forms.Label Opp4Num4;
        private System.Windows.Forms.Label Opp4Num3;
        private System.Windows.Forms.Label Opp4Num2;
        private System.Windows.Forms.Label Opp4Num1;
        private System.Windows.Forms.Label Opp4Num9;
        private System.Windows.Forms.Label Opp4Num10;
        private System.Windows.Forms.Label Opp4Num11;
        private System.Windows.Forms.Label Opp4Num12;
        private System.Windows.Forms.Label Opp4Num13;
        private System.Windows.Forms.Label Opp4Num14;
        private System.Windows.Forms.Label Opp4Num15;
        private System.Windows.Forms.Label Opp4Num16;
        private System.Windows.Forms.PictureBox Opp4Card16;
        private System.Windows.Forms.PictureBox Opp4Card15;
        private System.Windows.Forms.PictureBox Opp4Card14;
        private System.Windows.Forms.PictureBox Opp4Card13;
        private System.Windows.Forms.PictureBox Opp4Card12;
        private System.Windows.Forms.PictureBox Opp4Card11;
        private System.Windows.Forms.PictureBox Opp4Card10;
        private System.Windows.Forms.PictureBox Opp4Card9;
        private System.Windows.Forms.PictureBox Opp4Card8;
        private System.Windows.Forms.PictureBox Opp4Card7;
        private System.Windows.Forms.PictureBox Opp4Card6;
        private System.Windows.Forms.PictureBox Opp4Card5;
        private System.Windows.Forms.PictureBox Opp4Card4;
        private System.Windows.Forms.PictureBox Opp4Card3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox Opp4Card2;
        private System.Windows.Forms.PictureBox Opp4Card1;
        private System.Windows.Forms.Label Opp3Num8;
        private System.Windows.Forms.Label Opp3Num7;
        private System.Windows.Forms.Label Opp3Num6;
        private System.Windows.Forms.Label Opp3Num5;
        private System.Windows.Forms.Label Opp3Num4;
        private System.Windows.Forms.Label Opp3Num3;
        private System.Windows.Forms.Label Opp3Num2;
        private System.Windows.Forms.Label Opp3Num1;
        private System.Windows.Forms.Label Opp3Num9;
        private System.Windows.Forms.Label Opp3Num10;
        private System.Windows.Forms.Label Opp3Num11;
        private System.Windows.Forms.Label Opp3Num12;
        private System.Windows.Forms.Label Opp3Num13;
        private System.Windows.Forms.Label Opp3Num14;
        private System.Windows.Forms.Label Opp3Num15;
        private System.Windows.Forms.Label Opp3Num16;
        private System.Windows.Forms.PictureBox Opp3Card16;
        private System.Windows.Forms.PictureBox Opp3Card15;
        private System.Windows.Forms.PictureBox Opp3Card14;
        private System.Windows.Forms.PictureBox Opp3Card13;
        private System.Windows.Forms.PictureBox Opp3Card12;
        private System.Windows.Forms.PictureBox Opp3Card11;
        private System.Windows.Forms.PictureBox Opp3Card10;
        private System.Windows.Forms.PictureBox Opp3Card9;
        private System.Windows.Forms.PictureBox Opp3Card8;
        private System.Windows.Forms.PictureBox Opp3Card7;
        private System.Windows.Forms.PictureBox Opp3Card6;
        private System.Windows.Forms.PictureBox Opp3Card5;
        private System.Windows.Forms.PictureBox Opp3Card4;
        private System.Windows.Forms.PictureBox Opp3Card3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox Opp3Card2;
        private System.Windows.Forms.PictureBox Opp3Card1;
        private System.Windows.Forms.Label MainPlayerNum8;
        private System.Windows.Forms.Label MainPlayerNum7;
        private System.Windows.Forms.Label MainPlayerNum6;
        private System.Windows.Forms.Label MainPlayerNum5;
        private System.Windows.Forms.Label MainPlayerNum4;
        private System.Windows.Forms.Label MainPlayerNum3;
        private System.Windows.Forms.Label MainPlayerNum2;
        private System.Windows.Forms.Label MainPlayerNum1;
        private System.Windows.Forms.Label MainPlayerNum9;
        private System.Windows.Forms.Label MainPlayerNum10;
        private System.Windows.Forms.Label MainPlayerNum11;
        private System.Windows.Forms.Label MainPlayerNum12;
        private System.Windows.Forms.Label MainPlayerNum13;
        private System.Windows.Forms.Label MainPlayerNum14;
        private System.Windows.Forms.Label MainPlayerNum15;
        private System.Windows.Forms.Label MainPlayerNum16;
        private System.Windows.Forms.PictureBox MainPlayerCard16;
        private System.Windows.Forms.PictureBox MainPlayerCard15;
        private System.Windows.Forms.PictureBox MainPlayerCard14;
        private System.Windows.Forms.PictureBox MainPlayerCard13;
        private System.Windows.Forms.PictureBox MainPlayerCard12;
        private System.Windows.Forms.PictureBox MainPlayerCard11;
        private System.Windows.Forms.PictureBox MainPlayerCard10;
        private System.Windows.Forms.PictureBox MainPlayerCard9;
        private System.Windows.Forms.PictureBox MainPlayerCard8;
        private System.Windows.Forms.PictureBox MainPlayerCard7;
        private System.Windows.Forms.PictureBox MainPlayerCard6;
        private System.Windows.Forms.PictureBox MainPlayerCard5;
        private System.Windows.Forms.PictureBox MainPlayerCard4;
        private System.Windows.Forms.PictureBox MainPlayerCard3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox MainPlayerCard2;
        private System.Windows.Forms.PictureBox MainPlayerCard1;
        private System.Windows.Forms.Label Opp2Num10;
        private System.Windows.Forms.Button AcceptCardButton;
        private System.Windows.Forms.Button NoGraciasButton;
        private System.Windows.Forms.PictureBox DeckChip;
        private System.Windows.Forms.Label TopDeckChipCounter;
        private System.Windows.Forms.Label TopDeckChipText;
        #endregion

        private Socket mClientSocket;
        private Label TurnStatus;
    }
}

