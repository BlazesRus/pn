using System.Collections;
using System.Xml.Serialization;

namespace TextClipCreator
{
    /// <summary>
    /// Collection of Text Clips
    /// </summary>
    [XmlRoot("clips")]
    public class Clips
    {
        private string _name = "";
        private ArrayList _clips = new ArrayList();
        private bool _modified = false;

        public Clips()
        {
        }

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlElement("clip", Type = typeof(Clip))]
        public ArrayList TextClips
        {
            get => this._clips;
            set => this._clips = value;
        }

        public bool Modified
        {
            get => this._modified;
            set => this._modified = value;
        }

    }

    /// <summary>
    /// One Text Clip
    /// </summary>
    public class Clip
    {
        private string _name = "";
        private string _content = "";

        public Clip()
        {
        }

        public Clip(string name)
        {
            this._name = name;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        [XmlText]
        public string Content
        {
            get => this._content;
            set => this._content = value;
        }

        public override string ToString()
        {
            return this._name;
        }
    }

    /// <summary>
    /// Load and Save TextClip files
    /// </summary>
    public class ClipStorage
    {
        private static XmlSerializer s_ser = null;
        private readonly System.Xml.Serialization.XmlSerializerNamespaces s_xsn = null;

        public ClipStorage()
        {
            if (s_ser == null)
            {
                s_ser = new XmlSerializer(typeof(Clips));
                this.s_xsn = new XmlSerializerNamespaces();
                this.s_xsn.Add("", "");
            }
        }

        public Clips Load(string filename)
        {
            System.Xml.XmlTextReader xtw = new System.Xml.XmlTextReader(filename);
            try
            {
                Clips clips = (Clips)s_ser.Deserialize(xtw);
                return clips;
            }
            finally
            {
                xtw.Close();
            }
        }

        public void Save(Clips clips, string filename)
        {
            System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(filename, System.Text.Encoding.UTF8);
            try
            {
                xtw.Formatting = System.Xml.Formatting.Indented;
                s_ser.Serialize(xtw, clips, this.s_xsn);
            }
            finally
            {
                xtw.Close();
            }
        }
    }
}
