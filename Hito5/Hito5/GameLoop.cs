using Hito5;
using Hito5.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

enum Page_Type { INICIO, JUGAR, BANQUETE, EDITAR_MAZO, TIENDA, PARTIDA}

namespace Hito5
{
    internal class InicioLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        MainPage MiPagina = null;
        Controlador MiControl = null;

        public InicioLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as MainPage;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;

        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
    internal class JugarLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        Jugar MiPagina = null;
        Controlador MiControl = null;

        public JugarLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as Jugar;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
    internal class BanqueteLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        Banquete MiPagina = null;
        Controlador MiControl = null;

        public BanqueteLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as Banquete;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
    internal class EditarLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        EditarMazo MiPagina = null;
        Controlador MiControl = null;

        public EditarLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as EditarMazo;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
    internal class TiendaLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        Tienda MiPagina = null;
        Controlador MiControl = null;

        public TiendaLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as Tienda;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
    internal class PartidaLoop
    {
        //Manejar el Timer
        public DispatcherTimer GameTimer;
        Partida MiPagina = null;
        Controlador MiControl = null;

        public PartidaLoop(Page Pagina, Controlador Control)
        {
            MiPagina = Pagina as Partida;
            MiControl = Control;
            GameTimerSetup();
        }

        public void GameTimerSetup()
        {
            GameTimer = new DispatcherTimer();
            GameTimer.Tick += GameTimer_Tick;// dispatcherTimer_Tick;
            GameTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
        }
        void GameTimer_Tick(object sender, object e)
        {   //Los Drones se simulan a nivel de aplicación cada 0.1s
            if (MiControl != null)
            {
                MiControl.LeeMando();                      //Lee GamePAd
                MiControl.DetectaGestosMando();            //Detecta Gestos del Mando
                MiControl.ZMMando();                       //ZonaMuerta JoyStick y Triggers
                MiPagina.ActualizaIU();                    //Aplica cambios en IU y VM
                MiControl.FeedBack();                      //Activa motores del Mando
            }
        }
    }
}
