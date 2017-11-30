/**************************************************************
 * File:  CardTableForm.Designer.cs
 * 
 * Authors: Andrew Growney, Kaiser Mittenburg, Juzer Zarif          
 * 
 * Description: Logic for the Card Table window
 *                                                            
 * ***********************************************************/
using System;
using System.Drawing;
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
        public bool PlayerCard
        {
            get { return this.MainPlayerCard1.Visible; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.MainPlayerCard1.Visible = value;
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

        public string Opp1ChipNumber
        {
            get { return this.Opp1ChipCount.Text; }
            set
            {
                this.Opp1ChipCount.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp1ChipCount.Text = value;
                });
            }
        }
        public bool Opp1Card
        {
            get { return this.Opp1Card1.Visible; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Opp1Card1.Visible = value;
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

        public string Opp2ChipNumber
        {
            get { return this.Opp2ChipCount.Text; }
            set
            {
                this.Opp2ChipCount.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp2ChipCount.Text = value;
                });
            }
        }
        public bool Opp2Card
        {
            get { return this.Opp2Card1.Visible; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Opp2Card1.Visible = value;
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
            get { return this.Opp3ChipCount.Text; }
            set
            {
                this.Opp3ChipCount.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp3ChipCount.Text = value;
                });
            }
        }
        public bool Opp3Card
        {
            get { return this.Opp3Card1.Visible; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Opp3Card1.Visible = value;
                });
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
            get { return this.Opp4ChipCount.Text; }
            set
            {
                this.Opp4ChipCount.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Opp4ChipCount.Text = value;
                });
            }
        }
        public bool Opp4Card
        {
            get { return this.Opp4Card1.Visible; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Opp4Card1.Visible = value;
                });
            }
        }
        #endregion
        #region Turn Card
        public Image TurnCard
        {
            get { return this.TopDeckCard.BackgroundImage; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.TopDeckCard.BackgroundImage = value;
                });
            }
        }
        public string TurnCardValue
        {
            get { return this.currentCard.ToString(); }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.currentCard = Int32.Parse(value);
                });
            }
        }
        public string TurnChipNumber
        {
            get { return this.TopDeckChipCounter.Text; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.TopDeckChipCounter.Text = value;
                });
            }
        }
        #endregion
        #region Turn Status
        public string TurnStatusText
        {
            get { return this.TurnStatus.Text; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.TurnStatus.Text = value;
                });
            }
        }
        #endregion
        #region Buttons
        public Button Accept
        {
            get { return this.AcceptCardButton; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.AcceptCardButton = value;
                });
            }
        }
        public Button Reject
        {
            get { return this.NoGraciasButton; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.NoGraciasButton = value;
                });
            }
        }
        public System.Media.SoundPlayer Sound
        {
            get { return this.soundDriver; }
            set
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.soundDriver = value;
                });
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
            this.Opp2ChipCount = new System.Windows.Forms.Label();
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
            this.Opp2ChipText = new System.Windows.Forms.Label();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.Opp2Name = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Opp1ChipCount = new System.Windows.Forms.Label();
            this.Opp1Card16 = new System.Windows.Forms.PictureBox();
            this.Opp1Card15 = new System.Windows.Forms.PictureBox();
            this.Opp1Card14 = new System.Windows.Forms.PictureBox();
            this.Opp1Card13 = new System.Windows.Forms.PictureBox();
            this.Opp1Card12 = new System.Windows.Forms.PictureBox();
            this.Opp1Card11 = new System.Windows.Forms.PictureBox();
            this.Opp1Card10 = new System.Windows.Forms.PictureBox();
            this.Opp1Card9 = new System.Windows.Forms.PictureBox();
            this.Opp1Card8 = new System.Windows.Forms.PictureBox();
            this.Opp1Card7 = new System.Windows.Forms.PictureBox();
            this.Opp1Card6 = new System.Windows.Forms.PictureBox();
            this.Opp1Card5 = new System.Windows.Forms.PictureBox();
            this.Opp1ChipText = new System.Windows.Forms.Label();
            this.Opp1Card4 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.Opp1Name = new System.Windows.Forms.Label();
            this.Opp1Card3 = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Opp1Card2 = new System.Windows.Forms.PictureBox();
            this.Opp1Card1 = new System.Windows.Forms.PictureBox();
            this.DeckCard1 = new System.Windows.Forms.PictureBox();
            this.DeckCard2 = new System.Windows.Forms.PictureBox();
            this.DeckCard3 = new System.Windows.Forms.PictureBox();
            this.DeckCard4 = new System.Windows.Forms.PictureBox();
            this.GameDeckLabel = new System.Windows.Forms.Label();
            this.TopDeckChipCounter = new System.Windows.Forms.Label();
            this.TurnStatus = new System.Windows.Forms.Label();
            this.TopDeckChipText = new System.Windows.Forms.Label();
            this.DeckChip = new System.Windows.Forms.PictureBox();
            this.NoGraciasButton = new System.Windows.Forms.Button();
            this.AcceptCardButton = new System.Windows.Forms.Button();
            this.TopDeckCard = new System.Windows.Forms.PictureBox();
            this.MainPlayerChipCount = new System.Windows.Forms.Label();
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
            this.MainPlayerChipText = new System.Windows.Forms.Label();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.MainPlayerName = new System.Windows.Forms.Label();
            this.MainPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.Opp3ChipCount = new System.Windows.Forms.Label();
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
            this.Opp3ChipText = new System.Windows.Forms.Label();
            this.opp3ChipGraphic = new System.Windows.Forms.PictureBox();
            this.Opp3Name = new System.Windows.Forms.Label();
            this.Opp4ChipCount = new System.Windows.Forms.Label();
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
            this.Opp4ChipText = new System.Windows.Forms.Label();
            this.opp4ChipGraphic = new System.Windows.Forms.PictureBox();
            this.Opp4Name = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckChip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopDeckCard)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.opp3ChipGraphic)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.opp4ChipGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // Opp2ChipCount
            // 
            resources.ApplyResources(this.Opp2ChipCount, "Opp2ChipCount");
            this.Opp2ChipCount.ForeColor = System.Drawing.Color.White;
            this.Opp2ChipCount.Name = "Opp2ChipCount";
            // 
            // Opp2Card16
            // 
            resources.ApplyResources(this.Opp2Card16, "Opp2Card16");
            this.Opp2Card16.BackColor = System.Drawing.Color.White;
            this.Opp2Card16.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card16.Name = "Opp2Card16";
            this.Opp2Card16.TabStop = false;
            // 
            // Opp2Card15
            // 
            resources.ApplyResources(this.Opp2Card15, "Opp2Card15");
            this.Opp2Card15.BackColor = System.Drawing.Color.White;
            this.Opp2Card15.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card15.Name = "Opp2Card15";
            this.Opp2Card15.TabStop = false;
            // 
            // Opp2Card14
            // 
            resources.ApplyResources(this.Opp2Card14, "Opp2Card14");
            this.Opp2Card14.BackColor = System.Drawing.Color.White;
            this.Opp2Card14.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card14.Name = "Opp2Card14";
            this.Opp2Card14.TabStop = false;
            // 
            // Opp2Card13
            // 
            resources.ApplyResources(this.Opp2Card13, "Opp2Card13");
            this.Opp2Card13.BackColor = System.Drawing.Color.White;
            this.Opp2Card13.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card13.Name = "Opp2Card13";
            this.Opp2Card13.TabStop = false;
            // 
            // Opp2Card12
            // 
            resources.ApplyResources(this.Opp2Card12, "Opp2Card12");
            this.Opp2Card12.BackColor = System.Drawing.Color.White;
            this.Opp2Card12.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card12.Name = "Opp2Card12";
            this.Opp2Card12.TabStop = false;
            // 
            // Opp2Card11
            // 
            resources.ApplyResources(this.Opp2Card11, "Opp2Card11");
            this.Opp2Card11.BackColor = System.Drawing.Color.White;
            this.Opp2Card11.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card11.Name = "Opp2Card11";
            this.Opp2Card11.TabStop = false;
            // 
            // Opp2Card10
            // 
            resources.ApplyResources(this.Opp2Card10, "Opp2Card10");
            this.Opp2Card10.BackColor = System.Drawing.Color.White;
            this.Opp2Card10.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card10.Name = "Opp2Card10";
            this.Opp2Card10.TabStop = false;
            // 
            // Opp2Card9
            // 
            resources.ApplyResources(this.Opp2Card9, "Opp2Card9");
            this.Opp2Card9.BackColor = System.Drawing.Color.White;
            this.Opp2Card9.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card9.Name = "Opp2Card9";
            this.Opp2Card9.TabStop = false;
            // 
            // Opp2Card8
            // 
            resources.ApplyResources(this.Opp2Card8, "Opp2Card8");
            this.Opp2Card8.BackColor = System.Drawing.Color.White;
            this.Opp2Card8.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card8.Name = "Opp2Card8";
            this.Opp2Card8.TabStop = false;
            // 
            // Opp2Card7
            // 
            resources.ApplyResources(this.Opp2Card7, "Opp2Card7");
            this.Opp2Card7.BackColor = System.Drawing.Color.White;
            this.Opp2Card7.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card7.Name = "Opp2Card7";
            this.Opp2Card7.TabStop = false;
            // 
            // Opp2Card6
            // 
            resources.ApplyResources(this.Opp2Card6, "Opp2Card6");
            this.Opp2Card6.BackColor = System.Drawing.Color.White;
            this.Opp2Card6.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card6.Name = "Opp2Card6";
            this.Opp2Card6.TabStop = false;
            // 
            // Opp2Card5
            // 
            resources.ApplyResources(this.Opp2Card5, "Opp2Card5");
            this.Opp2Card5.BackColor = System.Drawing.Color.White;
            this.Opp2Card5.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card5.Name = "Opp2Card5";
            this.Opp2Card5.TabStop = false;
            // 
            // Opp2Card4
            // 
            resources.ApplyResources(this.Opp2Card4, "Opp2Card4");
            this.Opp2Card4.BackColor = System.Drawing.Color.White;
            this.Opp2Card4.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card4.Name = "Opp2Card4";
            this.Opp2Card4.TabStop = false;
            // 
            // Opp2Card3
            // 
            resources.ApplyResources(this.Opp2Card3, "Opp2Card3");
            this.Opp2Card3.BackColor = System.Drawing.Color.White;
            this.Opp2Card3.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card3.Name = "Opp2Card3";
            this.Opp2Card3.TabStop = false;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Name = "textBox2";
            // 
            // Opp2Card2
            // 
            resources.ApplyResources(this.Opp2Card2, "Opp2Card2");
            this.Opp2Card2.BackColor = System.Drawing.Color.White;
            this.Opp2Card2.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card2.Name = "Opp2Card2";
            this.Opp2Card2.TabStop = false;
            // 
            // Opp2Card1
            // 
            resources.ApplyResources(this.Opp2Card1, "Opp2Card1");
            this.Opp2Card1.BackColor = System.Drawing.Color.White;
            this.Opp2Card1.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp2Card1.Name = "Opp2Card1";
            this.Opp2Card1.TabStop = false;
            // 
            // Opp2ChipText
            // 
            resources.ApplyResources(this.Opp2ChipText, "Opp2ChipText");
            this.Opp2ChipText.ForeColor = System.Drawing.Color.White;
            this.Opp2ChipText.Name = "Opp2ChipText";
            // 
            // pictureBox17
            // 
            resources.ApplyResources(this.pictureBox17, "pictureBox17");
            this.pictureBox17.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox17.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.TabStop = false;
            // 
            // Opp2Name
            // 
            resources.ApplyResources(this.Opp2Name, "Opp2Name");
            this.Opp2Name.BackColor = System.Drawing.Color.Transparent;
            this.Opp2Name.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Opp2Name.Name = "Opp2Name";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = global::NoGracias.Properties.Resources.speaker;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // Opp1ChipCount
            // 
            resources.ApplyResources(this.Opp1ChipCount, "Opp1ChipCount");
            this.Opp1ChipCount.ForeColor = System.Drawing.Color.White;
            this.Opp1ChipCount.Name = "Opp1ChipCount";
            // 
            // Opp1Card16
            // 
            resources.ApplyResources(this.Opp1Card16, "Opp1Card16");
            this.Opp1Card16.BackColor = System.Drawing.Color.White;
            this.Opp1Card16.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card16.Name = "Opp1Card16";
            this.Opp1Card16.TabStop = false;
            // 
            // Opp1Card15
            // 
            resources.ApplyResources(this.Opp1Card15, "Opp1Card15");
            this.Opp1Card15.BackColor = System.Drawing.Color.White;
            this.Opp1Card15.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card15.Name = "Opp1Card15";
            this.Opp1Card15.TabStop = false;
            // 
            // Opp1Card14
            // 
            resources.ApplyResources(this.Opp1Card14, "Opp1Card14");
            this.Opp1Card14.BackColor = System.Drawing.Color.White;
            this.Opp1Card14.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card14.Name = "Opp1Card14";
            this.Opp1Card14.TabStop = false;
            // 
            // Opp1Card13
            // 
            resources.ApplyResources(this.Opp1Card13, "Opp1Card13");
            this.Opp1Card13.BackColor = System.Drawing.Color.White;
            this.Opp1Card13.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card13.Name = "Opp1Card13";
            this.Opp1Card13.TabStop = false;
            // 
            // Opp1Card12
            // 
            resources.ApplyResources(this.Opp1Card12, "Opp1Card12");
            this.Opp1Card12.BackColor = System.Drawing.Color.White;
            this.Opp1Card12.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card12.Name = "Opp1Card12";
            this.Opp1Card12.TabStop = false;
            // 
            // Opp1Card11
            // 
            resources.ApplyResources(this.Opp1Card11, "Opp1Card11");
            this.Opp1Card11.BackColor = System.Drawing.Color.White;
            this.Opp1Card11.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card11.Name = "Opp1Card11";
            this.Opp1Card11.TabStop = false;
            // 
            // Opp1Card10
            // 
            resources.ApplyResources(this.Opp1Card10, "Opp1Card10");
            this.Opp1Card10.BackColor = System.Drawing.Color.White;
            this.Opp1Card10.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card10.Name = "Opp1Card10";
            this.Opp1Card10.TabStop = false;
            // 
            // Opp1Card9
            // 
            resources.ApplyResources(this.Opp1Card9, "Opp1Card9");
            this.Opp1Card9.BackColor = System.Drawing.Color.White;
            this.Opp1Card9.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card9.Name = "Opp1Card9";
            this.Opp1Card9.TabStop = false;
            // 
            // Opp1Card8
            // 
            resources.ApplyResources(this.Opp1Card8, "Opp1Card8");
            this.Opp1Card8.BackColor = System.Drawing.Color.White;
            this.Opp1Card8.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card8.Name = "Opp1Card8";
            this.Opp1Card8.TabStop = false;
            // 
            // Opp1Card7
            // 
            resources.ApplyResources(this.Opp1Card7, "Opp1Card7");
            this.Opp1Card7.BackColor = System.Drawing.Color.White;
            this.Opp1Card7.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card7.Name = "Opp1Card7";
            this.Opp1Card7.TabStop = false;
            // 
            // Opp1Card6
            // 
            resources.ApplyResources(this.Opp1Card6, "Opp1Card6");
            this.Opp1Card6.BackColor = System.Drawing.Color.White;
            this.Opp1Card6.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card6.Name = "Opp1Card6";
            this.Opp1Card6.TabStop = false;
            // 
            // Opp1Card5
            // 
            resources.ApplyResources(this.Opp1Card5, "Opp1Card5");
            this.Opp1Card5.BackColor = System.Drawing.Color.White;
            this.Opp1Card5.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card5.Name = "Opp1Card5";
            this.Opp1Card5.TabStop = false;
            // 
            // Opp1ChipText
            // 
            resources.ApplyResources(this.Opp1ChipText, "Opp1ChipText");
            this.Opp1ChipText.ForeColor = System.Drawing.Color.White;
            this.Opp1ChipText.Name = "Opp1ChipText";
            // 
            // Opp1Card4
            // 
            resources.ApplyResources(this.Opp1Card4, "Opp1Card4");
            this.Opp1Card4.BackColor = System.Drawing.Color.White;
            this.Opp1Card4.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card4.Name = "Opp1Card4";
            this.Opp1Card4.TabStop = false;
            // 
            // pictureBox18
            // 
            resources.ApplyResources(this.pictureBox18, "pictureBox18");
            this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox18.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.TabStop = false;
            // 
            // Opp1Name
            // 
            resources.ApplyResources(this.Opp1Name, "Opp1Name");
            this.Opp1Name.BackColor = System.Drawing.Color.Transparent;
            this.Opp1Name.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Opp1Name.Name = "Opp1Name";
            // 
            // Opp1Card3
            // 
            resources.ApplyResources(this.Opp1Card3, "Opp1Card3");
            this.Opp1Card3.BackColor = System.Drawing.Color.White;
            this.Opp1Card3.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card3.Name = "Opp1Card3";
            this.Opp1Card3.TabStop = false;
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Name = "textBox3";
            // 
            // Opp1Card2
            // 
            resources.ApplyResources(this.Opp1Card2, "Opp1Card2");
            this.Opp1Card2.BackColor = System.Drawing.Color.White;
            this.Opp1Card2.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card2.Name = "Opp1Card2";
            this.Opp1Card2.TabStop = false;
            // 
            // Opp1Card1
            // 
            resources.ApplyResources(this.Opp1Card1, "Opp1Card1");
            this.Opp1Card1.BackColor = System.Drawing.Color.White;
            this.Opp1Card1.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp1Card1.Name = "Opp1Card1";
            this.Opp1Card1.TabStop = false;
            // 
            // DeckCard1
            // 
            resources.ApplyResources(this.DeckCard1, "DeckCard1");
            this.DeckCard1.BackgroundImage = global::NoGracias.Properties.Resources.img1;
            this.DeckCard1.Name = "DeckCard1";
            this.DeckCard1.TabStop = false;
            // 
            // DeckCard2
            // 
            resources.ApplyResources(this.DeckCard2, "DeckCard2");
            this.DeckCard2.BackgroundImage = global::NoGracias.Properties.Resources.img1;
            this.DeckCard2.Name = "DeckCard2";
            this.DeckCard2.TabStop = false;
            // 
            // DeckCard3
            // 
            resources.ApplyResources(this.DeckCard3, "DeckCard3");
            this.DeckCard3.BackgroundImage = global::NoGracias.Properties.Resources.img1;
            this.DeckCard3.Name = "DeckCard3";
            this.DeckCard3.TabStop = false;
            // 
            // DeckCard4
            // 
            resources.ApplyResources(this.DeckCard4, "DeckCard4");
            this.DeckCard4.BackgroundImage = global::NoGracias.Properties.Resources.img1;
            this.DeckCard4.Name = "DeckCard4";
            this.DeckCard4.TabStop = false;
            // 
            // GameDeckLabel
            // 
            resources.ApplyResources(this.GameDeckLabel, "GameDeckLabel");
            this.GameDeckLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameDeckLabel.ForeColor = System.Drawing.Color.White;
            this.GameDeckLabel.Name = "GameDeckLabel";
            // 
            // TopDeckChipCounter
            // 
            resources.ApplyResources(this.TopDeckChipCounter, "TopDeckChipCounter");
            this.TopDeckChipCounter.ForeColor = System.Drawing.Color.White;
            this.TopDeckChipCounter.Name = "TopDeckChipCounter";
            // 
            // TurnStatus
            // 
            resources.ApplyResources(this.TurnStatus, "TurnStatus");
            this.TurnStatus.BackColor = System.Drawing.Color.Transparent;
            this.TurnStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TurnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TurnStatus.ForeColor = System.Drawing.Color.White;
            this.TurnStatus.Name = "TurnStatus";
            // 
            // TopDeckChipText
            // 
            resources.ApplyResources(this.TopDeckChipText, "TopDeckChipText");
            this.TopDeckChipText.ForeColor = System.Drawing.Color.White;
            this.TopDeckChipText.Name = "TopDeckChipText";
            // 
            // DeckChip
            // 
            resources.ApplyResources(this.DeckChip, "DeckChip");
            this.DeckChip.BackColor = System.Drawing.Color.Transparent;
            this.DeckChip.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.DeckChip.Name = "DeckChip";
            this.DeckChip.TabStop = false;
            // 
            // NoGraciasButton
            // 
            resources.ApplyResources(this.NoGraciasButton, "NoGraciasButton");
            this.NoGraciasButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NoGraciasButton.FlatAppearance.BorderSize = 0;
            this.NoGraciasButton.Name = "NoGraciasButton";
            this.NoGraciasButton.UseVisualStyleBackColor = false;
            this.NoGraciasButton.Click += new System.EventHandler(this.NoGraciasButton_Click);
            // 
            // AcceptCardButton
            // 
            resources.ApplyResources(this.AcceptCardButton, "AcceptCardButton");
            this.AcceptCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(170)))), ((int)(((byte)(70)))));
            this.AcceptCardButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.AcceptCardButton.FlatAppearance.BorderSize = 0;
            this.AcceptCardButton.Name = "AcceptCardButton";
            this.AcceptCardButton.UseVisualStyleBackColor = false;
            this.AcceptCardButton.Click += new System.EventHandler(this.AcceptCardButton_Click);
            // 
            // TopDeckCard
            // 
            resources.ApplyResources(this.TopDeckCard, "TopDeckCard");
            this.TopDeckCard.BackColor = System.Drawing.Color.White;
            this.TopDeckCard.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.TopDeckCard.Name = "TopDeckCard";
            this.TopDeckCard.TabStop = false;
            // 
            // MainPlayerChipCount
            // 
            resources.ApplyResources(this.MainPlayerChipCount, "MainPlayerChipCount");
            this.MainPlayerChipCount.ForeColor = System.Drawing.Color.White;
            this.MainPlayerChipCount.Name = "MainPlayerChipCount";
            // 
            // MainPlayerCard16
            // 
            resources.ApplyResources(this.MainPlayerCard16, "MainPlayerCard16");
            this.MainPlayerCard16.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard16.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard16.Name = "MainPlayerCard16";
            this.MainPlayerCard16.TabStop = false;
            // 
            // MainPlayerCard15
            // 
            resources.ApplyResources(this.MainPlayerCard15, "MainPlayerCard15");
            this.MainPlayerCard15.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard15.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard15.Name = "MainPlayerCard15";
            this.MainPlayerCard15.TabStop = false;
            // 
            // MainPlayerCard14
            // 
            resources.ApplyResources(this.MainPlayerCard14, "MainPlayerCard14");
            this.MainPlayerCard14.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard14.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard14.Name = "MainPlayerCard14";
            this.MainPlayerCard14.TabStop = false;
            // 
            // MainPlayerCard13
            // 
            resources.ApplyResources(this.MainPlayerCard13, "MainPlayerCard13");
            this.MainPlayerCard13.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard13.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard13.Name = "MainPlayerCard13";
            this.MainPlayerCard13.TabStop = false;
            // 
            // MainPlayerCard12
            // 
            resources.ApplyResources(this.MainPlayerCard12, "MainPlayerCard12");
            this.MainPlayerCard12.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard12.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard12.Name = "MainPlayerCard12";
            this.MainPlayerCard12.TabStop = false;
            // 
            // MainPlayerCard11
            // 
            resources.ApplyResources(this.MainPlayerCard11, "MainPlayerCard11");
            this.MainPlayerCard11.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard11.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard11.Name = "MainPlayerCard11";
            this.MainPlayerCard11.TabStop = false;
            // 
            // MainPlayerCard10
            // 
            resources.ApplyResources(this.MainPlayerCard10, "MainPlayerCard10");
            this.MainPlayerCard10.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard10.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard10.Name = "MainPlayerCard10";
            this.MainPlayerCard10.TabStop = false;
            // 
            // MainPlayerCard9
            // 
            resources.ApplyResources(this.MainPlayerCard9, "MainPlayerCard9");
            this.MainPlayerCard9.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard9.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard9.Name = "MainPlayerCard9";
            this.MainPlayerCard9.TabStop = false;
            // 
            // MainPlayerCard8
            // 
            resources.ApplyResources(this.MainPlayerCard8, "MainPlayerCard8");
            this.MainPlayerCard8.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard8.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard8.Name = "MainPlayerCard8";
            this.MainPlayerCard8.TabStop = false;
            // 
            // MainPlayerCard7
            // 
            resources.ApplyResources(this.MainPlayerCard7, "MainPlayerCard7");
            this.MainPlayerCard7.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard7.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard7.Name = "MainPlayerCard7";
            this.MainPlayerCard7.TabStop = false;
            // 
            // MainPlayerCard6
            // 
            resources.ApplyResources(this.MainPlayerCard6, "MainPlayerCard6");
            this.MainPlayerCard6.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard6.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard6.Name = "MainPlayerCard6";
            this.MainPlayerCard6.TabStop = false;
            // 
            // MainPlayerCard5
            // 
            resources.ApplyResources(this.MainPlayerCard5, "MainPlayerCard5");
            this.MainPlayerCard5.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard5.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard5.Name = "MainPlayerCard5";
            this.MainPlayerCard5.TabStop = false;
            // 
            // MainPlayerCard4
            // 
            resources.ApplyResources(this.MainPlayerCard4, "MainPlayerCard4");
            this.MainPlayerCard4.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard4.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard4.Name = "MainPlayerCard4";
            this.MainPlayerCard4.TabStop = false;
            // 
            // MainPlayerCard3
            // 
            resources.ApplyResources(this.MainPlayerCard3, "MainPlayerCard3");
            this.MainPlayerCard3.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard3.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard3.Name = "MainPlayerCard3";
            this.MainPlayerCard3.TabStop = false;
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Name = "textBox5";
            // 
            // MainPlayerCard2
            // 
            resources.ApplyResources(this.MainPlayerCard2, "MainPlayerCard2");
            this.MainPlayerCard2.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard2.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard2.Name = "MainPlayerCard2";
            this.MainPlayerCard2.TabStop = false;
            // 
            // MainPlayerChipText
            // 
            resources.ApplyResources(this.MainPlayerChipText, "MainPlayerChipText");
            this.MainPlayerChipText.ForeColor = System.Drawing.Color.White;
            this.MainPlayerChipText.Name = "MainPlayerChipText";
            // 
            // pictureBox16
            // 
            resources.ApplyResources(this.pictureBox16, "pictureBox16");
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.TabStop = false;
            // 
            // MainPlayerName
            // 
            resources.ApplyResources(this.MainPlayerName, "MainPlayerName");
            this.MainPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.MainPlayerName.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.MainPlayerName.Name = "MainPlayerName";
            // 
            // MainPlayerCard1
            // 
            resources.ApplyResources(this.MainPlayerCard1, "MainPlayerCard1");
            this.MainPlayerCard1.BackColor = System.Drawing.Color.White;
            this.MainPlayerCard1.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.MainPlayerCard1.Name = "MainPlayerCard1";
            this.MainPlayerCard1.TabStop = false;
            // 
            // Opp3ChipCount
            // 
            resources.ApplyResources(this.Opp3ChipCount, "Opp3ChipCount");
            this.Opp3ChipCount.BackColor = System.Drawing.Color.Transparent;
            this.Opp3ChipCount.ForeColor = System.Drawing.Color.White;
            this.Opp3ChipCount.Name = "Opp3ChipCount";
            // 
            // Opp3Card16
            // 
            resources.ApplyResources(this.Opp3Card16, "Opp3Card16");
            this.Opp3Card16.BackColor = System.Drawing.Color.White;
            this.Opp3Card16.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card16.Name = "Opp3Card16";
            this.Opp3Card16.TabStop = false;
            // 
            // Opp3Card15
            // 
            resources.ApplyResources(this.Opp3Card15, "Opp3Card15");
            this.Opp3Card15.BackColor = System.Drawing.Color.White;
            this.Opp3Card15.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card15.Name = "Opp3Card15";
            this.Opp3Card15.TabStop = false;
            // 
            // Opp3Card14
            // 
            resources.ApplyResources(this.Opp3Card14, "Opp3Card14");
            this.Opp3Card14.BackColor = System.Drawing.Color.White;
            this.Opp3Card14.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card14.Name = "Opp3Card14";
            this.Opp3Card14.TabStop = false;
            // 
            // Opp3Card13
            // 
            resources.ApplyResources(this.Opp3Card13, "Opp3Card13");
            this.Opp3Card13.BackColor = System.Drawing.Color.White;
            this.Opp3Card13.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card13.Name = "Opp3Card13";
            this.Opp3Card13.TabStop = false;
            // 
            // Opp3Card12
            // 
            resources.ApplyResources(this.Opp3Card12, "Opp3Card12");
            this.Opp3Card12.BackColor = System.Drawing.Color.White;
            this.Opp3Card12.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card12.Name = "Opp3Card12";
            this.Opp3Card12.TabStop = false;
            // 
            // Opp3Card11
            // 
            resources.ApplyResources(this.Opp3Card11, "Opp3Card11");
            this.Opp3Card11.BackColor = System.Drawing.Color.White;
            this.Opp3Card11.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card11.Name = "Opp3Card11";
            this.Opp3Card11.TabStop = false;
            // 
            // Opp3Card10
            // 
            resources.ApplyResources(this.Opp3Card10, "Opp3Card10");
            this.Opp3Card10.BackColor = System.Drawing.Color.White;
            this.Opp3Card10.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card10.Name = "Opp3Card10";
            this.Opp3Card10.TabStop = false;
            // 
            // Opp3Card9
            // 
            resources.ApplyResources(this.Opp3Card9, "Opp3Card9");
            this.Opp3Card9.BackColor = System.Drawing.Color.White;
            this.Opp3Card9.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card9.Name = "Opp3Card9";
            this.Opp3Card9.TabStop = false;
            // 
            // Opp3Card8
            // 
            resources.ApplyResources(this.Opp3Card8, "Opp3Card8");
            this.Opp3Card8.BackColor = System.Drawing.Color.White;
            this.Opp3Card8.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card8.Name = "Opp3Card8";
            this.Opp3Card8.TabStop = false;
            // 
            // Opp3Card7
            // 
            resources.ApplyResources(this.Opp3Card7, "Opp3Card7");
            this.Opp3Card7.BackColor = System.Drawing.Color.White;
            this.Opp3Card7.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card7.Name = "Opp3Card7";
            this.Opp3Card7.TabStop = false;
            // 
            // Opp3Card6
            // 
            resources.ApplyResources(this.Opp3Card6, "Opp3Card6");
            this.Opp3Card6.BackColor = System.Drawing.Color.White;
            this.Opp3Card6.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card6.Name = "Opp3Card6";
            this.Opp3Card6.TabStop = false;
            // 
            // Opp3Card5
            // 
            resources.ApplyResources(this.Opp3Card5, "Opp3Card5");
            this.Opp3Card5.BackColor = System.Drawing.Color.White;
            this.Opp3Card5.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card5.Name = "Opp3Card5";
            this.Opp3Card5.TabStop = false;
            // 
            // Opp3Card4
            // 
            resources.ApplyResources(this.Opp3Card4, "Opp3Card4");
            this.Opp3Card4.BackColor = System.Drawing.Color.White;
            this.Opp3Card4.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card4.Name = "Opp3Card4";
            this.Opp3Card4.TabStop = false;
            // 
            // Opp3Card3
            // 
            resources.ApplyResources(this.Opp3Card3, "Opp3Card3");
            this.Opp3Card3.BackColor = System.Drawing.Color.White;
            this.Opp3Card3.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card3.Name = "Opp3Card3";
            this.Opp3Card3.TabStop = false;
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Name = "textBox4";
            // 
            // Opp3Card2
            // 
            resources.ApplyResources(this.Opp3Card2, "Opp3Card2");
            this.Opp3Card2.BackColor = System.Drawing.Color.White;
            this.Opp3Card2.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card2.Name = "Opp3Card2";
            this.Opp3Card2.TabStop = false;
            // 
            // Opp3Card1
            // 
            resources.ApplyResources(this.Opp3Card1, "Opp3Card1");
            this.Opp3Card1.BackColor = System.Drawing.Color.White;
            this.Opp3Card1.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp3Card1.Name = "Opp3Card1";
            this.Opp3Card1.TabStop = false;
            // 
            // Opp3ChipText
            // 
            resources.ApplyResources(this.Opp3ChipText, "Opp3ChipText");
            this.Opp3ChipText.BackColor = System.Drawing.Color.Transparent;
            this.Opp3ChipText.ForeColor = System.Drawing.Color.White;
            this.Opp3ChipText.Name = "Opp3ChipText";
            // 
            // opp3ChipGraphic
            // 
            resources.ApplyResources(this.opp3ChipGraphic, "opp3ChipGraphic");
            this.opp3ChipGraphic.BackColor = System.Drawing.Color.Transparent;
            this.opp3ChipGraphic.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.opp3ChipGraphic.Name = "opp3ChipGraphic";
            this.opp3ChipGraphic.TabStop = false;
            // 
            // Opp3Name
            // 
            resources.ApplyResources(this.Opp3Name, "Opp3Name");
            this.Opp3Name.BackColor = System.Drawing.Color.Transparent;
            this.Opp3Name.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Opp3Name.Name = "Opp3Name";
            // 
            // Opp4ChipCount
            // 
            resources.ApplyResources(this.Opp4ChipCount, "Opp4ChipCount");
            this.Opp4ChipCount.ForeColor = System.Drawing.Color.White;
            this.Opp4ChipCount.Name = "Opp4ChipCount";
            // 
            // Opp4Card16
            // 
            resources.ApplyResources(this.Opp4Card16, "Opp4Card16");
            this.Opp4Card16.BackColor = System.Drawing.Color.White;
            this.Opp4Card16.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card16.Name = "Opp4Card16";
            this.Opp4Card16.TabStop = false;
            // 
            // Opp4Card15
            // 
            resources.ApplyResources(this.Opp4Card15, "Opp4Card15");
            this.Opp4Card15.BackColor = System.Drawing.Color.White;
            this.Opp4Card15.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card15.Name = "Opp4Card15";
            this.Opp4Card15.TabStop = false;
            // 
            // Opp4Card14
            // 
            resources.ApplyResources(this.Opp4Card14, "Opp4Card14");
            this.Opp4Card14.BackColor = System.Drawing.Color.White;
            this.Opp4Card14.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card14.Name = "Opp4Card14";
            this.Opp4Card14.TabStop = false;
            // 
            // Opp4Card13
            // 
            resources.ApplyResources(this.Opp4Card13, "Opp4Card13");
            this.Opp4Card13.BackColor = System.Drawing.Color.White;
            this.Opp4Card13.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card13.Name = "Opp4Card13";
            this.Opp4Card13.TabStop = false;
            // 
            // Opp4Card12
            // 
            resources.ApplyResources(this.Opp4Card12, "Opp4Card12");
            this.Opp4Card12.BackColor = System.Drawing.Color.White;
            this.Opp4Card12.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card12.Name = "Opp4Card12";
            this.Opp4Card12.TabStop = false;
            // 
            // Opp4Card11
            // 
            resources.ApplyResources(this.Opp4Card11, "Opp4Card11");
            this.Opp4Card11.BackColor = System.Drawing.Color.White;
            this.Opp4Card11.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card11.Name = "Opp4Card11";
            this.Opp4Card11.TabStop = false;
            // 
            // Opp4Card10
            // 
            resources.ApplyResources(this.Opp4Card10, "Opp4Card10");
            this.Opp4Card10.BackColor = System.Drawing.Color.White;
            this.Opp4Card10.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card10.Name = "Opp4Card10";
            this.Opp4Card10.TabStop = false;
            // 
            // Opp4Card9
            // 
            resources.ApplyResources(this.Opp4Card9, "Opp4Card9");
            this.Opp4Card9.BackColor = System.Drawing.Color.White;
            this.Opp4Card9.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card9.Name = "Opp4Card9";
            this.Opp4Card9.TabStop = false;
            // 
            // Opp4Card8
            // 
            resources.ApplyResources(this.Opp4Card8, "Opp4Card8");
            this.Opp4Card8.BackColor = System.Drawing.Color.White;
            this.Opp4Card8.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card8.Name = "Opp4Card8";
            this.Opp4Card8.TabStop = false;
            // 
            // Opp4Card7
            // 
            resources.ApplyResources(this.Opp4Card7, "Opp4Card7");
            this.Opp4Card7.BackColor = System.Drawing.Color.White;
            this.Opp4Card7.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card7.Name = "Opp4Card7";
            this.Opp4Card7.TabStop = false;
            // 
            // Opp4Card6
            // 
            resources.ApplyResources(this.Opp4Card6, "Opp4Card6");
            this.Opp4Card6.BackColor = System.Drawing.Color.White;
            this.Opp4Card6.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card6.Name = "Opp4Card6";
            this.Opp4Card6.TabStop = false;
            // 
            // Opp4Card5
            // 
            resources.ApplyResources(this.Opp4Card5, "Opp4Card5");
            this.Opp4Card5.BackColor = System.Drawing.Color.White;
            this.Opp4Card5.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card5.Name = "Opp4Card5";
            this.Opp4Card5.TabStop = false;
            // 
            // Opp4Card4
            // 
            resources.ApplyResources(this.Opp4Card4, "Opp4Card4");
            this.Opp4Card4.BackColor = System.Drawing.Color.White;
            this.Opp4Card4.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card4.Name = "Opp4Card4";
            this.Opp4Card4.TabStop = false;
            // 
            // Opp4Card3
            // 
            resources.ApplyResources(this.Opp4Card3, "Opp4Card3");
            this.Opp4Card3.BackColor = System.Drawing.Color.White;
            this.Opp4Card3.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card3.Name = "Opp4Card3";
            this.Opp4Card3.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Name = "textBox1";
            // 
            // Opp4Card2
            // 
            resources.ApplyResources(this.Opp4Card2, "Opp4Card2");
            this.Opp4Card2.BackColor = System.Drawing.Color.White;
            this.Opp4Card2.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card2.Name = "Opp4Card2";
            this.Opp4Card2.TabStop = false;
            // 
            // Opp4Card1
            // 
            resources.ApplyResources(this.Opp4Card1, "Opp4Card1");
            this.Opp4Card1.BackColor = System.Drawing.Color.White;
            this.Opp4Card1.BackgroundImage = global::NoGracias.Properties.Resources.img2;
            this.Opp4Card1.Name = "Opp4Card1";
            this.Opp4Card1.TabStop = false;
            // 
            // Opp4ChipText
            // 
            resources.ApplyResources(this.Opp4ChipText, "Opp4ChipText");
            this.Opp4ChipText.ForeColor = System.Drawing.Color.White;
            this.Opp4ChipText.Name = "Opp4ChipText";
            // 
            // opp4ChipGraphic
            // 
            resources.ApplyResources(this.opp4ChipGraphic, "opp4ChipGraphic");
            this.opp4ChipGraphic.BackColor = System.Drawing.Color.Transparent;
            this.opp4ChipGraphic.BackgroundImage = global::NoGracias.Properties.Resources.chip2;
            this.opp4ChipGraphic.Name = "opp4ChipGraphic";
            this.opp4ChipGraphic.TabStop = false;
            // 
            // Opp4Name
            // 
            resources.ApplyResources(this.Opp4Name, "Opp4Name");
            this.Opp4Name.BackColor = System.Drawing.Color.Transparent;
            this.Opp4Name.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Opp4Name.Name = "Opp4Name";
            // 
            // CardTableForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.Opp3ChipCount);
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
            this.Controls.Add(this.Opp3ChipText);
            this.Controls.Add(this.opp3ChipGraphic);
            this.Controls.Add(this.Opp3Name);
            this.Controls.Add(this.Opp4ChipCount);
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
            this.Controls.Add(this.Opp4ChipText);
            this.Controls.Add(this.opp4ChipGraphic);
            this.Controls.Add(this.Opp4Name);
            this.Controls.Add(this.MainPlayerChipCount);
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
            this.Controls.Add(this.MainPlayerChipText);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.MainPlayerName);
            this.Controls.Add(this.MainPlayerCard1);
            this.Controls.Add(this.TopDeckChipCounter);
            this.Controls.Add(this.TurnStatus);
            this.Controls.Add(this.TopDeckChipText);
            this.Controls.Add(this.DeckChip);
            this.Controls.Add(this.NoGraciasButton);
            this.Controls.Add(this.AcceptCardButton);
            this.Controls.Add(this.TopDeckCard);
            this.Controls.Add(this.DeckCard1);
            this.Controls.Add(this.DeckCard2);
            this.Controls.Add(this.DeckCard3);
            this.Controls.Add(this.DeckCard4);
            this.Controls.Add(this.GameDeckLabel);
            this.Controls.Add(this.Opp2ChipCount);
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
            this.Controls.Add(this.Opp2ChipText);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.Opp2Name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Opp1ChipCount);
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
            this.Controls.Add(this.Opp1ChipText);
            this.Controls.Add(this.Opp1Card4);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.Opp1Name);
            this.Controls.Add(this.Opp1Card3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Opp1Card2);
            this.Controls.Add(this.Opp1Card1);
            this.Name = "CardTableForm";
            this.Load += new System.EventHandler(this.CardTableForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Opp1Card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeckChip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopDeckCard)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPlayerCard1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.opp3ChipGraphic)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.opp4ChipGraphic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        #endregion

        private Socket mClientSocket;
        private Label Opp2ChipCount;
        private PictureBox Opp2Card16;
        private PictureBox Opp2Card15;
        private PictureBox Opp2Card14;
        private PictureBox Opp2Card13;
        private PictureBox Opp2Card12;
        private PictureBox Opp2Card11;
        private PictureBox Opp2Card10;
        private PictureBox Opp2Card9;
        private PictureBox Opp2Card8;
        private PictureBox Opp2Card7;
        private PictureBox Opp2Card6;
        private PictureBox Opp2Card5;
        private PictureBox Opp2Card4;
        private PictureBox Opp2Card3;
        private TextBox textBox2;
        private PictureBox Opp2Card2;
        private PictureBox Opp2Card1;
        private Label Opp2ChipText;
        private PictureBox pictureBox17;
        private Label Opp2Name;
        private Button button1;
        private Label Opp1ChipCount;
        private PictureBox Opp1Card16;
        private PictureBox Opp1Card15;
        private PictureBox Opp1Card14;
        private PictureBox Opp1Card13;
        private PictureBox Opp1Card12;
        private PictureBox Opp1Card11;
        private PictureBox Opp1Card10;
        private PictureBox Opp1Card9;
        private PictureBox Opp1Card8;
        private PictureBox Opp1Card7;
        private PictureBox Opp1Card6;
        private PictureBox Opp1Card5;
        private Label Opp1ChipText;
        private PictureBox Opp1Card4;
        private PictureBox pictureBox18;
        private Label Opp1Name;
        private PictureBox Opp1Card3;
        private TextBox textBox3;
        private PictureBox Opp1Card2;
        private PictureBox Opp1Card1;
        private PictureBox DeckCard1;
        private PictureBox DeckCard2;
        private PictureBox DeckCard3;
        private PictureBox DeckCard4;
        private Label GameDeckLabel;
        private Label TopDeckChipCounter;
        private Label TurnStatus;
        private Label TopDeckChipText;
        private PictureBox DeckChip;
        private Button NoGraciasButton;
        private Button AcceptCardButton;
        private PictureBox TopDeckCard;
        private Label MainPlayerChipCount;
        private PictureBox MainPlayerCard16;
        private PictureBox MainPlayerCard15;
        private PictureBox MainPlayerCard14;
        private PictureBox MainPlayerCard13;
        private PictureBox MainPlayerCard12;
        private PictureBox MainPlayerCard11;
        private PictureBox MainPlayerCard10;
        private PictureBox MainPlayerCard9;
        private PictureBox MainPlayerCard8;
        private PictureBox MainPlayerCard7;
        private PictureBox MainPlayerCard6;
        private PictureBox MainPlayerCard5;
        private PictureBox MainPlayerCard4;
        private PictureBox MainPlayerCard3;
        private TextBox textBox5;
        private PictureBox MainPlayerCard2;
        private Label MainPlayerChipText;
        private PictureBox pictureBox16;
        private Label MainPlayerName;
        private PictureBox MainPlayerCard1;
        private Label Opp3ChipCount;
        private PictureBox Opp3Card16;
        private PictureBox Opp3Card15;
        private PictureBox Opp3Card14;
        private PictureBox Opp3Card13;
        private PictureBox Opp3Card12;
        private PictureBox Opp3Card11;
        private PictureBox Opp3Card10;
        private PictureBox Opp3Card9;
        private PictureBox Opp3Card8;
        private PictureBox Opp3Card7;
        private PictureBox Opp3Card6;
        private PictureBox Opp3Card5;
        private PictureBox Opp3Card4;
        private PictureBox Opp3Card3;
        private TextBox textBox4;
        private PictureBox Opp3Card2;
        private PictureBox Opp3Card1;
        private Label Opp3ChipText;
        private PictureBox opp3ChipGraphic;
        private Label Opp3Name;
        private Label Opp4ChipCount;
        private PictureBox Opp4Card16;
        private PictureBox Opp4Card15;
        private PictureBox Opp4Card14;
        private PictureBox Opp4Card13;
        private PictureBox Opp4Card12;
        private PictureBox Opp4Card11;
        private PictureBox Opp4Card10;
        private PictureBox Opp4Card9;
        private PictureBox Opp4Card8;
        private PictureBox Opp4Card7;
        private PictureBox Opp4Card6;
        private PictureBox Opp4Card5;
        private PictureBox Opp4Card4;
        private PictureBox Opp4Card3;
        private TextBox textBox1;
        private PictureBox Opp4Card2;
        private PictureBox Opp4Card1;
        private Label Opp4ChipText;
        private PictureBox opp4ChipGraphic;
        private Label Opp4Name;
    }
}

