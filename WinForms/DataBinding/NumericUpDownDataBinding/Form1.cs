using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NumericUpDownDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        // INotifyPropertyChanged ����
        public event PropertyChangedEventHandler? PropertyChanged;

        private double _doubleData = 0;

        public double DoubleData
        {
            get => _doubleData;
            set
            {
                _doubleData = value;
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
            NumericUpDown numericUpDown = new();
            Button button = new();
            button.Click += delegate { DoubleData++; };     // Ŭ���� ������ +1

            numericUpDown.DataBindings.Add(new Binding(nameof(numericUpDown.Value), this, nameof(DoubleData), false, DataSourceUpdateMode.OnPropertyChanged));

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.Controls.Add(numericUpDown, 0, 0);
            tableLayoutPanel.Controls.Add(button, 1, 0);
            tableLayoutPanel.Size = this.Size;
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}