using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.BusinessLogics;
using AllDeductedBusinessLogic.ViewModels;
using NLog;
using System;
using System.Windows;
using Unity;

namespace AllDeductedView
{
    /// <summary>
    /// Логика взаимодействия для DisciplineWindow.xaml
    /// </summary>
    public partial class DisciplineWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id
        {
            set { id = value; }
        }

        private int? id;

        private readonly DisciplineLogic logic;
        private readonly Logger logger;
        public DisciplineWindow(DisciplineLogic logic)
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            this.logic = logic;
        }
        private void DisciplineWindow_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                DisciplineViewModel discipline = logic.Read(new DisciplineBindingModel
                {
                    Id = id,
                    ProviderId = App.SelectProvider.Id
                })?[0];

                textBoxName.Text = discipline.Name;
                textBoxHoursCount.Text = discipline.HoursCount.ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните поле Name", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxHoursCount.Text))
            {
                MessageBox.Show("Заполните поле HoursCount", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DisciplineBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    HoursCount = Convert.ToInt32(textBoxHoursCount.Text),
                    ProviderId = App.SelectProvider.Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка созранения данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
