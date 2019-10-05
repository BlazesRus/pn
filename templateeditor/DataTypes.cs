using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ProjectTemplateEditor
{
    public enum NodeType
    {
        Set,
        Group,
        Category,
        Value
    };

    public enum SetType
    {
        [XmlEnum("project")]
        Project,
        [XmlEnum("folder")]
        Folder,
        [XmlEnum("file")]
        File
    };

    public enum ValueType
    {
        FolderPath,
        FilePath,
        Text,
        Boolean,
        Integer,
        OptionList
    };

    public interface IDescribed
    {
        string Description
        {
            get;
        }
    }

    public class OptionBase : IDescribed
    {
        private string _name = "setme";
        private string _desc = "New Option";
        protected string _default = "";
        private int _helpid = 0;

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlAttribute("description")]
        public string Description
        {
            get => this._desc;
            set => this._desc = value;
        }

        [XmlAttribute("default"), Browsable(false)]
        public string DefaultValue
        {
            get => this._default;
            set => this._default = value;
        }

        [XmlAttribute("helpid")]
        public int HelpID
        {
            get => this._helpid;
            set => this._helpid = value;
        }
    }

    [XmlRoot("folderPath")]
    public class FolderPath : OptionBase
    {
    }

    [XmlRoot("filePath")]
    public class FilePath : OptionBase
    {
    }

    [XmlRoot("value")]
    public class OptionListValue
    {
        private string _desc = "";
        private string _value = "";

        [XmlAttribute("description")]
        public string Description
        {
            get => this._desc;
            set => this._desc = value;
        }

        [XmlAttribute("value")]
        public string Value
        {
            get => this._value;
            set => this._value = value;
        }

        public override string ToString()
        {
            return this.Value + " : " + this.Description;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }

    public class OptionListDesigner : System.ComponentModel.Design.CollectionEditor
    {
        public OptionListDesigner() : base(typeof(ArrayList))
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(OptionListValue);
        }

        protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()
        {
            System.ComponentModel.Design.CollectionEditor.CollectionForm form = base.CreateCollectionForm();
            form.Text = "Option List Editor";

            // Make most of the buttons a bit nicer!
            foreach (System.Windows.Forms.Control c in form.Controls)
            {
                System.Windows.Forms.Button b = c as System.Windows.Forms.Button;
                if (b != null)
                {
                    if (b.Image == null)
                    {
                        b.FlatStyle = System.Windows.Forms.FlatStyle.System;
                    }
                }
            }

            return form;
        }


    };

    [XmlRoot("optionlist")]
    public class OptionList : OptionBase
    {
        private ArrayList _values = new ArrayList();

        [XmlIgnore]
        public string Default
        {
            get => this.DefaultValue;
            set => this.DefaultValue = value;
        }

        [XmlElement("value", typeof(OptionListValue)),
        Editor(typeof(OptionListDesigner), typeof(System.Drawing.Design.UITypeEditor))]
        public ArrayList Values
        {
            get => this._values;
            set => this._values = value;
        }
    }

    [XmlRoot("option")]
    public class Option : OptionBase
    {
        [XmlIgnore]
        public bool Default
        {
            get { if (this._default != string.Empty) { return System.Xml.XmlConvert.ToBoolean(this._default); } return false; }
            set => this._default = System.Xml.XmlConvert.ToString(value);
        }
    }

    [XmlRoot("text")]
    public class Text : OptionBase
    {
        [XmlIgnore]
        public string Default
        {
            get => this._default;
            set => this._default = value;
        }
    }

    [XmlRoot("int")]
    public class IntOption : OptionBase
    {
        [XmlIgnore]
        public int Default
        {
            get { if (this._default != string.Empty) { return System.Xml.XmlConvert.ToInt32(this._default); } return 0; }
            set => this._default = System.Xml.XmlConvert.ToString(value);
        }
    }

    public class OptionFactory
    {
        public static OptionBase CreateOption(ValueType vt)
        {
            switch (vt)
            {
                case ValueType.Integer:
                    return new IntOption();
                case ValueType.Boolean:
                    return new Option();
                case ValueType.FilePath:
                    return new FilePath();
                case ValueType.FolderPath:
                    return new FolderPath();
                case ValueType.OptionList:
                    return new OptionList();
                case ValueType.Text:
                    return new Text();
                default:
                    throw new ApplicationException("Unexpected ValueType value");
            }
        }

        private OptionFactory()
        {
        }
    }

    [XmlRoot("category")]
    public class Category : IDescribed
    {
        private string _name;
        private string _desc;
        private ArrayList _options = new ArrayList();

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlAttribute("description")]
        public string Description
        {
            get => this._desc;
            set => this._desc = value;
        }

        [Browsable(false),
        XmlElement("option", typeof(Option)),
        XmlElement("optionlist", typeof(OptionList)),
        XmlElement("int", typeof(IntOption)),
        XmlElement("text", typeof(Text)),
        XmlElement("filePath", typeof(FilePath)),
        XmlElement("folderPath", typeof(FolderPath))]
        public ArrayList Options
        {
            get => this._options;
            set => this._options = value;
        }
    }

    [XmlRoot("group")]
    public class Group : IDescribed
    {
        private string _name;
        private string _desc;
        private ArrayList _cats = new ArrayList();

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlAttribute("description")]
        public string Description
        {
            get => this._desc;
            set => this._desc = value;
        }

        [Browsable(false),
        XmlElement("category", typeof(Category))]
        public ArrayList Categories
        {
            get => this._cats;
            set => this._cats = value;
        }
    }



    [XmlRoot("set")]
    public class Set
    {
        private SetType _type;
        private ArrayList _groups = new ArrayList();

        [XmlAttribute("type"), Browsable(false)]
        public SetType Type
        {
            set => this._type = value;
            get => this._type;
        }

        [Browsable(false),
        XmlElement("group", typeof(Group))]
        public ArrayList Groups
        {
            get => this._groups;
            set => this._groups = value;
        }

        public Set()
        {
        }

        public Set(SetType type)
        {
            this._type = type;
        }
    }

    [XmlRoot("projectConfig")]
    public class ProjectConfig
    {
        private string _name;
        private string _helpfile;
        private string _id;
        private string _ns;
        private string _icon;
        private ArrayList _sets = new ArrayList();

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlAttribute("helpfile")]
        public string HelpFile
        {
            get => this._helpfile;
            set => this._helpfile = value;
        }

        [XmlAttribute("id")]
        public string GUID
        {
            get => this._id;
            set => this._id = value;
        }

        [XmlAttribute("icon")]
        public string Icon
        {
            get => this._icon;
            set => this._icon = value;
        }

        [XmlAttribute("ns")]
        public string XmlNameSpace
        {
            get => this._ns;
            set => this._ns = value;
        }

        [Browsable(false),
        XmlElement("set", typeof(Set))]
        public ArrayList Sets
        {
            get => this._sets;
            set => this._sets = value;
        }
    }

    public class FileLoader
    {
        public ProjectConfig Load(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ProjectConfig));
            // TODO: Exceptions...
            System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(filename);
            ProjectConfig pc = (ProjectConfig)xs.Deserialize(xtr);
            xtr.Close();
            return pc;
        }

        public void Save(string filename, ProjectConfig projConf)
        {
            System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(filename, System.Text.Encoding.UTF8)
            {
                Formatting = System.Xml.Formatting.Indented,
                Indentation = 1,
                IndentChar = '\t'
            };
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(ProjectConfig));
            xs.Serialize(xtw, projConf, xsn);
            xtw.Close();
        }
    }
}
