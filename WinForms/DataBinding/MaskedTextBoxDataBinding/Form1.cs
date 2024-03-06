using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaskedTextBoxDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        // INotifyPropertyChanged ����
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _mask = "000-0000-0000";

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                OnPropertyChanged();    // ������Ƽ�� ����Ǿ����� �˸�
            }
        }

        private string _inputText = string.Empty;

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
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
            MaskedTextBox textBox = new();
            Label checkInput = new();       // �ؽ�Ʈ �Է� Ȯ�ο�
            Button button = new();
            button.Click += delegate { InputText = "010-1234-5678"; };      // ���ڿ� �ʱ�ȭ

            textBox.DataBindings.Add(new Binding(nameof(textBox.Mask), this, nameof(Mask), false, DataSourceUpdateMode.OnPropertyChanged));
            textBox.DataBindings.Add(new Binding(nameof(textBox.Text), this, nameof(InputText), false, DataSourceUpdateMode.OnPropertyChanged));
            checkInput.DataBindings.Add(new Binding(nameof(checkInput.Text), this, nameof(InputText), false, DataSourceUpdateMode.OnPropertyChanged));

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
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