using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextBoxDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
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

        public Form1()
        {
            InitializeComponent();

            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            TextBox textbox1 = new();
            TextBox textbox2 = new();

            textbox1.DataBindings.Add(new Binding(nameof(textbox1.Text), this, nameof(TextData), true, DataSourceUpdateMode.OnPropertyChanged, "#,0.00"));
            var binding = new Binding(nameof(textbox2.Text), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += TextBoxFormat;
            binding.Parse += TextBoxParse;
            textbox2.DataBindings.Add(binding);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(textbox1, 0, 0);
            tableLayoutPanel.Controls.Add(textbox2, 1, 0);
            tableLayoutPanel.Size = this.Size;
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }

        private void TextBoxFormat(object? sender, ConvertEventArgs e)
        {
            // Format�� �ʿ��� ���
            if (e.DesiredType == typeof(string))
            {
                e.Value = $"Format - {e.Value}";
            }
        }

        private void TextBoxParse(object? sender, ConvertEventArgs e)
        {
            // Format ������ ��Ʈ���� enabled ���¶��, ������ �� format ������ ���� ������Ѵ�.
            if (e.DesiredType == typeof(string) && e.Value is not null)
            {
                if (((string)e.Value).Contains("Format - "))
                {
                    e.Value = ((string)e.Value).Replace("Format - ", "");
                }
                else e.Value = "";
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}