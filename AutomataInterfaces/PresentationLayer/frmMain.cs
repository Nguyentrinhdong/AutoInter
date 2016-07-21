using AutomataInterfaces.Interfaces;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutomataInterfaces.PresentationLayer
{
    public partial class frmMain : Form
    {
        private List<Automata> A = new List<Automata>();
        private TimedProvider tPr = new TimedProvider();
        private Boolean Kt = false;
        private GViewer gViewer = new GViewer();
        private String Path = "";




        public frmMain()
        {
#if DEBUG
            DisplayGeometryGraph.SetShowFunctions();
#endif

            InitializeComponent();
        }

        private void richTextBoxEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                if (Path == "")
                {
                    //MessageBox.Show("Chua mo file!");
                    SaveFileDialog savefdlg = new SaveFileDialog();
                    savefdlg.Filter = "Interface | *.ai";
                    if (savefdlg.ShowDialog() == DialogResult.OK)
                    {
                        Path = savefdlg.FileName;
                        //StreamWriter strWrt = new StreamWriter(Path);
                        richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                        //strWrt.Close();
                    }
                }
                else
                {
                    richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                }
            }
            else
                if (e.Control && e.KeyCode == Keys.W)       // Ctrl-S Save
                {
                    richTextBoxEditor.Text = "";
                    Path = "";
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            richTextBoxEditor.Focus();
            richTextBoxEditor.AcceptsTab = true;
            Scanner scanner = new Scanner();
            Parser parser = new Parser(scanner);
            TextHighlighter textHighlight = new TextHighlighter(richTextBoxEditor, scanner, parser);
            ParseTree tree = parser.Parse(richTextBoxEditor.Text);
            //Debug.WriteLine(richTextBoxEditor.Text);

            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Kt)
            {
                switch (tabControlAI.SelectedIndex)
                {
                    case 0: tabControlAI.SelectTab(0); break;
                    case 1:
                        {
                            treeViewDraw.Nodes.Clear();
                            tPr.CopyTreeNodes(tPr.Automatatree(A), treeViewDraw);
                            treeViewDraw.EndUpdate();
                        }
                        break;

                }
            }
        }

        private void richTextBoxEditor_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkSatisfyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimedProvider tpr = new TimedProvider();
            //tpr.CheckSatitsfy();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog savefdlg = new SaveFileDialog();
            try
            {
                if (Path == "")
                {
                    //MessageBox.Show("Chua mo file!");
                    tabControlAI.SelectTab(0);
                    savefdlg.Filter = "Interface | *.ai";

                    if (savefdlg.ShowDialog() == DialogResult.OK)
                    {
                        Path = savefdlg.FileName;
                        richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                        this.Text = "[ " + Path + "] Automata Interfaces";
                    }
                }
                else
                {
                    tabControlAI.SelectTab(0);
                    richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                    this.Text = "[ " + Path + "] Automata Interfaces";
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error save file! Please Close file."+ ex.Message.ToString());

            }

        }

        private void toolStripButtonDrawAutomata_Click(object sender, EventArgs e)
        {
            TimedProvider tpr = new TimedProvider();
           
            gViewer.Size = new System.Drawing.Size(500, 400);

            gViewer.Dock = DockStyle.Fill;
            gViewer.ToolBarIsVisible = false;
            panelGraphic.Controls.Add(gViewer);
            //this.splitContainerDraw.Panel2.Controls.Add(gViewer);
            tpr.Automata2Graphic(A, gViewer);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxAI abt = new AboutBoxAI();
            abt.Show();
        }

        private void toolStripAutomataGeneration_Click(object sender, EventArgs e)
        {
            tabControlAI.SelectTab(1);
            if (richTextBoxEditor.Text.Length != 0)
            {
                A = tPr.CreateAutomataList(richTextBoxEditor.Text);
                treeViewDraw.Nodes.Clear();
                tPr.CopyTreeNodes(tPr.Automatatree(A), treeViewDraw);
                treeViewDraw.EndUpdate();
            }
            else
            {
                MessageBox.Show("Please, load automata from file.");
            }
        }

        private void toolStripPlugggableCheck_Click(object sender, EventArgs e)
        {
            List<PlugableEI> f = new List<PlugableEI>();
            tabControlAI.SelectTab(1);
            if (A == null)
            {
                MessageBox.Show("The automata empty. Load automata from file or generate by press icon A on toolTips.");
            }
            else
            {
                if (A.Count == 2)
                {
                    tPr.PrecheckedAutomata(A);

                    if (tPr.CheckedPluggableIE(A[0], A[1], out f))
                    {
                        tPr.Automata2Graphic(f, gViewer);
                        MessageBox.Show("I is pluggable to E", "Pluggable Message", MessageBoxButtons.OK);

                    }
                    else
                    { MessageBox.Show("I is not pluggable to E", "Pluggable Message", MessageBoxButtons.OK); }
                }
                else
                    MessageBox.Show("Please! Input 2 automata for checking.");
            }
        }

        private void toolStripRefinementChecked_Click(object sender, EventArgs e)
        {
            List<PlugableEI> f = new List<PlugableEI>();
            tabControlAI.SelectTab(1);
            if (A == null)
            {
                MessageBox.Show("The automata empty. Load automata from file or generate by press icon A on toolTips.");
            }
            else
            {
                if (A.Count == 2)
                {
                    GViewer gView = new GViewer();

                    //gView.Size = new System.Drawing.Size(200, 100);

                    gView.Dock = DockStyle.Fill;
                    gView.ToolBarIsVisible = false;
                    tPr.Automata2Graphic(f, gView);
                    tPr.PrecheckedAutomata(A);
                    if (tPr.CheckedPluggableIE(A[0], A[1], out f))
                    {
                        MessageBox.Show("I is refinement to E", "Refinement Message", MessageBoxButtons.OK);
                    }
                    else
                    { MessageBox.Show("I is not refinement to E", "Refinement Message", MessageBoxButtons.OK); }
                }
                else
                    MessageBox.Show("Please! Input 2 automata for checking.");
            }
        }

        private void toolStripButtonOPen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "Interface | *.ai";
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                Path = ofdlg.FileName;
                StreamReader strRdr = new StreamReader(Path);
                richTextBoxEditor.Text = strRdr.ReadToEnd();
                //tabControl1.TabIndex = 0;
                tabControlAI.SelectTab(0);
                strRdr.Close();
                Kt = true;
            }
            this.Text = "[ " + ofdlg.FileName + "] Automata Interfaces";
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            tabControlAI.SelectTab(0);
            richTextBoxEditor.Text = "";
            Path = "";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefdlg = new SaveFileDialog();
            if (Path == "")
            {
                //MessageBox.Show("Chua mo file!");
                tabControlAI.SelectTab(0);
                savefdlg.Filter = "Interface | *.ai";

                if (savefdlg.ShowDialog() == DialogResult.OK)
                {
                    Path = savefdlg.FileName;
                    richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                    this.Text = "[ " + Path + "] Automata Interfaces";
                }
            }
            else
            {
                try
                {
                    tabControlAI.SelectTab(0);
                    richTextBoxEditor.SaveFile(Path, RichTextBoxStreamType.PlainText);
                    this.Text = "[ " + Path + "] Automata Interfaces";
                }
                catch   (IOException ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}