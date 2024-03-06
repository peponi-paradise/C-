using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RichTextBoxDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        // INotifyPropertyChanged ����
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _textData = string.Empty;

        public string TextData
        {
            get => _textData;
            set
            {
                _textData = value;
                OnPropertyChanged();    // ������Ƽ�� ����Ǿ����� �˸�
            }
        }

        private const string _sampleRTF = "{\\rtf1\\ansi\\ansicpg949\\deff0\\nouicompat\\deflang1033\\deflangfe1042{\\fonttbl{\\f0\\fnil\\fcharset0 Arial;}}\r\n{\\colortbl ;\\red0\\green77\\blue187;\\red0\\green0\\blue255;}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\sa200\\sl276\\slmult1\\fs20\\lang18 Hello, World!\\par\r\n\\cf1 Hello, World!\\cf0\\par\r\n\\i Hello, World!\\par\r\n\\b\\i0 Hello, World!\\par\r\n{\\i{\\field{\\*\\fldinst{HYPERLINK https://google.com }}{\\fldrslt{https://google.com\\ul0\\cf0}}}}\\f0\\fs20\\par\r\n}";

        public Form1()
        {
            InitializeComponent();

            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            RichTextBox textBox = new() { Dock = DockStyle.Fill, Height = 300 };
            TextBox checkInput = new() { Multiline = true, WordWrap = true, Dock = DockStyle.Fill, ScrollBars = ScrollBars.Vertical };       // �ؽ�Ʈ �Է� Ȯ�ο�
            Button button = new() { Text = "Sample" };
            button.Click += delegate { TextData = _sampleRTF; };        // ���� RTF �Է�

            // RichTextBox �Է� �� ��Ŀ�� �̵��ؾ� TextData�� ������Ʈ��
            // textBox.DataBindings.Add(new Binding(nameof(textBox.Text), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged));  // �Ϲ� �ؽ�Ʈ
            textBox.DataBindings.Add(new Binding(nameof(textBox.Rtf), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged));      // RTF �ؽ�Ʈ
            checkInput.DataBindings.Add(new Binding(nameof(checkInput.Text), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged));

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new(SizeType.Percent, 80));
            tableLayoutPanel.ColumnStyles.Add(new(SizeType.Percent, 20));
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.Controls.Add(textBox, 0, 0);
            tableLayoutPanel.Controls.Add(checkInput, 0, 1);
            tableLayoutPanel.Controls.Add(button, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}