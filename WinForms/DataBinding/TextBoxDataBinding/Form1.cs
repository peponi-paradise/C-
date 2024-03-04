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
                OnPropertyChanged();    // 프로퍼티가 변경되었음을 알림
            }
        }

        public Form1()
        {
            InitializeComponent();

            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            TextBox textbox1 = new();   // string 그대로 출력
            TextBox textbox2 = new();   // Format 적용된 string 출력
            Button button = new();      // string 값을 코드에서 업데이트
            button.Click += delegate { TextData += "a"; };

            textbox1.DataBindings.Add(new Binding(nameof(textbox1.Text), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged));
            var binding = new Binding(nameof(textbox2.Text), this, nameof(TextData), false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += TextBoxFormat;
            binding.Parse += TextBoxParse;
            textbox2.DataBindings.Add(binding);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.Controls.Add(textbox1, 0, 0);
            tableLayoutPanel.Controls.Add(textbox2, 1, 0);
            tableLayoutPanel.Controls.Add(button, 2, 0);
            tableLayoutPanel.Size = this.Size;
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }

        private void TextBoxFormat(object? sender, ConvertEventArgs e)
        {
            // Format이 필요한 경우
            if (e.DesiredType == typeof(string))
            {
                e.Value = $"Format - {e.Value}";
            }
        }

        private void TextBoxParse(object? sender, ConvertEventArgs e)
        {
            // Format 설정한 컨트롤이 enabled 상태라면, 조작할 때 format 설정한 값을 빼줘야한다.
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