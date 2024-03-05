using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonthCalendarDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        // INotifyPropertyChanged ����
        public event PropertyChangedEventHandler? PropertyChanged;

        private SelectionRange _range = new() { Start = DateTime.Today, End = DateTime.Today.AddDays(4) };

        public SelectionRange TimeRange
        {
            get => _range;
            set
            {
                _range = value;
                OnPropertyChanged();        // ������Ƽ�� ����Ǿ����� �˸�
            }
        }

        public Form1()
        {
            InitializeComponent();

            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            MonthCalendar monthCalendar = new();
            TextBox textBox = new() { Width = 200 };
            Button button = new();
            button.Click += delegate { TimeRange = new(DateTime.Today, DateTime.Today.AddDays(4)); };   // ��¥ ����

            monthCalendar.DataBindings.Add(new Binding(nameof(monthCalendar.SelectionRange), this, nameof(TimeRange), false, DataSourceUpdateMode.OnPropertyChanged));

            // Ķ���� ���� �� ��Ŀ�� �̵��ؾ� TimeRange�� ������Ʈ��
            textBox.DataBindings.Add(new Binding(nameof(textBox.Text), this, nameof(TimeRange), false, DataSourceUpdateMode.OnPropertyChanged));

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.Controls.Add(monthCalendar, 0, 0);
            tableLayoutPanel.Controls.Add(textBox, 1, 0);
            tableLayoutPanel.Controls.Add(button, 1, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            this.Controls.Add(tableLayoutPanel);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}