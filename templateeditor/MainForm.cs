using System;
using System.Windows.Forms;

namespace ProjectTemplateEditor
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class FormMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem itmOpen;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNS;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.MenuItem itmNew;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem itmSave;
        private System.Windows.Forms.MenuItem itmSaveAs;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem itmExit;
        private TreeNode _file;
        private TreeNode _project;
        private TreeNode _folder;
        private string _filename = null;
        private NodeType _nodeType;
        private string _guid = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PropertyGrid propDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHelp;
        private static readonly string AppName = "PN Project Template Editor";

        public FormMain()
        {
            //
            // Required for Windows Form Designer support
            //
            this.InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.itmNew = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.itmOpen = new System.Windows.Forms.MenuItem();
            this.itmSave = new System.Windows.Forms.MenuItem();
            this.itmSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.itmExit = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propDisplay = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tree = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(8, 304);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 24);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Location = new System.Drawing.Point(144, 304);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 24);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "&Remove";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Namespace:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNS
            // 
            this.txtNS.Location = new System.Drawing.Point(88, 40);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(208, 20);
            this.txtNS.TabIndex = 6;
            this.txtNS.Text = "urn:example";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.itmNew,
                                                                                      this.menuItem3,
                                                                                      this.itmOpen,
                                                                                      this.itmSave,
                                                                                      this.itmSaveAs,
                                                                                      this.menuItem6,
                                                                                      this.itmExit});
            this.menuItem1.Text = "&File";
            // 
            // itmNew
            // 
            this.itmNew.Index = 0;
            this.itmNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.itmNew.Text = "&New";
            this.itmNew.Click += new System.EventHandler(this.itmNew_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // itmOpen
            // 
            this.itmOpen.Index = 2;
            this.itmOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.itmOpen.Text = "&Open";
            this.itmOpen.Click += new System.EventHandler(this.itmOpen_Click);
            // 
            // itmSave
            // 
            this.itmSave.Index = 3;
            this.itmSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.itmSave.Text = "&Save";
            this.itmSave.Click += new System.EventHandler(this.itmSave_Click);
            // 
            // itmSaveAs
            // 
            this.itmSaveAs.Index = 4;
            this.itmSaveAs.Text = "Save &As...";
            this.itmSaveAs.Click += new System.EventHandler(this.itmSaveAs_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "-";
            // 
            // itmExit
            // 
            this.itmExit.Index = 6;
            this.itmExit.Text = "E&xit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right);
            this.panel1.Controls.Add(this.propDisplay);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tree);
            this.panel1.Location = new System.Drawing.Point(8, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 232);
            this.panel1.TabIndex = 8;
            // 
            // propDisplay
            // 
            this.propDisplay.CommandsVisibleIfAvailable = true;
            this.propDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propDisplay.LargeButtons = false;
            this.propDisplay.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propDisplay.Location = new System.Drawing.Point(336, 0);
            this.propDisplay.Name = "propDisplay";
            this.propDisplay.Size = new System.Drawing.Size(240, 232);
            this.propDisplay.TabIndex = 5;
            this.propDisplay.Text = "propertyGrid1";
            this.propDisplay.ViewBackColor = System.Drawing.SystemColors.Window;
            this.propDisplay.ViewForeColor = System.Drawing.SystemColors.WindowText;
            this.propDisplay.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propDisplay_PropertyValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(328, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 232);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.ImageList = this.imageList1;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(328, 232);
            this.tree.TabIndex = 3;
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(304, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Icon File:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIcon
            // 
            this.txtIcon.Location = new System.Drawing.Point(384, 40);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(168, 20);
            this.txtIcon.TabIndex = 11;
            this.txtIcon.Text = "";
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(304, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Help File:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(384, 8);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(168, 20);
            this.txtHelp.TabIndex = 9;
            this.txtHelp.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(592, 334);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Text = "PN Project Template Editor";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new FormMain());
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            //tree.
            this._project = new TreeNode("Project", 1, 1);
            this._folder = new TreeNode("Folder", 2, 2);
            this._file = new TreeNode("File", 3, 3);
            this.setup();
        }

        private void itmOpen_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Project Templates (*.pnpt)|*.pnpt",
                CheckFileExists = true
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                this._filename = ofd.FileName;

                FileLoader fl = new FileLoader();
                ProjectConfig theConfig = fl.Load(this._filename);

                this.show(theConfig);

                this.Text = AppName + " - " + System.IO.Path.GetFileName(this._filename);
            }
        }

        private void setup()
        {
            this.tree.Nodes.Clear();
            //tree.Nodes.Add( new TreeNode( "Project Group", 0, 0 ) );

            this.txtIcon.Text = "";
            this.txtHelp.Text = "";
            this.txtName.Text = "";
            this.txtNS.Text = "urn:example";
            this._project.Nodes.Clear();
            this._folder.Nodes.Clear();
            this._file.Nodes.Clear();
            this._project.Tag = new Set(SetType.Project);
            this._folder.Tag = new Set(SetType.Folder);
            this._file.Tag = new Set(SetType.File);

            this.tree.Nodes.Add(this._project);
            this.tree.Nodes.Add(this._folder);
            this.tree.Nodes.Add(this._file);

            this._guid = "{" + System.Guid.NewGuid().ToString() + "}";

            this.enableButtons();
        }

        private void show(ProjectConfig c)
        {
            this.setup();

            this.txtName.Text = c.Name;
            this.txtNS.Text = c.XmlNameSpace;
            this.txtIcon.Text = c.Icon;
            this.txtHelp.Text = c.HelpFile;
            this._guid = c.GUID;

            foreach (Set s in c.Sets)
            {
                switch (s.Type)
                {
                    case SetType.Project:
                        {
                            this._project.Tag = s;
                        }
                        break;
                    case SetType.Folder:
                        {
                            this._folder.Tag = s;
                        }
                        break;
                    case SetType.File:
                        {
                            this._file.Tag = s;
                        }
                        break;
                }
            }

            this.displaySet(this._project);
            this.displaySet(this._folder);
            this.displaySet(this._file);
        }

        private void displaySet(TreeNode tn)
        {
            if (tn.Tag == null)
            {
                return;
            }

            foreach (Group g in ((Set)tn.Tag).Groups)
            {
                TreeNode group = new TreeNode(g.Description, 6, 6)
                {
                    Tag = g
                };
                tn.Nodes.Add(group);

                this.displayGroup(group);
            }

            tn.Expand();
        }

        private void displayGroup(TreeNode group)
        {
            if (group.Tag == null)
            {
                return;
            }

            foreach (Category c in ((Group)group.Tag).Categories)
            {
                TreeNode cat = new TreeNode(c.Description, 4, 4)
                {
                    Tag = c
                };
                group.Nodes.Add(cat);

                this.displayCat(cat);
            }

            group.Expand();
        }

        private void displayCat(TreeNode cat)
        {
            if (cat.Tag == null)
            {
                return;
            }

            foreach (OptionBase o in ((Category)cat.Tag).Options)
            {
                TreeNode opt = new TreeNode(o.Description, 5, 5)
                {
                    Tag = o
                };
                cat.Nodes.Add(opt);
            }

            cat.Expand();
        }

        private void tree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.propDisplay.SelectedObject = null;

            if (e.Node != null && e.Node.Tag != null)
            {
                this.propDisplay.SelectedObject = e.Node.Tag;
            }

            if (this.tree.SelectedNode.Tag is Set)
            {
                this._nodeType = NodeType.Set;
            }
            else if (this.tree.SelectedNode.Tag is Group)
            {
                this._nodeType = NodeType.Group;
            }
            else if (this.tree.SelectedNode.Tag is Category)
            {
                this._nodeType = NodeType.Category;
            }
            else
            {
                this._nodeType = NodeType.Value;
            }

            this.enableButtons();
        }

        private void enableButtons()
        {
            bool selection = this.tree.SelectedNode != null;
            if (selection)
            {
                switch (this._nodeType)
                {
                    case NodeType.Set:
                        this.btnAdd.Text = "Add Group";
                        break;

                    case NodeType.Group:
                        this.btnAdd.Text = "Add Category";
                        break;

                    case NodeType.Value:
                    case NodeType.Category:
                        this.btnAdd.Text = "Add Value";
                        break;
                }
            }

            this.btnAdd.Enabled = selection;
            this.btnRemove.Enabled = selection;
            this.itmSave.Enabled = this._filename != null && this._filename != "";
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            switch (this._nodeType)
            {
                case NodeType.Set:
                    this.addGroup();
                    break;

                case NodeType.Group:
                    this.addCategory();
                    break;

                case NodeType.Value:
                case NodeType.Category:
                    this.addValue();
                    break;
            }
        }

        private void addGroup()
        {
            Set theSet = (Set)this.tree.SelectedNode.Tag;
            Group theGroup = new Group
            {
                Name = "setme",
                Description = "New Option Group"
            };
            theSet.Groups.Add(theGroup);

            this.tree.SelectedNode.Nodes.Clear();
            this.displaySet(this.tree.SelectedNode);
            this.tree.SelectedNode = this.tree.SelectedNode.Nodes[this.tree.SelectedNode.Nodes.Count - 1];
        }

        private void addCategory()
        {
            Group theGroup = (Group)this.tree.SelectedNode.Tag;
            Category theCategory = new Category
            {
                Name = "setme",
                Description = "New Category"
            };
            theGroup.Categories.Add(theCategory);

            this.tree.SelectedNode.Nodes.Clear();
            this.displayGroup(this.tree.SelectedNode);
            this.tree.SelectedNode = this.tree.SelectedNode.Nodes[this.tree.SelectedNode.Nodes.Count - 1];
        }

        private void addValue()
        {
            TypeInputForm tif = new TypeInputForm();
            if (tif.ShowDialog(this) == DialogResult.OK)
            {
                OptionBase theOption = OptionFactory.CreateOption(tif.Result);
                Category theCategory;
                TreeNode theNode;
                if (this.tree.SelectedNode.Tag is Category)
                {
                    theNode = this.tree.SelectedNode;
                }
                else
                {
                    theNode = this.tree.SelectedNode.Parent;
                }

                theCategory = (Category)theNode.Tag;
                theCategory.Options.Add(theOption);
                theNode.Nodes.Clear();
                this.displayCat(theNode);
                this.tree.SelectedNode = theNode.Nodes[theNode.Nodes.Count - 1];
            }
        }

        private void propDisplay_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Description" && this.propDisplay.SelectedObject is IDescribed)
            {
                this.tree.SelectedNode.Text = ((IDescribed)this.propDisplay.SelectedObject).Description;
            }
        }

        private void itmNew_Click(object sender, System.EventArgs e)
        {
            this.setup();
            this.Text = AppName;
            this.enableButtons();
        }

        private void itmSave_Click(object sender, System.EventArgs e)
        {
            this.save();
        }

        private void itmSaveAs_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Project Templates (*.pnpt)|*.pnpt"
            };
            if (this._filename != null)
            {
                sfd.InitialDirectory = System.IO.Path.GetDirectoryName(this._filename);
            }

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                this._filename = sfd.FileName;
                this.save();
                this.Text = AppName + " - " + System.IO.Path.GetFileName(this._filename);
            }
        }

        private void save()
        {
            FileLoader fl = new FileLoader();
            ProjectConfig pc = new ProjectConfig
            {
                Name = this.txtName.Text,
                XmlNameSpace = this.txtNS.Text,
                GUID = this._guid,
                HelpFile = this.txtHelp.Text,
                Icon = this.txtIcon.Text
            };
            if (((Set)this._project.Tag).Groups.Count > 0)
            {
                pc.Sets.Add(this._project.Tag);
            }

            if (((Set)this._file.Tag).Groups.Count > 0)
            {
                pc.Sets.Add(this._file.Tag);
            }

            if (((Set)this._folder.Tag).Groups.Count > 0)
            {
                pc.Sets.Add(this._folder.Tag);
            }

            fl.Save(this._filename, pc);

            this.enableButtons();
        }

        private void itmExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
