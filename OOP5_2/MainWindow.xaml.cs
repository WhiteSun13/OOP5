﻿using System.Windows;
using MeasuringDevice;

namespace OOP5_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IMeasuringDevice device;

        private void createInstance_Click(object sender, RoutedEventArgs e)
        {
            if (lengthRadio.IsChecked == true)
            {
                if (imperialRadio.IsChecked == true)
                {
                    device = new MeasureLengthDevice(Units.Imperial);
                }
                else if (metricRadio.IsChecked == true)
                {
                    device = new MeasureLengthDevice(Units.Metric);
                }
            }
            else if (massRadio.IsChecked == true)
            {
                if (imperialRadio.IsChecked == true)
                {
                    device = new MeasureMassDevice(Units.Imperial);
                }
                else if (metricRadio.IsChecked == true)
                {
                    device = new MeasureMassDevice(Units.Metric);
                }
            }
        }

        private void startCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StartCollecting();
        }

        private void stopCollecting_Click(object sender, RoutedEventArgs e)
        {
            device.StopCollecting();
        }

        private void getRawData_Click(object sender, RoutedEventArgs e)
        {
            int[] rawData = device.GetRawData();
            rawDataList.Items.Clear();
            foreach (int data in rawData)
            {
                rawDataList.Items.Add(data);
            }
        }

        private void getMetricValue_Click(object sender, RoutedEventArgs e)
        {
            decimal metricValue = device.MetricValue();
            metricValueLabel.Content = metricValue.ToString();
        }

        private void getImperialValue_Click(object sender, RoutedEventArgs e)
        {
            decimal imperialValue = device.ImperialValue();
            imperialValueLabel.Content = imperialValue.ToString();
        }
    }
}