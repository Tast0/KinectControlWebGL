//2017年10月16日 21:48:12完成编译
//在kinectControl.cs中可以进行修改，实现双手识别，现在只是右手识别

using System.Windows;
using System.Windows.Input;

namespace KinectV2MouseControl
{
    public partial class MainWindow : Window
    {//实例化一个对象，并初始化
        KinectControl kinectCtrl = new KinectControl();

        public MainWindow()
        {
            //加载组件的编译页面
            InitializeComponent();
        }
        //鼠标灵敏度值改变
        private void MouseSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MouseSensitivity.IsLoaded)
            {
                kinectCtrl.mouseSensitivity = (float)MouseSensitivity.Value;
                txtMouseSensitivity.Text = kinectCtrl.mouseSensitivity.ToString("f2");
                //库函数设置鼠标灵敏度
                Properties.Settings.Default.MouseSensitivity = kinectCtrl.mouseSensitivity;
                Properties.Settings.Default.Save();
            }
        }
        //暂停点击时间值改变
        private void PauseToClickTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PauseToClickTime.IsLoaded)
            {
                kinectCtrl.timeRequired = (float)PauseToClickTime.Value;
                txtTimeRequired.Text = kinectCtrl.timeRequired.ToString("f2");

                Properties.Settings.Default.PauseToClickTime = kinectCtrl.timeRequired;
                Properties.Settings.Default.Save();
            }
        }
        //键盘鼠标灵敏度键
        private void txtMouseSensitivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtMouseSensitivity.Text, out v))
                {
                    MouseSensitivity.Value = v;
                    kinectCtrl.mouseSensitivity = (float)MouseSensitivity.Value;
                }
            }
        }
        //需要关闭的时间
        private void txtTimeRequired_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtTimeRequired.Text, out v))
                {
                    PauseToClickTime.Value = v;
                    kinectCtrl.timeRequired = (float)PauseToClickTime.Value;
                }
            }
        }
        //窗口加载
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MouseSensitivity.Value = Properties.Settings.Default.MouseSensitivity;
            PauseToClickTime.Value = Properties.Settings.Default.PauseToClickTime;
            PauseThresold.Value = Properties.Settings.Default.PauseThresold;
            chkNoClick.IsChecked = !Properties.Settings.Default.DoClick;
            CursorSmoothing.Value = Properties.Settings.Default.CursorSmoothing;
            if (Properties.Settings.Default.GripGesture)
            {
                rdiGrip.IsChecked = true;
            }
            else
            {
                rdiPause.IsChecked = true;
            }

        }
        //暂停Thresold值改变
        private void PauseThresold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PauseThresold.IsLoaded)
            {
                kinectCtrl.pauseThresold = (float)PauseThresold.Value;
                txtPauseThresold.Text = kinectCtrl.pauseThresold.ToString("f2");

                Properties.Settings.Default.PauseThresold = kinectCtrl.pauseThresold;
                Properties.Settings.Default.Save();
            }
        }
        //txt暂停三键
        private void txtPauseThresold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float v;
                if (float.TryParse(txtPauseThresold.Text, out v))
                {
                    PauseThresold.Value = v;
                    kinectCtrl.timeRequired = (float)PauseThresold.Value;
                }
            }
        }
        //恢复初始化设置
        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            MouseSensitivity.Value = KinectControl.MOUSE_SENSITIVITY;
            PauseToClickTime.Value = KinectControl.TIME_REQUIRED;
            PauseThresold.Value = KinectControl.PAUSE_THRESOLD;
            CursorSmoothing.Value = KinectControl.CURSOR_SMOOTHING;

            chkNoClick.IsChecked = !KinectControl.DO_CLICK;
            rdiGrip.IsChecked = KinectControl.USE_GRIP_GESTURE;
        }
        //没有点击的检查
        private void chkNoClick_Checked(object sender, RoutedEventArgs e)
        {
            chkNoClickChange();
        }

        //没有点击改变
        public void chkNoClickChange()
        {
            kinectCtrl.doClick = !chkNoClick.IsChecked.Value;
            Properties.Settings.Default.DoClick = kinectCtrl.doClick;
            Properties.Settings.Default.Save();
        }
        //没有点击的不检查
        private void chkNoClick_Unchecked(object sender, RoutedEventArgs e)
        {
            chkNoClickChange();
        }
        //窗口关闭
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            kinectCtrl.Close();
        }
        //控制姿态变化
        public void rdiGripGestureChange()
        {
            kinectCtrl.useGripGesture = rdiGrip.IsChecked.Value;
            Properties.Settings.Default.GripGesture = kinectCtrl.useGripGesture;
            Properties.Settings.Default.Save();
        }
        //控制检查
        private void rdiGrip_Checked(object sender, RoutedEventArgs e)
        {
            rdiGripGestureChange();
        }
        //暂停检查
        private void rdiPause_Checked(object sender, RoutedEventArgs e)
        {
            rdiGripGestureChange();
        }
        //光标平滑值改变
        private void CursorSmoothing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CursorSmoothing.IsLoaded)
            {
                kinectCtrl.cursorSmoothing = (float)CursorSmoothing.Value;
                txtCursorSmoothing.Text = kinectCtrl.cursorSmoothing.ToString("f2");
                //库函数设置鼠标平滑度
                Properties.Settings.Default.CursorSmoothing = kinectCtrl.cursorSmoothing;
                Properties.Settings.Default.Save();
            }
        }


    }


}
