﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSkills.ViewModel
{
    public class MenuViewModel
    {

        //ctor
        public MenuViewModel()
        {

        }

        public IMainWindowsCodeBehind CodeBehind { get; set; }


        /// <summary>
        /// Переход к первой вьюшке
        /// </summary>
        private RelayCommand _LoadFirstUCCommand;
        public RelayCommand LoadFirstUCCommand
        {
            get
            {
                return _LoadFirstUCCommand = _LoadFirstUCCommand ??
                  new RelayCommand(OnLoadFirstUC, CanLoadFirstUC);
            }
        }
        private bool CanLoadFirstUC()
        {
            return true;
        }
        private void OnLoadFirstUC()
        {
            CodeBehind.LoadView(ViewType.First);
        }


        /// <summary>
        /// Переход ко Второй вьюшке
        /// </summary>
        private RelayCommand _LoadSecondUCCommand;
        public RelayCommand LoadSecondUCCommand
        {
            get
            {
                return _LoadSecondUCCommand = _LoadSecondUCCommand ??
                  new RelayCommand(OnLoadSecondUC, CanLoadSecondUC);
            }
        }
        private bool CanLoadSecondUC()
        {
            return true;
        }
        private void OnLoadSecondUC()
        {
            CodeBehind.LoadView(ViewType.Settings);
        }


        /// <summary>
        /// Возвращение к главной вьюшке
        /// </summary>
        private RelayCommand _LoadMainUCCommand;
        public RelayCommand LoadMainUCCommand
        {
            get
            {
                return _LoadMainUCCommand = _LoadMainUCCommand ??
                  new RelayCommand(OnLoadMainUC, CanLoadMainUC);
            }
        }
        private bool CanLoadMainUC()
        {
            return true;
        }
        private void OnLoadMainUC()
        {
            CodeBehind.LoadView(ViewType.Main);
        }

    }
}
