using System;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using Microsoft.Kinect;

namespace KinectV2MouseControl
{
    class KinectControl
    {
        /// <summary>
        ///激活Kinect传感器
        /// </summary>
        KinectSensor sensor;
        /// <summary>
        /// 读者的身体帧数
        /// </summary>
        BodyFrameReader bodyFrameReader;
        /// <summary>
        ///数组的身体
        /// </summary>
        private Body[] bodies = null;
        /// <summary>
        /// 屏幕宽度和高度来确定精确的鼠标灵敏度
        /// </summary>
        int screenWidth, screenHeight;

        /// <summary>
        /// 计时器pause-to-click特性
        /// </summary>
        DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// 根据你的手的动作光标移动的距离有多远
        /// </summary>
        public float mouseSensitivity = MOUSE_SENSITIVITY;

        /// <summary>
        /// 暂停时需要的时间
        /// </summary>
        public float timeRequired = TIME_REQUIRED;
        /// <summary>
        /// 你的手在一个院的半径范围内移动多久，会被认为是一种点击的点击。
        /// </summary>
        public float pauseThresold = PAUSE_THRESOLD;
        /// <summary>
        /// 决定用户是否需要点击鼠标或移动光标
        /// </summary>
        public bool doClick = DO_CLICK;
        /// <summary>
        /// 使用握拳手势点击或不点击
        /// </summary>
        public bool useGripGesture = USE_GRIP_GESTURE;
        /// <summary>
        /// 值0 - 0.95f，它越大，光标移动的越平滑
        /// </summary>
        public float cursorSmoothing = CURSOR_SMOOTHING;

        // 默认值
        public const float MOUSE_SENSITIVITY = 1.8f;
        public const float TIME_REQUIRED = 2f;
        public const float PAUSE_THRESOLD = 60f;
        public const bool DO_CLICK = true;
        public const bool USE_GRIP_GESTURE = true;
        public const float CURSOR_SMOOTHING = 0.9f;

        /// <summary>
        /// 确定我们是否跟踪了这只手并用它来移动光标， 
        /// 如果是假的，意思是用户可能无法举起手，
        /// 我们就不会得到最后的手位置，而一些动作，比如pause-to-click也不会被执行。
        /// </summary>
        bool alreadyTrackedPos = false;

        /// <summary>
        /// 用于存储用于使用pause-to-click的时间
        /// </summary>
        float timeCount = 0;
        /// <summary>
        /// 存储最后的光标位置
        /// </summary>
        Point lastCurPos = new Point(0, 0);

        /// <summary>
        /// 如果是真的，用户就会做左手握拳手势
        /// </summary>
        bool wasLeftGrip = false;
        /// <summary>
        /// 如果是正确的，用户就会做出右手握拳的手势  
        /// </summary>
        bool wasRightGrip = false;
        //构造函数
        public KinectControl()
        {
            // 得到可用的Kinect传感器
            sensor = KinectSensor.GetDefault();
            // 为身体框架打开解读器
            bodyFrameReader = sensor.BodyFrameSource.OpenReader();
            bodyFrameReader.FrameArrived += bodyFrameReader_FrameArrived;

            //获得屏幕和高度
            screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            // 设置定时器，每0.1秒执行一次
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100); 
　　　　    timer.Tick += new EventHandler(Timer_Tick);
　　　　    timer.Start();

           // 打开传感器
            sensor.Open();
        }


        
        /// <summary>
        ///点击暂停计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Timer_Tick(object sender, EventArgs e)
        {
            if (!doClick || useGripGesture) return;

            if (!alreadyTrackedPos) {
                timeCount = 0;
                return;
            }
            
            Point curPos = MouseControl.GetCursorPosition();
            //光标落在按钮范围内
            if ((lastCurPos - curPos).Length < pauseThresold)
            {//并且停留时间大于设置时间，实现点击事件
                if ((timeCount += 0.1f) > timeRequired)
                {
                    //MouseControl.MouseLeftDown();
                    //MouseControl.MouseLeftUp();
                    MouseControl.DoMouseClick();
                    timeCount = 0;
                }
            }
            else
            {
                timeCount = 0;
            }

            lastCurPos = curPos;
        }

        /// <summary>
        ///阅读的身体框架
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            //获取一帧身体数据
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }
             
                    //第一次GetAndRefreshBodyData被调用时，Kinect将在数组中分配每个主体。
                    //只要这些物体不被处理，并且在数组中不被设置为空，
                    //这些物体将被重新使用。
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }

            if (!dataReceived) 
            {
                alreadyTrackedPos = false;
                return;
            }

            foreach (Body body in this.bodies)
            {

                //第一个被跟踪的身体，注意下面有一个休息。
                if (body.IsTracked)
                {
                    // 得到各种骨骼位置
                    CameraSpacePoint handLeft = body.Joints[JointType.HandLeft].Position;
                    CameraSpacePoint handRight = body.Joints[JointType.HandRight].Position;
                    CameraSpacePoint spineBase = body.Joints[JointType.SpineBase].Position;
                    // 如果右手向前推进
                    if (handRight.Z - spineBase.Z < -0.15f) 
                    {             
                        //用这个计算的手x。我们不使用右肩作为参考，
                        //因为肩膀的右肩通常是在升力的后面，而这个位置是推断和不稳定的。
                        //因为脊椎底部在右手的左边，我们加上0.05f，使它更接近右边。
                        float x = handRight.X - spineBase.X + 0.05f;                                              
                        //用这个来计算。它的脊柱底部比右方要低，我们加上0.51f来让它成为higer，
                        //值0.51是通过多次测试来计算的，你可以把它设置为你喜欢的另一个。
                        float y = spineBase.Y - handRight.Y + 0.51f;
                        // 得到当前光标位置
                        Point curPos = MouseControl.GetCursorPosition();
                        //使用的平滑度应该是0-0.95f。我们的算法是:oldPos + (newPos - oldPos) * smoothValue
                        float smoothing = 1 - cursorSmoothing;
                        // 设置光标位置
                        MouseControl.SetCursorPos((int)(curPos.X + (x  * mouseSensitivity * screenWidth - curPos.X) * smoothing), (int)(curPos.Y + ((y + 0.25f) * mouseSensitivity * screenHeight - curPos.Y) * smoothing));
                        
                        alreadyTrackedPos = true;

                        //控制动作
                        if (doClick && useGripGesture)
                        {//用握拳动作进行完成点击事件
                         ///////////////////////添加缩放功能/////////////////////////////
                            bool isZoom = (System.Math.Abs(handRight.Z - body.Joints[JointType.ShoulderRight].Position.Z) > 0.5);
                            if (body.HandRightState == HandState.Open && isZoom)
                            {                              
                                MouseControl.MouseAmplification();
                                System.Threading.Thread.Sleep(200);
                            }
                            else if (body.HandRightState == HandState.Closed && isZoom)
                            {                               
                                MouseControl.MouseNarrow();
                                System.Threading.Thread.Sleep(200);
                            }
   
                         ////////////////////////////////////////////////////
                            if (body.HandRightState == HandState.Closed && !isZoom)
                            {
                                if (!wasRightGrip)
                                {
                                    MouseControl.MouseLeftDown();
                                    wasRightGrip = true;
                                }
                            }
                            else if (body.HandRightState == HandState.Open && !isZoom)
                            {
                                if (wasRightGrip)
                                {
                                    MouseControl.MouseLeftUp();
                                    wasRightGrip = false;
                                }
                            }
                        }
                    }
            //////////////////实现双手识别///////////////////////////////////////////////
                    //else if (handLeft.Z - spineBase.Z < -0.15f) // if left hand lift forward
                    //{
                    //    float x = handLeft.X - spineBase.X + 0.3f;
                    //    float y = spineBase.Y - handLeft.Y + 0.51f;
                    //    Point curPos = MouseControl.GetCursorPosition();
                    //    float smoothing = 1 - cursorSmoothing;
                    //    MouseControl.SetCursorPos((int)(curPos.X + (x * mouseSensitivity * screenWidth - curPos.X) * smoothing), (int)(curPos.Y + ((y + 0.25f) * mouseSensitivity * screenHeight - curPos.Y) * smoothing));
                    //    alreadyTrackedPos = true;

                    //    if (doClick && useGripGesture)
                    //    {
                    //        if (body.HandLeftState == HandState.Closed)
                    //        {
                    //            if (!wasLeftGrip)
                    //            {
                    //                MouseControl.MouseLeftDown();
                    //                wasLeftGrip = true;
                    //            }
                    //        }
                    //        else if (body.HandLeftState == HandState.Open)
                    //        {
                    //            if (wasLeftGrip)
                    //            {
                    //                MouseControl.MouseLeftUp();
                    //                wasLeftGrip = false;
                    //            }
                    //        }
                    //    }
                    //}
                    else
                    {
                        wasLeftGrip = true;
                        wasRightGrip = true;
                        alreadyTrackedPos = false;
                    }

                    // 第一个被跟踪的身体
                    break;
                }
            }
        }

        public void Close()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }

            if (this.sensor != null)
            {
                this.sensor.Close();
                this.sensor = null;
            }
        }

    }
}
