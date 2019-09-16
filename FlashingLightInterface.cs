//Author: Michael Housworth
//Email: mhousworth@csu.fullerton.edu
//Course: CPSC 223n
//Semester: Fall 2019
//Assignment #: 1
//Program name: Flashing Red Stop Light


using System;
using System.Drawing;
using System.Windows.Forms;

public class FlashingLightInterface: Form{
	//Create member variables
	private static System.Timers.Timer FlashTimer;

	private Label title = new Label();
	private Button PauseResume = new Button();
	private Button Exit = new Button();
	private Size maximumFLInterfacesize = new Size(1920,1080);
	private Size minimumFLInterfacesize = new Size(1280,720);

	private bool Pause = false;
	private bool Flash = true;

	public FlashingLightInterface(){
		//Set Text
		Text = "Flashing Red Light Assignment";
		title.Text = "Flashing Red Light by Michael Housworth";
		title.TextAlign = ContentAlignment.TopCenter;
		PauseResume.Text = "Pause";
		Exit.Text = "Exit";

		//Set Size
		Size = minimumFLInterfacesize;
		title.Size = new Size(minimumFLInterfacesize.Width, 30);
		PauseResume.Size = new Size(80, 40);
		Exit.Size = new Size(80,40);

		//Set Location
		title.Location = new Point(0,0);
		PauseResume.Location = new Point(minimumFLInterfacesize.Width/2-160,minimumFLInterfacesize.Height-100);
		Exit.Location = new Point(minimumFLInterfacesize.Width/2+80,minimumFLInterfacesize.Height-100);
		//Set BackColor
		BackColor = Color.DarkCyan;
		title.BackColor = Color.LightGoldenrodYellow;
		PauseResume.BackColor = Color.Orange;
		Exit.BackColor = Color.Green;

		//Add Controls to the Form
		Controls.Add(title);
		Controls.Add(PauseResume);
		Controls.Add(Exit);

		//Register EventHandlers
		PauseResume.Click += new EventHandler(lightTrigger);
		Exit.Click += new EventHandler(exitApp);

		//Initialize Timer
		setTimer();
	}

	private void setTimer(){
		//Create Timer
		FlashTimer = new System.Timers.Timer(300);
		FlashTimer.Elapsed += flashLight;
		FlashTimer.AutoReset = true;
		FlashTimer.Enabled = true;
	}

	//Toggle Flash boolean
	private void flashLight(Object source, System.Timers.ElapsedEventArgs e){
		Flash = !Flash;
		Invalidate();
	}

	//Draw "Control Panel" rectangle, and if the Flash is true/false don't/do draw a red circle
	protected override void OnPaint(PaintEventArgs ee){
			Graphics graph = ee.Graphics;
			graph.FillRectangle(Brushes.Gold,0,600,1280,120);
			if(Flash)
      	graph.FillEllipse(Brushes.Red,480,140,320,320);  //Output a Red Circle
      //The next statement looks like recursion, but it really is not recursion.
      //In fact, it calls the method with the same name located in the super class.
      base.OnPaint(ee);
   }

	 //Toggle Pause/Resume Button
	 protected void lightTrigger(Object sender, EventArgs events){
		//Change Pause flag from true to false or vice-versa
		Pause = !Pause;
		//Start or stop Timer
		if(Pause == true){
			PauseResume.Text = "Resume";
			FlashTimer.Stop();
		}
		else{
			PauseResume.Text = "Pause";
			FlashTimer.Start();
		}
	}

	protected void exitApp(Object sender, EventArgs events){
		//Close program
		Close();
	}

}
