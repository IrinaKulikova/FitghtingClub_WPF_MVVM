﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitghtingClub_WPF
{

    /** Бойцовскйй клуб
* Разработать игровую программу
* Игровой процесс
* В игре участвуют два игрока. Роль второго игрока исполняет компьютер.
* Игра строится на основе раундов.
* В одном раунде один игрок атакует, другой защищается. Атакующий игрок выбирет для удара часть тела оппонента (голова, корпус, ноги).
* Защищающийся игрок выбирает часть тела для блока (голова,
* корпус, ноги). В момент окончания раунда наступает подсчет результата.
* 1 Если выбор части тела атакующим и защищающимся игроком совпали удар считается заблокированным и очки здоровья не снимаются.
* 2 Если выбор части тела атакующим и защищающимся игроком не совпали удар считается нанесенным и у защищающегося игрока уменьшаются очки здоровья.
* После нанесения ударов проверяется количество очков здоровья у защищаюсего игрока.
* 3 Если очки здоровья защищаюсегося игрока меньше или равны нулю он считается мертвым и атакующий игрок побеждает.
* Если очки здоровья защищаюсегося игрока больше нуля раунд считается оконченным и игроки меняются местами(атакующий становится защищающимся)

* Требования
* 1. Сущность Игрок должна содержать поля Имя игрока (Name), Заблокированную часть тела (Blocked) и Очки здоровья (Hp)
* 2. Части тела для удобства должны реализваться с помощью перечисления
* 3. Сущность Игрок должна содержать методыGetHitпринимающий часть тела для удара и SetBlock для выбора защищаемой части тела
* 4. У сущности игрок должны быть события Блок (Block), Получения урона (Wound) и Смерти (Death)
* 5. Аргументы событий должны возвращать имя игрока и текущие очки здоровья.

* Интерфейс
* 1. Интерфейс программы разрабатывается с помощью WinForms
* 2. На интерфейсе должны отображаться
* a. Имена игроков
* b. Очки здоровья в числовом и графическом формате (progressbar)
* c. Программа должна вести лог боя в текстовом виде
*/


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ViewGame : Window
    {
        //public bool DisaibleControl { get; set; }

        public ViewGame(bool disaibleControl, String playerName)
        {
            InitializeComponent();
            //DisaibleControl = disaibleControl;
            (DataContext as ViewModelGame).IsAIPlayer = disaibleControl;
            (DataContext as ViewModelGame).PlayerName = playerName;
        }
    }
}