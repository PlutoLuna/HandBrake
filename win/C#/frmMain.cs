using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Handbrake
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // --------------------------------------------------------------
        // onLoad - setup the program ready for use.
        // --------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Set the Version number lable to the corect version.
            Version.Text = "Version " + Properties.Settings.Default.GuiVersion;

            // Run the update checker.
            updateCheck();

            // Now load the users default if required.
            loadUserDefaults();
            
        }

        public void loadUserDefaults()
        { 
            try
            {
                if (Properties.Settings.Default.defaultSettings == "Checked")
                {
                    //Source
                    text_source.Text = Properties.Settings.Default.DVDSource;
                    drp_dvdtitle.Text = Properties.Settings.Default.DVDTitle;
                    drop_chapterStart.Text = Properties.Settings.Default.ChapterStart;
                    drop_chapterFinish.Text = Properties.Settings.Default.ChapterFinish;
                    //Destination
                    text_destination.Text = Properties.Settings.Default.VideoDest;
                    drp_videoEncoder.Text = Properties.Settings.Default.VideoEncoder;
                    drp_audioCodec.Text = Properties.Settings.Default.AudioEncoder;
                    text_width.Text = Properties.Settings.Default.Width;
                    text_height.Text = Properties.Settings.Default.Height;
                    //Picture Settings Tab
                    drp_crop.Text = Properties.Settings.Default.CroppingOption;
                    text_top.Text = Properties.Settings.Default.CropTop;
                    text_bottom.Text = Properties.Settings.Default.CropBottom;
                    text_left.Text = Properties.Settings.Default.CropLeft;
                    text_right.Text = Properties.Settings.Default.CropRight;
                    drp_subtitle.Text = Properties.Settings.Default.Subtitles;
                    //Video Settings Tab
                    text_bitrate.Text = Properties.Settings.Default.VideoBitrate;
                    text_filesize.Text = Properties.Settings.Default.VideoFilesize;
                    slider_videoQuality.Value = Properties.Settings.Default.VideoQuality;
                    if (Properties.Settings.Default.TwoPass == "Checked")
                    {
                        check_2PassEncode.CheckState = CheckState.Checked;
                    }
                    if (Properties.Settings.Default.DeInterlace == "Checked")
                    {
                        check_DeInterlace.CheckState = CheckState.Checked;
                    }
                    if (Properties.Settings.Default.Grayscale == "Checked")
                    {
                        check_grayscale.CheckState = CheckState.Checked;
                    }

                    drp_videoFramerate.Text = Properties.Settings.Default.Framerate;

                    if (Properties.Settings.Default.PixelRatio == "Checked")
                    {
                        CheckPixelRatio.CheckState = CheckState.Checked;
                    }
                    if (Properties.Settings.Default.turboFirstPass == "Checked")
                    {
                        check_turbo.CheckState = CheckState.Checked;
                    }
                    if (Properties.Settings.Default.largeFile == "Checked")
                    {
                        check_largeFile.CheckState = CheckState.Checked;
                    }
                    //Audio Settings Tab
                    drp_audioBitrate.Text = Properties.Settings.Default.AudioBitrate;
                    drp_audioSampleRate.Text = Properties.Settings.Default.AudioSampleRate;
                    drp_audioChannels.Text = Properties.Settings.Default.AudioChannels;
                    //H264 Tab
                    if (Properties.Settings.Default.CRF == "Checked")
                    {
                        CheckCRF.CheckState = CheckState.Checked;
                    }
                    rtf_h264advanced.Text = Properties.Settings.Default.H264;
                }
            }
            catch (Exception)
            {
                // No real need to alert the user. Try/Catch only in just incase there is a problem reading the settings xml file.
            }
        }

        public void updateCheck()
        {
            if (Properties.Settings.Default.updateStatus == "Checked")
            {

                try
                {
                    String updateFile = Properties.Settings.Default.updateFile;
                    WebClient client = new WebClient();
                    String data = client.DownloadString(updateFile);
                    String[] versionData = data.Split('\n');

                    if ((versionData[0] != Properties.Settings.Default.GuiVersion) || (versionData[1] != Properties.Settings.Default.CliVersion))
                    {
                        lbl_update.Visible = true;
                    }
                }
                //else fail displaying an error message.
                catch (Exception)
                {
                    //Silently ignore the error
                }
            }
        }



        // --------------------------------------------------------------
        // The Menu Bar
        // --------------------------------------------------------------

        // FILE MENU --------------------------------------------------------------
        private void mnu_open_Click(object sender, EventArgs e)
        {
            File_Open.ShowDialog();
        }
        private void mnu_save_Click(object sender, EventArgs e)
        {
            File_Save.ShowDialog();
        }

        private void mnu_update_Click(object sender, EventArgs e)
        {
            Form Update = new frmUpdate();
            Update.Show();
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // TOOLS MENU --------------------------------------------------------------
        private void mnu_encode_Click(object sender, EventArgs e)
        {
            Form Queue = new frmQueue();
            Queue.Show();
        }

        private void mnu_viewDVDdata_Click(object sender, EventArgs e)
        {
            Form DVDData = new frmDVDData();
            DVDData.Show();
        }

        private void mnu_options_Click(object sender, EventArgs e)
        {
            Form Options = new frmOptions();
            Options.Show();
        }

        // PRESETS MENU --------------------------------------------------------------
        private void mnu_preset_ipod133_Click(object sender, EventArgs e)
        {
            CheckPixelRatio.CheckState = CheckState.Unchecked;
            text_width.Text = "640";
            text_height.Text = "480";
            drp_videoEncoder.Text = "H.264 (iPod)";
            text_bitrate.Text = "1000";
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            drp_audioBitrate.Text = "160";
            rtf_h264advanced.Text = "";
            drp_crop.Text = "No Crop";
        }

        private void mnu_preset_ipod178_Click(object sender, EventArgs e)
        {
            CheckPixelRatio.CheckState = CheckState.Unchecked;
            text_width.Text = "640";
            text_height.Text = "352";
            drp_videoEncoder.Text = "H.264 (iPod)";
            text_bitrate.Text = "1000";
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            drp_audioBitrate.Text = "160";
            rtf_h264advanced.Text = "";
            drp_crop.Text = "No Crop";
        }

        private void mnu_preset_ipod235_Click(object sender, EventArgs e)
        {
            CheckPixelRatio.CheckState = CheckState.Unchecked;
            text_width.Text = "640";
            text_height.Text = "272";
            drp_videoEncoder.Text = "H.264 (iPod)";
            text_bitrate.Text = "1000";
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            drp_audioBitrate.Text = "160";
            rtf_h264advanced.Text = "";
            drp_crop.Text = "No Crop";
        }

        private void mnu_appleTv_Click(object sender, EventArgs e)
        {
            text_width.Text = "";
            text_height.Text = "";
            drp_videoEncoder.Text = "H.264";
            text_bitrate.Text = "3000";
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            drp_audioBitrate.Text = "160";
            CheckPixelRatio.CheckState = CheckState.Checked;
            drp_audioSampleRate.Text = "48";
            rtf_h264advanced.Text = "bframes=3:ref=1:subme=5:me=umh:no-fast-pskip=1:no-dct-decimate=1:trellis=2";
            drp_crop.Text = "No Crop";
            
        }

        private void mnu_presetPS3_Click(object sender, EventArgs e)
        {
            CheckPixelRatio.CheckState = CheckState.Unchecked;
            text_width.Text = "";
            text_height.Text = "";
            drp_videoEncoder.Text = "H.264";
            text_bitrate.Text = "3000";
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            drp_audioBitrate.Text = "160";
            CheckPixelRatio.CheckState = CheckState.Checked;
            drp_audioSampleRate.Text = "48";
            rtf_h264advanced.Text = "level=41";
            drp_crop.Text = "No Crop";
        }

        private void mnu_ProgramDefaultOptions_Click(object sender, EventArgs e)
        {
            //Source
            Properties.Settings.Default.DVDSource = text_source.Text;
            Properties.Settings.Default.DVDTitle = drp_dvdtitle.Text;
            Properties.Settings.Default.ChapterStart = drop_chapterStart.Text;
            Properties.Settings.Default.ChapterFinish = drop_chapterFinish.Text;
            //Destination
            Properties.Settings.Default.VideoDest = text_destination.Text;
            Properties.Settings.Default.VideoEncoder = drp_videoEncoder.Text;
            Properties.Settings.Default.AudioEncoder = drp_audioCodec.Text;
            Properties.Settings.Default.Width = text_width.Text;
            Properties.Settings.Default.Height = text_height.Text;
            //Picture Settings Tab
            Properties.Settings.Default.CroppingOption = drp_crop.Text;
            Properties.Settings.Default.CropTop = text_top.Text;
            Properties.Settings.Default.CropBottom = text_bottom.Text;
            Properties.Settings.Default.CropLeft = text_left.Text;
            Properties.Settings.Default.CropRight = text_right.Text;
            Properties.Settings.Default.Subtitles = drp_subtitle.Text;
            //Video Settings Tab
            Properties.Settings.Default.VideoBitrate = text_bitrate.Text;
            Properties.Settings.Default.VideoFilesize = text_filesize.Text;
            Properties.Settings.Default.VideoQuality = slider_videoQuality.Value;
            Properties.Settings.Default.TwoPass = check_2PassEncode.CheckState.ToString();
            Properties.Settings.Default.DeInterlace = check_DeInterlace.CheckState.ToString();
            Properties.Settings.Default.Grayscale = check_grayscale.CheckState.ToString();
            Properties.Settings.Default.Framerate = drp_videoFramerate.Text;
            Properties.Settings.Default.PixelRatio = CheckPixelRatio.CheckState.ToString();
            Properties.Settings.Default.turboFirstPass = check_turbo.CheckState.ToString();
            Properties.Settings.Default.largeFile = check_largeFile.CheckState.ToString();
            //Audio Settings Tab
            Properties.Settings.Default.AudioBitrate = drp_audioBitrate.Text;
            Properties.Settings.Default.AudioSampleRate = drp_audioSampleRate.Text;
            Properties.Settings.Default.AudioChannels = drp_audioChannels.Text;
            //H264 Tab
            Properties.Settings.Default.CRF = CheckCRF.CheckState.ToString();
            Properties.Settings.Default.H264 = rtf_h264advanced.Text;
            Properties.Settings.Default.Save();
        }

        // Help Menu --------------------------------------------------------------
        private void mnu_wiki_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org/trac");
        }

        private void mnu_onlineDocs_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org/?page_id=11");
        }

        private void mnu_faq_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org/trac/wiki/WindowsGuiFaq");
        }

        private void mnu_homepage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org");
        }

        private void mnu_forum_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org/forum");
        }

        private void mnu_about_Click(object sender, EventArgs e)
        {
			Form About = new frmAbout();
            About.Show();
        }



        // -------------------------------------------------------------- 
        // Buttons on the main Window
        // --------------------------------------------------------------
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            String filename ="";
            text_source.Text = "";

            if (RadioDVD.Checked)
            {
                DVD_Open.ShowDialog();
                filename = DVD_Open.SelectedPath;
                if (filename != "")
                {
                    text_source.Text = filename;
                    Form frmReadDVD = new frmReadDVD(filename);
                    frmReadDVD.Show();
                }

            }
            else
            {
                ISO_Open.ShowDialog();
                filename = ISO_Open.FileName;
                if (filename != "")
                {
                    text_source.Text = filename;
                    Form frmReadDVD = new frmReadDVD(filename);
                    frmReadDVD.Show();
                }

            }

                
        }

        private void btn_destBrowse_Click(object sender, EventArgs e)
        {
            // TODO: Need to write some code to check if there is a reasonable amount of disk space left.

            DVD_Save.ShowDialog();
            text_destination.Text = DVD_Save.FileName;
        }

        private void btn_h264Clear_Click(object sender, EventArgs e)
        {
            rtf_h264advanced.Text = "";
        }

        private void GenerateQuery_Click(object sender, EventArgs e)
        {
            String query = GenerateTheQuery();
            QueryEditorText.Text = query;
        }

        private void btn_ClearQuery_Click(object sender, EventArgs e)
        {
            QueryEditorText.Text = "";
        }

        private void btn_queue_Click(object sender, EventArgs e)
        {
            Form Queue = new frmQueue();
            Queue.Show();
        }

        private void btn_encode_Click(object sender, EventArgs e)
        {
            String query = "";
 
            if (QueryEditorText.Text == "")
            {
                query = GenerateTheQuery();
                MessageBox.Show(query);
            }
            else
            {
                query = QueryEditorText.Text;
            }

            System.Diagnostics.Process hbProc = new System.Diagnostics.Process();
            hbProc.StartInfo.FileName = "hbcli.exe";
            hbProc.StartInfo.Arguments = query;
            hbProc.StartInfo.UseShellExecute = false;
            hbProc.Start();
            

            MessageBox.Show("The encode process has now started.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
       
            // TODO: Need to write a bit of code here to do process monitoring.
            // Note: hbProc.waitForExit will freeze the app, meaning one cannot add additional items to the queue during an encode.
        }

        // -------------------------------------------------------------- 
        // Items that require actions on frmMain
        // --------------------------------------------------------------


        private void drop_chapterStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryEditorText.Text = "";
            if ((drop_chapterFinish.Text != "Auto") && (drop_chapterStart.Text != "Auto"))
            {
                int chapterFinish = int.Parse(drop_chapterFinish.Text);
                int chapterStart = int.Parse(drop_chapterStart.Text);

                try
                {
                    if (chapterFinish < chapterStart)
                    {
                        MessageBox.Show("Invalid Chapter Range! - Final chapter can not be smaller than the starting chapter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Character Entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            
        }

        private void drop_chapterFinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryEditorText.Text = "";
            if ((drop_chapterFinish.Text != "Auto") && (drop_chapterStart.Text != "Auto"))
            {
                int chapterFinish = int.Parse(drop_chapterFinish.Text);
                int chapterStart = int.Parse(drop_chapterStart.Text);

                try
                {
                    if (chapterFinish > chapterStart)
                    {
                        MessageBox.Show("Invalid Chapter Range! - Start chapter can not be larger than the Final chapter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Character Entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void text_bitrate_TextChanged(object sender, EventArgs e)
        {
            text_filesize.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            CheckCRF.CheckState = CheckState.Unchecked;
        }

        private void text_filesize_TextChanged(object sender, EventArgs e)
        {
            text_bitrate.Text = "";
            slider_videoQuality.Value = 0;
            SliderValue.Text = "0%";
            CheckCRF.CheckState = CheckState.Unchecked;
        }

        private void slider_videoQuality_Scroll(object sender, EventArgs e)
        {
            SliderValue.Text = slider_videoQuality.Value.ToString() + "%";
            text_bitrate.Text = "";
            text_filesize.Text = "";
        }

        private void label_h264_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://handbrake.m0k.org/trac/wiki/x264Options");
        }




        //
        // The Query Generation Function
        //


        // This function was imported from old vb.net version of this application.
        // It could probably do with being cleaned up a good deal at some point
        public string GenerateTheQuery()
        {
            string source = text_source.Text;
            string dvdTitle = drp_dvdtitle.Text;
            string chapterStart = drop_chapterStart.Text;
            string chapterFinish = drop_chapterFinish.Text;
            int totalChapters = drop_chapterFinish.Items.Count - 1;
            string dvdChapter = "";

            if (source ==  "")
            {
                MessageBox.Show("No Source has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else{
                source = " -i " + '"' + source+ '"'; //'"'+
            }

            if (dvdTitle ==  "Automatic")
            {
                dvdTitle = "";
            }else{
                string[] titleInfo = dvdTitle.Split(' ');
                dvdTitle = " -t "+ titleInfo[0];
            }




            if ((chapterFinish.Equals("Auto") && chapterStart.Equals("Auto")))
            {
                dvdChapter = "";
            }
            else if (chapterFinish == chapterStart)
            {
                dvdChapter = " -c " + chapterStart;
            }

            else
            {
                dvdChapter = " -c " + chapterStart + "-" + chapterFinish;
            }

            string querySource = source+ dvdTitle+ dvdChapter;
            // ----------------------------------------------------------------------

            // Destination

            string destination = text_destination.Text;
            string videoEncoder = drp_videoEncoder.Text;
            string audioEncoder = drp_audioCodec.Text;
            string width = text_width.Text;
            string height = text_height.Text;
            if ((destination ==  ""))
            {
                MessageBox.Show("No destination has been selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                destination = " -o " + '"' + destination + '"'; //'"'+ 
            }

            if ((videoEncoder ==  "Mpeg 4"))
            {
                videoEncoder = " -e ffmpeg";
            }

            else if ((videoEncoder ==  "Xvid"))
            {
                videoEncoder = " -e xvid";
            }

            else if ((videoEncoder ==  "H.264"))
            {
                videoEncoder = " -e x264";
            }

            else if ((videoEncoder ==  "H.264 Baseline 1.3"))
            {
                videoEncoder = " -e x264b13";
            }

            else if ((videoEncoder ==  "H.264 (iPod)"))
            {
                videoEncoder = " -e x264b30";
            }

            if ((audioEncoder ==  "AAC"))
            {
                audioEncoder = " -E faac";
            }

            else if ((audioEncoder ==  "MP3"))
            {
                audioEncoder = " -E lame";
            }

            else if ((audioEncoder ==  "Vorbis"))
            {
                audioEncoder = " -E vorbis";
            }

            else if ((audioEncoder ==  "AC3"))
            {
                audioEncoder = " -E ac3";
            }

            if ((width !=  ""))
            {
                width = " -w "+ width;
            }

            if ((height !=  ""))
            {
                height = " -l "+ height;
            }

            string queryDestination = destination+ videoEncoder+ audioEncoder+ width+ height;
            // ----------------------------------------------------------------------

            // Picture Settings Tab

            string cropSetting = drp_crop.Text;
            string cropTop = text_top.Text;
            string cropBottom = text_bottom.Text;
            string cropLeft = text_left.Text;
            string cropRight = text_right.Text;
            string subtitles = drp_subtitle.Text;
            string cropOut = "";
            // Returns Crop Query

            if (cropSetting ==  "Auto Crop")
            {
                cropOut = "";
            }

            else if (cropSetting ==  "No Crop")
            {
                cropOut = " --crop 0:0:0:0 ";
            }

            else
            {
                cropOut = " --crop "+ cropTop+ ":"+ cropBottom+ ":"+ cropLeft+ ":"+ cropRight;
            }

            if ((subtitles ==  "None"))
            {
                subtitles = "";
            }

            else if ((subtitles ==  ""))
            {
                subtitles = "";
            }

            else
            {
                string[] tempSub;
                tempSub = subtitles.Split(' ');
                subtitles = " -s "+ tempSub[0];
            }

            string queryPictureSettings = cropOut+ subtitles;
            // ----------------------------------------------------------------------

            // Video Settings Tab

            string videoBitrate = text_bitrate.Text;
            string videoFilesize = text_filesize.Text;
            int videoQuality = slider_videoQuality.Value;
            string vidQSetting;
            string twoPassEncoding = check_2PassEncode.CheckState.ToString();
            string deinterlace = check_DeInterlace.CheckState.ToString();
            string grayscale = check_grayscale.CheckState.ToString();
            string videoFramerate = drp_videoFramerate.Text;
            string pixelRatio = CheckPixelRatio.CheckState.ToString();
            string ChapterMarkers = Check_ChapterMarkers.CheckState.ToString();
            string turboH264 = check_turbo.CheckState.ToString();
            string largeFile = check_largeFile.CheckState.ToString();

            if ((videoBitrate !=  ""))
            {
                videoBitrate = " -b "+ videoBitrate;
            }

            if ((videoFilesize !=  ""))
            {
                videoFilesize = " -S "+ videoFilesize;
            }

            // Video Quality Setting

            if ((videoQuality ==  0))
            {
                vidQSetting = "";
            }

            else
            {
                videoQuality = videoQuality/ 100;
                if (videoQuality ==  1)
                {
                    vidQSetting = "1.0";
                }

                vidQSetting = " -q " + videoQuality.ToString();
            }

            if ((twoPassEncoding ==  "1"))
            {
                twoPassEncoding = " -2 ";
            }

            else
            {
                twoPassEncoding = "";
            }

            if ((deinterlace ==  "1"))
            {
                deinterlace = " -d ";
            }

            else
            {
                deinterlace = "";
            }

            if ((grayscale ==  "1"))
            {
                grayscale = " -g ";
            }

            else
            {
                grayscale = "";
            }

            if ((videoFramerate ==  "Automatic"))
            {
                videoFramerate = "";
            }

            else
            {
                videoFramerate = " -r "+ videoFramerate;
            }

            if ((pixelRatio ==  "1"))
            {
                pixelRatio = " -p ";
            }

            else
            {
                pixelRatio = "";
            }

            if ((ChapterMarkers ==  "1"))
            {
                ChapterMarkers = " -m ";
            }

            else
            {
                ChapterMarkers = "";
            }

            if ((turboH264 ==  "1"))
            {
                turboH264 = " -T ";
            }

            else
            {
                turboH264 = "";
            }

            if ((largeFile ==  "1"))
            {
                largeFile = " -4 ";
            }

            else
            {
                largeFile = "";
            }

            string queryVideoSettings = videoBitrate + videoFilesize + vidQSetting + twoPassEncoding + deinterlace + grayscale + videoFramerate + pixelRatio + ChapterMarkers + turboH264 + largeFile;
            // ----------------------------------------------------------------------

            // Audio Settings Tab

            string audioBitrate = drp_audioBitrate.Text;
            string audioSampleRate = drp_audioSampleRate.Text;
            string audioChannels = drp_audioChannels.Text;
            string Mixdown = drp_audioMixDown.Text;
            string SixChannelAudio = "";
            if ((audioBitrate !=  ""))
            {
                audioBitrate = " -B "+ audioBitrate;
            }

            if ((audioSampleRate !=  ""))
            {
                audioSampleRate = " -R "+ audioSampleRate;
            }

            if ((audioChannels ==  "Automatic"))
            {
                audioChannels = "";
            }

            else if ((audioChannels ==  ""))
            {
                audioChannels = "";
            }

            else
            {
                string[] tempSub;
                tempSub = audioChannels.Split(' ');
                audioChannels = " -a "+ tempSub[0];
            }

            if ((Mixdown ==  "Automatic"))
            {
                Mixdown = "";
            }

            else if (Mixdown ==  "Mono")
            {
                Mixdown = "mono";
            }

            else if (Mixdown ==  "Stereo")
            {
                Mixdown = "stereo";
            }

            else if (Mixdown ==  "Dolby Surround")
            {
                Mixdown = "dpl1";
            }

            else if (Mixdown ==  "Dolby Pro Logic II")
            {
                Mixdown = "dpl2";
            }

            else if (Mixdown ==  "6 Channel Discrete")
            {
                Mixdown = "6ch";
            }

            else
            {
                Mixdown = "stero";
            }

            if ((Mixdown !=  ""))
            {
                SixChannelAudio = " -6 "+ Mixdown;
            }

            else
            {
                SixChannelAudio = "";
            }

            string queryAudioSettings = audioBitrate+ audioSampleRate+ audioChannels+ SixChannelAudio;
            // ----------------------------------------------------------------------

            //  H.264 Tab

            string CRF = CheckCRF.CheckState.ToString();
            string h264Advanced = rtf_h264advanced.Text;
            if ((CRF ==  "1"))
            {
                CRF = " -Q ";
            }

            else
            {
                CRF = "";
            }

            if ((h264Advanced ==  ""))
            {
                h264Advanced = "";
            }

            else
            {
                h264Advanced = " -x "+ h264Advanced;
            }

            string h264Settings = CRF+ h264Advanced;
            // ----------------------------------------------------------------------

            // Processors (Program Settings)

            string processors = Properties.Settings.Default.Processors;
            //  Number of Processors Handler

            if ((processors ==  "Automatic"))
            {
                processors = "";
            }

            else
            {
                processors = " -C "+ processors+ " ";
            }

            string queryAdvancedSettings = processors;
            // ----------------------------------------------------------------------

            //  Verbose option (Program Settings)

            string verbose = "";
            if ( Properties.Settings.Default.verbose ==  "1")
            {
                verbose = " -v ";
            }

            // ----------------------------------------------------------------------

            return querySource+ queryDestination+ queryPictureSettings+ queryVideoSettings+ h264Settings+ queryAudioSettings+ queryAdvancedSettings+ verbose;
        }

        

        

        // This is the END of the road ------------------------------------------------------------------------------
    }
}