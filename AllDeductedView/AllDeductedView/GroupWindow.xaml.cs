using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.BusinessLogics;
using AllDeductedBusinessLogic.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Unity;

namespace AllDeductedView
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly GroupLogic logic;
        private readonly DisciplineLogic logicD;
        private Dictionary<int, string> linkDiscipline;
        private Dictionary<int, string> linkOrders;
        private readonly Logger logger;

        public int Id
        {
            set { id = value; }
        }

        private int? id;

        public GroupWindow(GroupLogic logic, DisciplineLogic logicD)
        {
            InitializeComponent();
            this.logic = logic;
            this.logicD = logicD;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void GroupWindow_Load(object sender, RoutedEventArgs e)
        {
            if (!id.HasValue)
                return;

            try
            {
                var element = logic.Read(new GroupBindingModel
                {
                    Id = id.Value,
                    ProviderId = App.SelectProvider.Id
                }).FirstOrDefault();
                if (element != null)
                {
                    textBoxCurator.Text = element.CuratorName;
                    textBoxName.Text = element.Name;
                }

                var listD = logicD.Read(new DisciplineBindingModel
                {
                    ProviderId = App.SelectProvider.Id
                });
                listBoxDiscipline.ItemsSource = listD;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReloadList()
        {
            listBoxLinkDiscipline.Items.Clear();
            foreach (var ld in linkDiscipline)
            {
                listBoxLinkDiscipline.Items.Add(new GroupViewModel { Id = ld.Key, Name = ld.Value });
            }
        }

        private void LoadData()
        {
            try
            {
                GroupViewModel view = logic.Read(new GroupBindingModel
                {
                    Id = id,
                    ProviderId = App.SelectProvider.Id,
                }).FirstOrDefault();
                if (view != null)
                {
                    linkDiscipline = view.Discipline;
                    linkOrders = view.Orders;
                }
                else
                {
                    linkDiscipline = new Dictionary<int, string>();
                    linkOrders = new Dictionary<int, string>();
                }

                ReloadList();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка чтения данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!linkDiscipline.ContainsKey((int)listBoxDiscipline.SelectedValue))
            {
                linkDiscipline.Add((int)listBoxDiscipline.SelectedValue,
                    ((GroupViewModel)listBoxDiscipline.SelectedItem).Name);
                ReloadList();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxLinkDiscipline.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Удалить запись", "Вопрос",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        linkDiscipline.Remove((int)listBoxLinkDiscipline.SelectedValue);
                        ReloadList();
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка удаления данных : " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logic.CreateOrUpdate(new GroupBindingModel
                {
                    Id = id,
                    Discipline = linkDiscipline,
                    Order = linkOrders,
                    CuratorName = textBoxCurator.Text,
                    Name = textBoxName.Text,
                    ProviderId = App.SelectProvider.Id
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка сохранения данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}