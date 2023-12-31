﻿using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.BusinessLogics;
using AllDeductedBusinessLogic.ViewModels;
using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace AllDeductedView
{
    /// <summary>
    /// Логика взаимодействия для ListDisciplineWindow.xaml
    /// </summary>
    public partial class ListDisciplineWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogic reportLogic;
        private readonly StudentLogic studentLogic;
        private readonly Logger logger;

        public ListDisciplineWindow(StudentLogic studentLogic, ReportLogic reportLogic)
        {
            this.studentLogic = studentLogic;
            this.reportLogic = reportLogic;
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
        }

        public void ListDisciplineWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = studentLogic.Read(new StudentBindingModel
                {
                    ProviderId = App.SelectProvider.Id
                });
                if (list != null)
                {
                    dataGridStudents.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStudents.SelectedItem == null || dataGridStudents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Студент не выбран", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var dialog = new SaveFileDialog {Filter = "docx|*.docx"};
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    var list = new List<StudentViewModel>();
                    foreach (var student in dataGridStudents.SelectedItems)
                    {
                        list.Add((StudentViewModel) student);
                    }

                    reportLogic.SaveToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        Students = list,
                    });
                    MessageBox.Show("Формирование завершено", "ОК", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка создания файла .doc : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonExcel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStudents.SelectedItem == null || dataGridStudents.SelectedItems.Count == 0)
            {
                MessageBox.Show("Студент не выбран", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            var dialog = new SaveFileDialog {Filter = "xls|*.xlsx"};
            try
            {
                if (dialog.ShowDialog() != true) 
                    return;

                var list = new List<StudentViewModel>();
                foreach (var student in dataGridStudents.SelectedItems)
                {
                    list.Add((StudentViewModel) student);
                }

                reportLogic.SaveToExcelFile(new ReportBindingModel
                {
                    FileName = dialog.FileName,
                    Students = list,
                });
                MessageBox.Show("Формирование завершено", "ОК", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка создания файла .xls : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}