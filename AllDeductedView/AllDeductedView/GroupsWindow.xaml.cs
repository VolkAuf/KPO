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
    /// Логика взаимодействия для GroupsWindow.xaml
    /// </summary>
    public partial class GroupsWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly GroupLogic logic;
        private readonly Logger logger;

        public GroupsWindow(GroupLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void GroupsWindow_Loaded(object sender, RoutedEventArgs e)
        {
             LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(new GroupBindingModel
                {
                    ProviderId = App.SelectProvider.Id
                });
                if (list != null)
                {
                    dataGridGroups.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<GroupWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridGroups.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<GroupWindow>();
                int id = ((GroupViewModel)dataGridGroups.SelectedItems[0]).Id;
                form.Id = id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridGroups.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((GroupViewModel)dataGridGroups.SelectedItems[0]).Id;
                    try
                    {
                        logic.Delete(new GroupBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка удаления данных : " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}