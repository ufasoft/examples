
using System.Numerics;

namespace video_winforms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        //this.winFormmPlayerControl1.SetPlayer(new Player())
    }

	WMPLib.WindowsMediaPlayer Player;

	private void PlayFile(String url)
	{
		Player = new WMPLib.WindowsMediaPlayer();
		Player.openPlayer(url);
		Player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
		Player.MediaError += new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
		Player.enabled = true;
		Player.windowlessVideo = true;
		Player.uiMode = "full";
		Player.controls.play();
	}

	private void Player_PlayStateChange(int NewState)
	{
		if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
		{
			this.Close();
		}
	}

	private void Player_MediaError(object pMediaObject)
	{
		MessageBox.Show("Cannot play media file.");
		this.Close();
	}
	private void button1_Click_1(object sender, EventArgs e)
	{
        PlayFile(textBox1.Text);
	}
}
