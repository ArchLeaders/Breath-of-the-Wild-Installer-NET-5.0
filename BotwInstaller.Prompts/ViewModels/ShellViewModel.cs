﻿using BotwInstaller.Prompts.Views;
using BotwInstaller.Prompts.ViewThemes.ControlStyles;
using MaterialDesignThemes.Wpf;
using Stylet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BotwInstaller.Prompts.ViewModels
{
    public class ShellViewModel : Screen
    {
        public void SwitchTheme()
        {
            PaletteHelper helper = new();
            ITheme theme = helper.GetTheme();

            string file = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\BotwInstaller.Prompts\\settings.ini";
            string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\BotwInstaller.Prompts\\";
            Directory.CreateDirectory(folder);

            if (theme.GetBaseTheme() == BaseTheme.Light)
            {
                AppTheme.Change();
                File.WriteAllText(file, "dark");
            }
            else if (theme.GetBaseTheme() == BaseTheme.Dark)
            {
                AppTheme.Change(true);
                File.WriteAllText(file, "light");
            }
            else
            {
                AppTheme.Change();
                File.WriteAllText(file, "dark");
            }
        }
    }
}
