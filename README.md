 KinectControlWebGL
======================
环境配置
----------------------
* VS2013
* kinect for Windows SDK

算法实现
-----------------------
* MouseControl实现对窗口数据的初始化
* MouseControl实现对鼠标控制，点击左键动作，中键滚动，光标控制
* KinectControl实现kinect骨骼识别，将手部位映射到计算机屏幕

软件使用
----------------------
 ![](https://github.com/Tast0/KinectControlWebGL/blob/master/KinectControlWebGL/20171016220250.jpg)  
*  `Mouse Sensitivity` 鼠标灵敏度设置，数值越大，则会导致手部发生微动就会引起光标移动
*  `Pause-To-Click Time Required`  确定点击动作，所需要的时间，此按键要与Pause To Click 按钮连用
*  `Pause Movement Thresold`  光标所控范围
*  `Cursor Smoothing`  光标平滑度，其数值越大，光标移动越连贯，但是会降低移动速度
*  `Grip Gesture`  握拳表示点击
*  `Pause To Click`  停留表示点击
*  `No clicks, move cursor only`  没有点击动作
*  `Default`  恢复默认设置


